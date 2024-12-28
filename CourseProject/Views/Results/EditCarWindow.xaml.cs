using CourseProject.Controllers;
using CourseProject.Models.Entities;
using System.Windows;
using CourseProject.Infrastructure;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EditCarWindow.xaml
/// </summary>
public partial class EditCarWindow : Window
{
    private ServiceStationController _controller;

    private readonly Car _originalCar;
    private Car _carCopy;
    public EditCarWindow(Car car, ServiceStationController controller)
    {
        InitializeComponent();

        _controller = controller;

        _originalCar = car;

        _carCopy = new Car
        {
            Id = car.Id,
            Owner = car.Owner,
            PathPhoto = car.PathPhoto,
            Brand = car.Brand,
            Color = car.Color,
            ReleaseYear = car.ReleaseYear,
            StateNumber = car.StateNumber
        };

        DataContext = _carCopy;

    } // EditCarWindow

    private void BtnSelect_Click(object sender, RoutedEventArgs e)
    {
        _originalCar.StateNumber = _carCopy.StateNumber;

        _controller.UpdateCar(_originalCar);

        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
        => Close();
}