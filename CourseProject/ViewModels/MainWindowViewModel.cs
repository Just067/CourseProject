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

    // команда открытия окна посещения
    public RelayCommand VisitCommand { get; set; }

    // команда добавления цвета автомобиля
    public RelayCommand AddColorCommand { get; set; }

    // команда добавления марки автомобиля
    public RelayCommand AddBrandCommand { get; set; }

    // команда открытия окна с добавлением автомобиля
    public RelayCommand AddCarCommand { get; set; }

    // команда редактирования клиента
    public RelayCommand EditClientCommand { get; set; }

    // команда редактирования автомобиля
    public RelayCommand EditCarCommand { get; set; }

    public MainWindowViewModel(MainWindow hostWindow, ServiceStationController controller) {

        HostWindow = hostWindow;
        _controller = controller;

        ExitCommand = new(_ => Application.Current.Shutdown(0));

        EmployeesCommand = new(_ => new EmployeesWindow(_controller.GetAllEmployees()).ShowDialog());

        VisitCommand = new(_ => new VisitWindow(_controller.GetAllEmployees()).ShowDialog());

        AddColorCommand = new(AddColorExec);

        AddBrandCommand = new(AddBrandExec);

        AddCarCommand = new(AddCarExec);

        EditClientCommand = new(ShowClientExec);

        EditCarCommand = new(ShowCarExec);

        FillDataGrids();

    } // MainWindowViewModel

    public void FillDataGrids()
    {
        HostWindow.DgClients.ItemsSource = _controller.GetAllClients();
        HostWindow.DgCars.ItemsSource = _controller.GetAllCars();
        HostWindow.DgVisits.ItemsSource = _controller.GetAllVisits();
    }

} // class MainWindowViewModel
