using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EmployeesWindow.xaml
/// </summary>
public partial class EmployeesWindow : Window
{
    public EmployeesWindow(List<Employee> employees)
    {
        InitializeComponent();

        DgEmployees.ItemsSource = employees;
    } // EmployeesWindow
}