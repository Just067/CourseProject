using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class EmployeesWindowViewModel
{
    private ServiceStationController _controller;

    public EmployeesWindow HostWindow { get; set; }

    // команда завершения работы приложения
    public RelayCommand ExitCommand { get; set; }

    // команда добавления специальности
    public RelayCommand AddSpecializationCommand { get; set; }

    // команда открытия окна с добавлением работника
    public RelayCommand AddEmployeeCommand { get; set; }

    // команда редактирования работника
    public RelayCommand EditEmployeeCommand { get; set; }

    // команда удаления работника
    public RelayCommand DeleteEmployeeCommand { get; set; }

    public EmployeesWindowViewModel(EmployeesWindow hostWindow, ServiceStationController controller)
    {

        HostWindow = hostWindow;
        _controller = controller;

        ExitCommand = new(_ => hostWindow.Close());

        AddEmployeeCommand = new(AddEmployeeExec);

        AddSpecializationCommand = new(async void (o) => await AddSpecializationExec(o));

        EditEmployeeCommand = new(ShowEmployeeExec);

        DeleteEmployeeCommand = new(DeleteEmployeeExec);

        FillDataGrid();

    } // EmployeesWindowViewModel

    public void FillDataGrid() =>
        HostWindow.DgEmployees.ItemsSource = _controller.GetAllEmployees();
}