using CourseProject.Infrastructure;
using CourseProject.Models.Entities;
using CourseProject.Models.Queries;

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


    // 1. Запрос с параметром
    // Выбирает информацию о клиенте по номеру паспорта
    public List<Client> Query01(string passport) => db
        .Clients
        .Where(c => c.Passport == passport)
        .ToList();

    // 2. Запрос с параметром
    // Выбирает информацию о договорах страхования клиента с заданным номером паспорта
    //public List<Visit> Query02(string passport) => db
    //    .Contracts
    //    .Where(ic => ic.Client.Passport == passport)
    //    .ToList();

    // 3. Запрос с параметрами
    // Выбирает информацию о клиентах, заключивших договоры на сумму в заданном диапазоне значений

   // public List<Client> Query03(int minAmount, int maxAmount) => db
   //     .Contracts
   //     .Where(ic => ic.InsurancePrice >= minAmount && ic.InsurancePrice <= maxAmount)
   //     .Select(ic => ic.Client)
   //     .Distinct()
   //     .ToList();

    // 4. Запрос с параметром
    // Выбирает информацию об агентах с заданной фамилией
    //public List<Employee> Query04(string surname) => db
    //    .Agents
    //    .Where(a => a.Surname == surname)
    //    .ToList();

    // 5. Запрос с параметром, итогами
    // Выбирает информацию о договорах заданного клиента.
    // Выводить также итоговую информацию: количество договоров, сумму договоров 
   // public List<Query05> Query05(Client client) => db
   //     .Contracts
   //     .Where(ic => ic.Client.Equals(client))
   //     .Select(ic => new Query05(
   //         ic.Id,
   //         ic.Client.FullName,
   //         ic.Client.Passport,
   //         ic.Client.Discount,
   //         ic.Client.Contracts.Count,
   //         ic.Client.Contracts.Sum(i => i.InsurancePrice)))
   //     .ToList();

    // 6. Запрос с параметром, итогами
    // Выбирает информацию о договорах заданного агента.
    // Выводить также итоговую информацию: количество договоров, сумму договоров
    //public List<Query06> Query06(Employee agent) => db
    //    .Contracts
    //    .Where(ic => ic.Employee.Equals(agent))
    //    .Select(ic => new Query06(
    //        ic.Id,
    //        ic.Employee.FullName,
    //        ic.Employee.Passport,
    //        ic.Employee.Commission,
    //        ic.Employee.Contracts.Count,
    //        ic.Employee.Contracts.Sum(i => i.InsurancePrice)))
    //    .ToList();

    // 7. Запрос с параметром, итогами
    // Выбирает информацию о договорах с заданным видом страхования.
    // Выводить также итоговую информацию: количество договоров, сумму договоров
   // public List<Query07> Query07(string insuranceType) => db
   //     .Contracts
   //     .Where(ic => ic.InsuranceType == insuranceType)
   //     .Select(ic => new Query07(
   //         ic.Id,
   //         ic.InsuranceType,
   //         ic.InsurancePrice,
   //         ic.Tariff,
   //         ic.ContractDate,
   //         ic.Employee.Contracts.Count,
   //         ic.Employee.Contracts.Sum(c => c.InsurancePrice)
   //     ))
   //     .ToList();

    // 8. Запрос на добавление
    // Добавление договора страхования. 
    //public void Query08(Visit contract)
    //{
    //    db.Contracts.Add(contract);
    //    db.SaveChanges();
    //}

    // 9. Запрос на изменение
    // Редактирование договора страхования по идентификатору
   // public void Query09(int contractId)
   // {
   //     var contract = db.Contracts.FirstOrDefault(item => item.Id == contractId);
   //     if (contract == null) return;
   //
   //     contract.InsuranceType = "Личное";
   //     contract.InsurancePrice = Utils.GetRandom(1000, 200000);
   //     contract.Tariff = Utils.GetRandom(1, 20);
   //     contract.ContractDate = DateTime.Now;
   //
   //     db.Contracts.Update(contract);
   //
   //     db.SaveChanges();
   // }

    // 10. Запрос на удаление
    // Удаление договора страхования по идентификатору
   // public void Query10(int contractId)
   // {
   //     var contract = db.Contracts.FirstOrDefault(item => item.Id == contractId);
   //     if (contract == null) return;
   //     db.Contracts.Remove(contract);
   //     db.SaveChanges();
   // }

   public void AddColor(Color color)
   {
        db.Colors.Add(color);
        db.SaveChanges();
    }
} // class ServiceStationController
