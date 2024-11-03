using CourseProject.Controllers;
using CourseProject.ViewModels;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddCarWindow.xaml
/// </summary>
public partial class AddCarWindow : Window
{
    private ServiceStationController _serviceStationController = new();
    public AddCarWindow()
    {
        InitializeComponent();

        DataContext = new AddCarWindowViewModel(this, _serviceStationController);
    }
}