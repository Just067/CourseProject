using CourseProject.Controllers;
using CourseProject.Models.Entities;
using CourseProject.ViewModels;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для VisitWindow.xaml
/// </summary>
public partial class VisitWindow : Window
{
    public VisitWindow(List<Employee> employees)
    {
        InitializeComponent();

        DgEmployees.ItemsSource = employees;
    }
}