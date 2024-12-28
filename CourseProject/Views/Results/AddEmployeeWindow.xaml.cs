using CourseProject.Controllers;
using CourseProject.ViewModels;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddEmployeeWindow.xaml
/// </summary>
public partial class AddEmployeeWindow : Window
{
    private ServiceStationController _serviceStationController = new();
    public AddEmployeeWindow()
    {
        InitializeComponent();

        DataContext = new AddEmployeeWindowViewModel(this, _serviceStationController);
    }
}