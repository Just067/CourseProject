using CourseProject.Controllers;
using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EditEmployeeWindow.xaml
/// </summary>
public partial class EditEmployeeWindow : Window
{
    private ServiceStationController _controller;

    private readonly Employee _originalEmployee;
    private Employee _employeeCopy;

    public EditEmployeeWindow(Employee employee, ServiceStationController controller)
    {
        InitializeComponent();

        _controller = controller;

        _originalEmployee = employee;

        _employeeCopy = new Employee
        {
            Id = _originalEmployee.Id,
            Person = _originalEmployee.Person,
            Category = _originalEmployee.Category,
            Experience = _originalEmployee.Experience,
            Specialization = _originalEmployee.Specialization,
            PathPhoto = _originalEmployee.PathPhoto,
            IsEmployed = _originalEmployee.IsEmployed
        };

        DataContext = _employeeCopy;

    } // EditClientWindow

    private void BtnSelect_Click(object sender, RoutedEventArgs e)
    {

        _originalEmployee.Category = _employeeCopy.Category;
        _originalEmployee.Experience = _employeeCopy.Experience;

        _controller.UpdateEmployee(_originalEmployee);

        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
        => Close();
}