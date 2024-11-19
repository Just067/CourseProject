using System.Windows;
using System.Windows.Input;
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


    private void ClientsDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.EditClientCommand.Execute(this);
        }
    }

    private void CarsDoubleClick(object sender, MouseButtonEventArgs e)
    {
        if (DataContext is MainWindowViewModel viewModel)
        {
            viewModel.EditCarCommand.Execute(this);
        }
    }
}