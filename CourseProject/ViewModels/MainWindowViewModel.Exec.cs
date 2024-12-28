using System.Windows;
using CourseProject.Models.Entities;
using CourseProject.Views.ChoiceWindows;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class MainWindowViewModel
{
    // добавление нового цвета
    private async Task AddColorExec(object o)
    {
        var dictionary = _controller.GetAllColors()
            .ToDictionary(c => c.Name);

        AddColorWindow dialog = new(_controller.GetAllColors());

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string color = dialog.Color.ToLower();

        if (!dictionary.ContainsKey(color))
        {
            await _controller.AddColor(new Color { Name = color });

            MessageBox.Show($"Цвет '{color}' успешно добавлен.");

        }
        else
        {
            MessageBox.Show($"Цвет '{color}' уже существует.");
        }
    }

    // открытие окна клиента
    private void ShowClientExec(object o)
    {
        var client = (Client)HostWindow.DgClients.SelectedItem;

        if (client == null) return;

        var prefix = "/Assets/People/";
        client.PathPhoto = (client.PathPhoto.StartsWith(prefix) ? "" : prefix) + client.PathPhoto;
        var win = new EditClientWindow(client, _controller);

        win.ShowDialog();

        FillDataGrids();
    } // ShowClientExec

    // открытие окна автомобиля
    private void ShowCarExec(object o)
    {
        var car = (Car)HostWindow.DgCars.SelectedItem;

        if (car == null) return;

        var prefix = "/Assets/Cars/";
        car.PathPhoto = (car.PathPhoto.StartsWith(prefix) ? "" : prefix) + car.PathPhoto;
        var win = new EditCarWindow(car, _controller);

        win.ShowDialog();

        FillDataGrids();
    } // ShowCarExec

    // добавление новой марки автомобиля
    private async Task AddBrandExec(object o)
    {
        // Получить словарь всех названий марок из базы данных
        var brands = _controller.GetAllBrands()
            .ToDictionary(item => item.Name.ToLower());

        // Открыть диалог для ввода новой марки
        AddBrandWindow dialog = new(_controller.GetAllBrands());

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string brand = dialog.Brand;

        // Проверить наличие марки и добавить, если его нет
        if (!brands.ContainsKey(brand.ToLower()))
        {
            await _controller.AddBrand(new Brand { Name = brand });
            MessageBox.Show($"Марка '{brand}' успешно добавлена.");
        }
        else
        {
            MessageBox.Show($"Марка '{brand}' уже существует.");
        }
    }

    // добавление автомобиля
    private void AddCarExec(object o)
    {
        AddCarWindow dialog = new();

        if (dialog.ShowDialog() == false)
        {
            return;
        }

        FillDataGrids();
    }

    // добавление клиента
    private void AddClientExec(object o)
    {
        AddClientWindow dialog = new();

        if (dialog.ShowDialog() == false)
        {
            return;
        }

        FillDataGrids();
    }

    // добавление посещения
    private void AddVisitExec(object o)
    {
        VisitWindow dialog = new(_controller.GetAllEmployees(), _controller.GetAllCars(), _controller.GetAllClients());

        if (dialog.ShowDialog() == false)
        {
            return;
        }

        FillDataGrids();
    }

    // 1. Фамилия, имя, отчество и адрес владельца автомобиля
    // с данным номером государственной регистрации
    private async Task Query01Exec(object o)
    {

        var dialog = new StateNumberChoiceWindow();

        if (dialog.ShowDialog() == false)
        {
            return;
        } // if

        string stateNumber = dialog.StateNumber;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var people = await _controller.Query01(stateNumber);

        var peopleWindow = new PeopleWindow(people) { SpButtons = { Visibility = Visibility.Hidden } };

        peopleWindow.ShowDialog();
    } // Query01Exec

    // 2. Марка и год выпуска автомобиля данного владельца
    private async Task Query02Exec(object o)
    {
        var dialog = new PeopleWindow(_controller.GetAllPeople());

        if (dialog.ShowDialog() == false)
        {
            return;
        } // if

        var person = dialog.Person;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var cars = await _controller.Query02(person);

        new CarsWindow(cars).ShowDialog();

    } // Query02Exec

    // 3. Перечень устраненных неисправностей в автомобиле данного владельца
    private async Task Query03Exec(object o)
    {

        var dialog = new PeopleWindow(_controller.GetAllPeople());

        if (dialog.ShowDialog() == false)
        {
            return;
        } // if

        var person = dialog.Person;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var defects = await _controller.Query03(person);

        var defectsWindow = new DefectsWindow(defects) { SpButtons = { Visibility = Visibility.Hidden } };

        defectsWindow.ShowDialog();
    } // Query03Exec

    // 4. Фамилия, имя, отчество работника станции, устранявшего данную неисправность
    // в автомобиле данного клиента, и время ее устранения
    private async Task Query04Exec(object o)
    {
        var dialogDefect = new DefectsWindow(_controller.GetAllDefects());

        if (dialogDefect.ShowDialog() == false)
        {
            return;
        } // if

        Defect defect = dialogDefect.Defect;

        var dialogClient = new ClientsWindow(_controller.GetAllClients());

        if (dialogClient.ShowDialog() == false)
        {
            return;
        } // if

        Client client = dialogClient.Client;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var data = await _controller.Query04(client, defect);

        new Query04Window(data).ShowDialog();

    } // Query04Exec

    // 5. Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили
    // с указанным типом неисправности
    private async Task Query05Exec(object o)
    {
        var dialog = new DefectsWindow(_controller.GetAllDefects());

        if (dialog.ShowDialog() == false)
        {
            return;
        } // if

        Defect defect = dialog.Defect;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var clients = await _controller.Query05(defect);

        var clientWindow = new ClientsWindow(clients) { SpButtons = { Visibility = Visibility.Hidden } };

        clientWindow.ShowDialog();
    } // Query05Exec

    // 6. Самая распространенная неисправность в автомобилях указанной марки
    private async Task Query06Exec(object o)
    {

        var dialog = new BrandsWindow(_controller.GetAllBrands());

        if (dialog.ShowDialog() == false)
        {
            return;
        } // if

        Brand brand = dialog.Brand;

        // выполнить запрос, получить выборку (коллекцию) для отображения
        var defect = await _controller.Query06(brand);

        var defectWindow = new DefectsWindow(defect) { SpButtons = { Visibility = Visibility.Hidden } };

        defectWindow.ShowDialog();
    } // Query06Exec

    // 7. Количество рабочих каждой специальности на станции
    private async Task Query07Exec(object o) =>
        new Query07Window(await _controller.Query07()).ShowDialog();
}