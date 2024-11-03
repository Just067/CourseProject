using System.Windows;
using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class AddCarWindowViewModel
{

    private ServiceStationController _controller;

    public AddCarWindow HostWindow { get; set; }

    // команда выбора цвета
    public RelayCommand ColorCommand { get; set; }

    // команда выбора владельца
    public RelayCommand OwnerCommand { get; set; }

    // команда выбора марки
    public RelayCommand BrandCommand { get; set; }

    // команда выбора автомобиля
    public RelayCommand SelectCommand { get; set; }

    // команда отмены
    public RelayCommand CancelCommand { get; set; }


    public AddCarWindowViewModel(AddCarWindow hostWindow, ServiceStationController controller)
    {
        HostWindow = hostWindow;

        _controller = controller;

        ColorCommand = new(ColorExec);

        OwnerCommand = new(OwnerExec);

        BrandCommand = new(BrandExec);

        SelectCommand = new(SelectExec);

        CancelCommand = new(CancelExec);

    } // AddCarWindowViewModel

}