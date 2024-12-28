using CourseProject.Controllers;
using CourseProject.ViewModels;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddClientWindow.xaml
/// </summary>
public partial class AddClientWindow : Window
{
    private ServiceStationController _serviceStationController = new();
    public AddClientWindow()
    {
        InitializeComponent();

        DataContext = new AddClientWindowViewModel(this, _serviceStationController);
    }
}