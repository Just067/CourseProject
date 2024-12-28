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
    private ServiceStationController _serviceStationController = new();

    public VisitWindow(List<Employee> employees, List<Car> cars, List<Client> clients)
    {
        InitializeComponent();

        (DgEmployees.ItemsSource, DgCars.ItemsSource, DgClients.ItemsSource, CxbService.ItemsSource) = 
            (employees, cars, clients, _serviceStationController.GetAllServices().Select(service => service.Name).ToList());

        DgEmployees.SelectedIndex = DgClients.SelectedIndex = DgCars.SelectedIndex = CxbService.SelectedIndex = 0;

        DataContext = new AddVisitWindowViewModel(this, _serviceStationController);
    }

}