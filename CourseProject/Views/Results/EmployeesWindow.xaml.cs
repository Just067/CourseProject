using System.Windows;
using System.Windows.Input;
using CourseProject.Controllers;
using CourseProject.Models.Entities;
using CourseProject.ViewModels;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EmployeesWindow.xaml
/// </summary>
public partial class EmployeesWindow : Window
{
    private ServiceStationController _serviceStationController = new();
    public EmployeesWindow(List<Employee> employees)
    {
        InitializeComponent();
        DgEmployees.ItemsSource = employees;

        DataContext = new EmployeesWindowViewModel(this, _serviceStationController);
    } // EmployeesWindow

    private void EmployeesDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is EmployeesWindowViewModel viewModel)
        {
            viewModel.EditEmployeeCommand.Execute(this);
        }
    }
}