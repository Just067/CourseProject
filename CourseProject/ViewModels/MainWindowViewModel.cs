using System.Windows;
using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

// Команды приложения
public partial class MainWindowViewModel
{
    private ServiceStationController _controller;

    public MainWindow HostWindow { get; set; }

    // команда завершения работы приложения
    public RelayCommand ExitCommand { get; set; }

    // команда открытия окна с работниками
    public RelayCommand EmployeesCommand { get; set; }

    // команда открытия окна добавления посещения
    public RelayCommand AddVisitCommand { get; set; }


    // команда добавления цвета автомобиля
    public RelayCommand AddColorCommand { get; set; }

    // команда добавления марки автомобиля
    public RelayCommand AddBrandCommand { get; set; }

    // команда открытия окна с добавлением автомобиля
    public RelayCommand AddCarCommand { get; set; }

    // команда открытия окна с добавлением клиента
    public RelayCommand AddClientCommand { get; set; }

    // команда редактирования клиента
    public RelayCommand EditClientCommand { get; set; }

    // команда редактирования автомобиля
    public RelayCommand EditCarCommand { get; set; }

    // команда запроса Фамилия, имя, отчество и адрес владельца автомобиля
    // с данным номером государственной регистрации
    public RelayCommand Query01Command { get; set; }

    // команда запроса Марка и год выпуска автомобиля данного владельца
    public RelayCommand Query02Command { get; set; }

    // команда запроса Перечень устраненных неисправностей в автомобиле данного владельца
    public RelayCommand Query03Command { get; set; }

    // команда запроса Фамилия, имя, отчество работника станции, устранявшего данную неисправность
    // в автомобиле данного клиента, и время ее устранения
    public RelayCommand Query04Command { get; set; }

    // команда запроса Фамилия, имя, отчество клиентов, сдавших в ремонт автомобили с указанным
    // типом неисправности
    public RelayCommand Query05Command { get; set; }

    // команда запроса Самая распространенная неисправность в автомобилях указанной марки
    public RelayCommand Query06Command { get; set; }

    // команда запроса Количество рабочих каждой специальности на станции
    public RelayCommand Query07Command { get; set; }

    // сохранить справку о количестве автомобилей в ремонте
    public RelayCommand SaveCarsInRepairReport { get; set; }

    // сохранить справку о количестве незанятых работниках
    public RelayCommand SaveFreeWorkersReport { get; set; }

    // сохранить месячный отсчет
    public RelayCommand SaveMonthReport { get; set; }

    public MainWindowViewModel(MainWindow hostWindow, ServiceStationController controller) {

        HostWindow = hostWindow;
        _controller = controller;

        ExitCommand = new(_ => Application.Current.Shutdown(0));

        EmployeesCommand = new(_ => new EmployeesWindow(_controller.GetAllEmployees()).ShowDialog());

        AddVisitCommand = new(AddVisitExec);

        AddColorCommand = new(async void (o) => await AddColorExec(o));

        AddBrandCommand = new(async void (o) => await AddBrandExec(o));

        AddCarCommand = new(AddCarExec);

        AddClientCommand = new(AddClientExec);

        EditClientCommand = new(ShowClientExec);

        EditCarCommand = new(ShowCarExec);

        Query01Command = new(async void (o) => await Query01Exec(o));

        Query02Command = new(async void (o) => await Query02Exec(o));

        Query03Command = new(async void (o) => await Query03Exec(o));

        Query04Command = new(async void (o) => await Query04Exec(o));

        Query05Command = new(async void (o) => await Query05Exec(o));

        Query06Command = new(async void (o) => await Query06Exec(o));

        Query07Command = new(async void (o) => await Query07Exec(o));

        SaveCarsInRepairReport = new(async void (o) => await _controller.SaveCarsInRepairWithDialog(o));

        SaveFreeWorkersReport = new(async void (o) => await _controller.SaveFreeWorkersWithDialog(o));

        SaveMonthReport = new(async void (o) => await _controller.SaveMonthReportWithDialog(o));

        FillDataGrids();

    } // MainWindowViewModel

    public void FillDataGrids()
    {
        HostWindow.DgClients.ItemsSource = _controller.GetAllClients();
        HostWindow.DgCars.ItemsSource = _controller.GetAllCars();
        HostWindow.DgVisits.ItemsSource = _controller.GetAllVisits();
    }

} // class MainWindowViewModel
