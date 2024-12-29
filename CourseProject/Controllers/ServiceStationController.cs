using System.IO;
using CourseProject.Infrastructure.Factories;
using CourseProject.Models.Entities;
using CourseProject.Models.Queries;
using System.Text;
using System.Windows;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Controllers;


public class ServiceStationController(ServiceStationContext db)
{
    public ServiceStationController() : this(new ServiceStationContext()) { }

    // чтение всех записей
    public List<Person> GetAllPeople() => db.People.ToList();

    public List<Client> GetAllClients() => db.Clients.ToList();

    public List<Specialization> GetAllSpecializations() => db.Specializations.ToList();

    public List<Employee> GetAllEmployees() => db.Employees.ToList();

    public List<Service> GetAllServices() => db.Services.ToList();

    public List<Defect> GetAllDefects() => db.Defects.ToList();

    public List<Color> GetAllColors() => db.Colors.ToList();

    public List<Brand> GetAllBrands() => db.Brands.ToList();

    public List<Car> GetAllCars() => db.Cars.ToList();

    public List<Visit> GetAllVisits() => db.Visits.ToList();

    // 1. Фамилия, имя, отчество владельца автомобиля
    // с данным номером государственной регистрации
    public async Task<List<Person>> Query01(string stateNumber) =>
        await db.Cars
            .Where(car => car.StateNumber == stateNumber)
            .Select(car => new Person
            {
                Surname = car.Owner.Surname,
                Name = car.Owner.Name,
                Patronymic = car.Owner.Patronymic
            })
            .ToListAsync();

    // 2. Марка и год выпуска автомобиля данного владельца
    public async Task<List<Car>> Query02(Person owner) =>
        await db.Cars
            .Where(car => car.Owner == owner)
            .Select(car => new Car
            {
                Brand = car.Brand,
                Color = car.Color,
                Owner = car.Owner,
                ReleaseYear = car.ReleaseYear,
                StateNumber = car.StateNumber
            })
            .ToListAsync();

    // 3. Перечень устраненных неисправностей в автомобиле данного владельца
    public async Task<List<Defect>> Query03(Person owner) =>
        await db.Visits
            .Where(visit => visit.Car.Owner == owner && visit.IsPaid)
            .Select(visit => visit.Defect)
            .ToListAsync();

    // 4. Фамилия, имя, отчество работника станции, устранявшего данную неисправность
    // в автомобиле данного клиента, и время ее устранения
    public async Task<List<Query04>> Query04(Client client, Defect defect) =>
        await db.Visits
            .Where(visit => visit.Client == client && visit.Defect == defect && visit.IsPaid)
            .Select(visit => new Query04 (
                visit.Id,
                visit.Employee.Person,
                visit.DateOfIssue
            ))
            .ToListAsync();

    // 5. Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным типом неисправности
    public async Task<List<Client>> Query05(Defect defect) =>
        await db.Visits
            .Where(visit => visit.Defect == defect)
            .Select(visit => visit.Client)
            .Select(client => new Client {
                Person = client.Person,
                BirthDate = client.BirthDate,
                Passport = client.Passport,
                Registration = client.Registration
            })
            .ToListAsync();

    // 6. Самая распространенная неисправность в автомобилях указанной марки
    public async Task<List<Defect>> Query06(Brand brand) =>
        await db.Visits
            .Where(visit => visit.Car.Brand == brand)
            .GroupBy(visit => visit.Defect)
            .OrderByDescending(group => group.Count())
            .Select(group => group.Key)
            .ToListAsync();

    // 7. Количество рабочих каждой специальности на станции
    public async Task<List<Query07>> Query07() =>
        await db.Employees
            .GroupBy(employee => employee.Specialization)
            .Select(group => new Query07
            (
                group.Key,
                group.Count()
            ))
            .ToListAsync();

    // Количество автомобилей в ремонте на текущий момент
    public async Task<int> GetCarsInRepairCount() =>
        await db.Visits
            // Автомобиль еще не выдан
            .Where(visit => visit.DateOfIssue > DateTime.Now) 
            .Select(visit => visit.CarId)
            .Distinct()
            .CountAsync();

    // Количество незанятых рабочих на текущий момент
    public async Task<int> GetFreeWorkersCount() =>
       await db.Employees
            .CountAsync(employee => !employee.IsEmployed);

    // Количество устраненных неисправностей каждого вида
    public async Task<Dictionary<string, int>> GetMonthlyDefectsCount(DateTime reportDate) =>
        await db.Visits
        .Where(visit => visit.DateOfIssue <= reportDate)
        .GroupBy(visit => visit.Defect.Name)
        .ToDictionaryAsync(group => group.Key, group => group.Count());

    // Доход, полученный станцией
    public async Task<int> GetMonthlyIncome(DateTime reportDate) =>
        await db.Visits
        .Where(visit => visit.IsPaid)
        .SumAsync(visit => visit.Service.Cost);

    // Перечень отремонтированных автомобилей
    public async Task<List<RepairedCar>> GetRepairedCars(DateTime reportDate) =>
        await db.Visits
            .Where(visit => visit.DateOfIssue < reportDate)
            .GroupBy(visit => visit.Car)
            .Select(group => new RepairedCar(
                group.First().Id,
                group.Key,
                group.Select(v => v.Defect.Name).Distinct().ToList(),
                group.Select(v => v.Employee).Distinct().ToList(),
                group.Min(v => v.DateOfApplication),
                group.Max(v => v.DateOfIssue)
            ))
            .ToListAsync();

    // Автомобили, находящиеся в ремонте
    public async Task<List<CarInRepair>> GetCarsInRepairDetails(DateTime reportDate) =>
        await db.Visits
            .Where(visit => visit.DateOfIssue > reportDate)
            .GroupBy(visit => visit.Car)
            .Select(group => new CarInRepair(
                group.First().Id,
                group.Key,
                group.Min(v => v.DateOfApplication),
                group.Select(v => v.Defect.Name).Distinct().ToList(),
                group.Select(v => v.Employee).Distinct().ToList()
            ))
            .ToListAsync();

    // Месячный отсчет
    public async Task MonthlyReport(string filePath)
    {
        var reportDate = DateTime.Now;

        var defectsCount = await GetMonthlyDefectsCount(reportDate);
        var income = await GetMonthlyIncome(reportDate);
        var repairedCars = await GetRepairedCars(reportDate);
        var carsInRepair = await GetCarsInRepairDetails(reportDate);

        // Формирование отчета
        var reportBuilder = new StringBuilder();

        reportBuilder.AppendLine($"Отчет за {reportDate:MMMM yyyy}:");
        reportBuilder.AppendLine($"Общий доход: {income} руб.");

        reportBuilder.AppendLine("\nКоличество устраненных неисправностей:");
        foreach (var (defect, count) in defectsCount)
            reportBuilder.AppendLine($"- {defect}: {count}");

        reportBuilder.AppendLine("\nОтремонтированные автомобили:");
        foreach (var item in repairedCars)
            reportBuilder.AppendLine($"- {item.Car.Brand.Name} ({item.Car.Color.Name}): {item.StartDate:dd.MM.yyyy} - {item.EndDate:dd.MM.yyyy}");

        reportBuilder.AppendLine("\nАвтомобили в ремонте:");
        foreach (var item in carsInRepair)
        {
            reportBuilder.AppendLine($"- {item.Car.Brand.Name} ({item.Car.Color.Name}): с {item.StartDate:dd.MM.yyyy}");
            reportBuilder.AppendLine($"  Неисправности: {string.Join(", ", item.Defects)}");
            reportBuilder.AppendLine($"  Работники: {string.Join(", ", item.Employees.Select(e => $"{e.Person.Surname} {e.Person.Name}"))}");
        }

        // Запись в файл
        await File.WriteAllTextAsync(filePath, reportBuilder.ToString(), Encoding.UTF8);

        MessageBox.Show("Отчет успешно сохранен!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // Автомобили в ремонте
    public async Task CarsInRepair(string filePath)
    {
        var reportDate = DateTime.Now;

        var carsInRepairCount = await GetCarsInRepairCount();

        // Формирование отчета
        var reportBuilder = new StringBuilder();

        reportBuilder.AppendLine($"Справка о количестве автомобилей в ремонте за {reportDate:MMMM yyyy}:");
        reportBuilder.AppendLine($"Количество автомобилей в ремонте на текущий момент: {carsInRepairCount} шт.");

        // Запись в файл
        await File.WriteAllTextAsync(filePath, reportBuilder.ToString(), Encoding.UTF8);

        MessageBox.Show("Справка успешно сохранена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // Незанятые рабочие
    public async Task FreeWorkers(string filePath)
    {
        var reportDate = DateTime.Now;

        var freeWorkers = await GetFreeWorkersCount();

        // Формирование отчета
        var reportBuilder = new StringBuilder();

        reportBuilder.AppendLine($"Справка о количестве незанятых рабочих за {reportDate:MMMM yyyy}:");
        reportBuilder.AppendLine($"Количество незанятых рабочих на текущий момент: {freeWorkers} чел.");

        // Запись в файл
        await File.WriteAllTextAsync(filePath, reportBuilder.ToString(), Encoding.UTF8);

        MessageBox.Show("Справка успешно сохранена!", "Информация", MessageBoxButton.OK, MessageBoxImage.Information);
    }

    // Сохранение справки об автомобилях в ремонте
    public async Task SaveCarsInRepairWithDialog(object o)
    {
        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = "Текстовые файлы (*.txt)|*.txt",
            DefaultExt = ".txt",
            Title = "Сохранить справку о количестве автомобилей в ремонте",
            FileName = $"Количество автомобилей в ремонте_{DateTime.Now:yyyy_MM}.txt"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            await CarsInRepair(saveFileDialog.FileName);
        }
    }

    // Сохранение справки о свободых рабочих
    public async Task SaveFreeWorkersWithDialog(object o)
    {
        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = "Текстовые файлы (*.txt)|*.txt",
            DefaultExt = ".txt",
            Title = "Сохранить справку о количестве незанятых рабочих",
            FileName = $"Количество незанятых работников_{DateTime.Now:yyyy_MM}.txt"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            await FreeWorkers(saveFileDialog.FileName);
        }
    }

    // Сохранение месячного отсчета
    public async Task SaveMonthReportWithDialog(object o)
    {
        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
        {
            Filter = "Текстовые файлы (*.txt)|*.txt",
            DefaultExt = ".txt",
            Title = "Сохранить отчет",
            FileName = $"Отчет_{DateTime.Now:yyyy_MM}.txt"
        };

        if (saveFileDialog.ShowDialog() == true)
        {
            await MonthlyReport(saveFileDialog.FileName);
        }
    }

    // добавление нового цвета
    public async Task AddColor(Color color) {
        db.Colors.Add(color);
        await db.SaveChangesAsync();
    }

    // добавление новой специальности
    public async Task AddSpecialization(Specialization specialization)
    {
        db.Specializations.Add(specialization);
        await db.SaveChangesAsync();
    }

    // добавление новой марки автомобиля
    public async Task AddBrand(Brand brand) {
        db.Brands.Add(brand);
        await db.SaveChangesAsync();
    }

    // добавление нового автомобиля
    public async Task AddCar(Car car) {

        db.Cars.Add(car);
        await db.SaveChangesAsync();
    }

    // добавление нового работника
    public async Task AddEmployee(Employee employee)
    {
        db.Employees.Add(employee);
        await db.SaveChangesAsync();
    }

    // добавление нового клиента
    public async Task AddClient(Client client)
    {
        db.Clients.Add(client);
        await db.SaveChangesAsync();
    }

    // добавить неисправность
    public async Task AddDefect(Defect defect)
    {
        db.Defects.Add(defect);
        await db.SaveChangesAsync();
    }

    // добавить посещение
    public async Task AddVisit(Visit visit)
    {
        db.Visits.Add(visit);
        await db.SaveChangesAsync();
    }

    // изменение клиента
    public void UpdateClient(Client client) { 
       db.Clients.Update(client);
       db.SaveChanges();
    }

    // изменение работника
    public void UpdateEmployee(Employee employee)
    {
        db.Employees.Update(employee);
        db.SaveChanges();
    }

    // изменение автомобиля
    public void UpdateCar(Car car)
    {
       db.Cars.Update(car);
       db.SaveChanges();
    }

    // изменение посещения
    public void UpdateVisit(Visit visit)
    {
        db.Visits.Update(visit);
        db.SaveChanges();
    }

    // удалить работника
    public void DeleteEmployee(Employee employee)
    {
        db.Employees.Remove(employee);
        db.SaveChanges();
    }

    // удалить посещение
    public void DeleteVisit(Visit visit)
    {
        db.Visits.Remove(visit);
        db.SaveChanges();
    }

} // class ServiceStationController
