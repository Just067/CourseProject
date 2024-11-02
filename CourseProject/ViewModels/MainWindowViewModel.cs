using System.Windows;
using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views;
using CourseProject.Views.ChoiceWindows;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

// Команды приложения
public partial class MainWindowViewModel
{
    private ServiceStationController _controller;

    public MainWindow HostWindow { get; set; }

    public RelayCommand ExitCommand { get; set; }

    public RelayCommand EmployeesCommand { get; set; }

    public RelayCommand VisitCommand { get; set; }

    public RelayCommand AddColor { get; set; }

    public RelayCommand AddBrand { get; set; }

    public MainWindowViewModel(MainWindow hostWindow, ServiceStationController controller) {
        HostWindow = hostWindow;
        _controller = controller;

        ExitCommand = new(_ => Application.Current.Shutdown(0));

        EmployeesCommand = new(_ => new EmployeesWindow(_controller.GetAllEmployees()).ShowDialog());

        VisitCommand = new(_ => new VisitWindow(_controller.GetAllEmployees()).ShowDialog());

        AddColor = new(AddColorExec);

        AddBrand = new(AddBrandExec);

        FillDataGrids();


    } // MainWindowViewModel

    public void FillDataGrids()
    {
        HostWindow.DgClients.ItemsSource = _controller.GetAllClients();
        //HostWindow.DgSpecializations.ItemsSource = _controller.GetAllSpecializations();
        //HostWindow.DgPeople.ItemsSource = _controller.GetAllPeople();
        //HostWindow.DgBrands.ItemsSource = _controller.GetAllBrands();
        HostWindow.DgCars.ItemsSource = _controller.GetAllCars();
        //HostWindow.DgDefects.ItemsSource = _controller.GetAllDefects();
        //HostWindow.DgColors.ItemsSource = _controller.GetAllColors();
        //HostWindow.DgServices.ItemsSource = _controller.GetAllServices();
        HostWindow.DgVisits.ItemsSource = _controller.GetAllVisits();
    }



    // 2. Запрос с параметром
    // Выбирает информацию о договорах страхования клиента с заданным номером паспорта
    private void Query02Exec()
    {

        // получить параметр запроса из диалогового окна
        var passports = _controller.GetAllClients()
            .Select(item => item.Passport)
            .Distinct()
            .ToArray();

        PassportChoiceWindow dialog = new PassportChoiceWindow(passports);

        if (dialog.ShowDialog() != true)
        {
            return;
        } // if

        string passport = dialog.Passport;

        //// выполнить запрос, получить выборку (коллекцию) для отобржаения
        //var contracts = _controller.Query02(passport);
        //
        //new ResultVisitsWindow(contracts).ShowDialog();
    } // Query02Exec

    // команда выполнения запроса 2
    public RelayCommand Query02Command => new(o => Query02Exec(), o => true);

    // 3. Запрос с параметрами
    // Выбирает информацию о клиентах, заключивших договоры на сумму в заданном диапазоне значений
    private void Query03Exec()
    {

        //// получить параметр запроса из диалогового окна
        //var prices = _controller.GetAllVisits()
        //    .Select(item => item.InsurancePrice.ToString())
        //    .Distinct()
        //    .ToArray();

        //SumChoiceWindow dialog = new SumChoiceWindow(prices);
        //
        //if (dialog.ShowDialog() != true)
        //{
        //    return;
        //} // if
        //
        //var (lo, hi) = (Convert.ToInt32(dialog.Lo), Convert.ToInt32(dialog.Hi));
        //
        //// выполнить запрос, получить выборку (коллекцию) для отобржаения
        //var clients = _controller.Query03(lo, hi);
        //
        //new ResultClientsWindow(clients).ShowDialog();
    } // Query03Exec

    // команда выполнения запроса 3
    public RelayCommand Query03Command => new(o => Query03Exec(), o => true);

    // 4. Запрос с параметром
    // Выбирает информацию об агентах с заданной фамилией
    private void Query04Exec()
    {

        //// получить параметр запроса из диалогового окна
        //var surnames = _controller.GetAllAgents()
        //    .Select(item => item.Surname)
        //    .Distinct()
        //    .ToArray();
        //
        //SurnameChoiceWindow dialog = new SurnameChoiceWindow(surnames);
        //
        //if (dialog.ShowDialog() != true)
        //{
        //    return;
        //} // if
        //
        //string surname = dialog.Surname;
        //
        //// выполнить запрос, получить выборку (коллекцию) для отобржаения
        //var agents = _controller.Query04(surname);
        //
        //new EmployeesWindow(agents).ShowDialog();
    } // Query04Exec

    // команда выполнения запроса 4
    public RelayCommand Query04Command => new(o => Query04Exec(), o => true);

    // 5. Запрос с параметром, итогами
    // Выбирает информацию о договорах заданного клиента.
    // Выводить также итоговую информацию: количество договоров, сумму договоров 
    private void Query05Exec()
    {

        // получить параметр запроса из диалогового окна
        //var fullNames = _controller.GetAllClients()
        //    .Select(item => item.FullName)
        //    .Distinct()
        //    .ToArray();
        //
        //PersonChoiceForm dialog = new PersonChoiceForm(fullNames);
        //
        //if (dialog.ShowDialog() != true)
        //{
        //    return;
        //} // if
        //
        //var client = _controller.GetAllClients().First(item => item.FullName == dialog.Person);
        //
        //// выполнить запрос, получить выборку (коллекцию) для отобржаения
        //var contracts = _controller.Query05(client);
        //
        //new ResultQuery05Window(contracts).ShowDialog();
    } // Query05Exec

    // команда выполнения запроса 5
    public RelayCommand Query05Command => new(o => Query05Exec(), o => true);

    // 6. Запрос с параметром, итогами
    // Выбирает информацию о договорах заданного агента.
    // Выводить также итоговую информацию: количество договоров, сумму договоров
    private void Query06Exec()
    {

        // получить параметр запроса из диалогового окна
        //var fullNames = _controller.GetAllAgents()
        //    .Select(item => item.FullName)
        //    .Distinct()
        //    .ToArray();
        //
        //PersonChoiceForm dialog = new PersonChoiceForm(fullNames);
        //
        //if (dialog.ShowDialog() != true)
        //{
        //    return;
        //} // if
        //
        //
        //var agent = _controller.GetAllAgents().First(item => item.FullName == dialog.Person);
        //
        //// выполнить запрос, получить выборку (коллекцию) для отображения
        //var contracts = _controller.Query06(agent);
        //
        //new ResultQuery06Window(contracts).ShowDialog();
    } // Query06Exec

    // команда выполнения запроса 6
    public RelayCommand Query06Command => new(o => Query06Exec(), o => true);

    // 7. Запрос с параметром, итогами
    // Выбирает информацию о договорах с заданным видом страхования.
    // Выводить также итоговую информацию: количество договоров, сумму договоров
    private void Query07Exec()
    {

        // получить параметр запроса из диалогового окна
        //var types = _controller.GetAllVisits()
        //    .Select(item => item.InsuranceType)
        //    .Distinct()
        //    .ToArray();
        //
        //InsuranceTypeChoiceWindow dialog = new InsuranceTypeChoiceWindow(types);
        //
        //if (dialog.ShowDialog() != true)
        //{
        //    return;
        //} // if
        //
        //
        //// выполнить запрос, получить выборку (коллекцию) для отображения
        //var contracts = _controller.Query07(dialog.InsuranceType);
        //
        //new ResultQuery07Window(contracts).ShowDialog();
    } // Query07Exec

    // команда выполнения запроса 7
    public RelayCommand Query07Command => new(o => Query07Exec(), o => true);

    // 8. Запрос на добавление
    // Добавление договора страхования. 
    private void Query08Exec()
    {
        //Visit Visit = new () 
        //{
        //    ClientId = _controller.GetAllClients()[Utils.GetRandom(0, _controller.GetAllClients().Count - 1)].Id,
        //    InsuranceAgentId = _controller.GetAllAgents()[Utils.GetRandom(0, _controller.GetAllAgents().Count - 1)].Id,
        //    InsuranceType = "Личное",
        //    InsurancePrice = Utils.GetRandom(1000, 200_000),
        //    Tariff = Utils.GetRandom(1, 15),
        //    ContractDate = DateTime.Now
        //};
        //
        //_controller.Query08(Visit);
        //
        //FillDataGrids();
    } // Query08Exec

    // команда выполнения запроса 8
    public RelayCommand Query08Command => new(o => Query08Exec(), o => true);

    // 9. Запрос на изменение
    // Редактирование договора страхования по идентификатору
    private void Query09Exec()
    {
        //_controller.Query09
        //(
        //    _controller
        //        .GetAllVisits()
        //        [Utils.GetRandom(0, _controller.GetAllVisits().Count - 1)]
        //        .Id
        //);
        //
        //FillDataGrids();
    }

    // команда выполнения запроса 9
    public RelayCommand Query09Command => new(o => Query09Exec(), o => true);

    // 10. Запрос на удаление
    // Удаление договора страхования по идентификатору
    private void Query10Exec()
    {
        //_controller.Query10
        //(
        //    _controller
        //        .GetAllVisits()
        //        [Utils.GetRandom(0, _controller.GetAllVisits().Count - 1)]
        //        .Id
        //);
        //
        //FillDataGrids();
    }

    // команда выполнения запроса 10
    public RelayCommand Query10Command => new(o => Query10Exec(), o => true);

} // class MainWindowViewModel
