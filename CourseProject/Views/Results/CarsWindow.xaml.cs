using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для CarsWindow.xaml
/// </summary>
public partial class CarsWindow : Window
{
    public CarsWindow(List<Car> cars)
    {
        InitializeComponent();

        LvCars.ItemsSource = cars;
    }
}