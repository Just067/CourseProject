using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class AddClientWindowViewModel
{

    private ServiceStationController _controller;

    public AddClientWindow HostWindow { get; set; }

    // команда выбора ФИО
    public RelayCommand PersonCommand { get; set; }

    // команда выбора работника
    public RelayCommand SelectCommand { get; set; }

    // команда отмены
    public RelayCommand CancelCommand { get; set; }


    public AddClientWindowViewModel(AddClientWindow hostWindow, ServiceStationController controller)
    {
        HostWindow = hostWindow;

        _controller = controller;

        PersonCommand = new(PersonExec);

        SelectCommand = new(async void (o) => await SelectExec(o));

        CancelCommand = new(CancelExec);

    } // AddEmployeeWindowViewModel
}