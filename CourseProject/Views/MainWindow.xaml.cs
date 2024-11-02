using System.Windows;
using CourseProject.Controllers;
using CourseProject.ViewModels;

namespace CourseProject.Views;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private ServiceStationController _serviceStationController = new();

    public MainWindow()
    {
        InitializeComponent();

        DataContext = new MainWindowViewModel(this, _serviceStationController);
    }

}