using CourseProject.Controllers;
using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EditCarWindow.xaml
/// </summary>
public partial class EditCarWindow : Window
{
    private ServiceStationController _controller;

    private Car _car;
    public EditCarWindow(Car car, ServiceStationController controller)
    {
        InitializeComponent();

        _controller = controller;

        _car = car;

        DataContext = _car;

    } // EditCarWindow

    private void BtnSelect_Click(object sender, RoutedEventArgs e)
    {
        var car = _controller.GetAllCars().FirstOrDefault(item => item.Id == _car.Id);
        if (car == null) return;

        _controller.UpdateCar(car);

        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
        => Close();
}