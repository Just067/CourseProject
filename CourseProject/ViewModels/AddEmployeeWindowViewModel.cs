using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class AddEmployeeWindowViewModel
{

    private ServiceStationController _controller;

    public AddEmployeeWindow HostWindow { get; set; }

    // команда выбора ФИО
    public RelayCommand PersonCommand { get; set; }

    // команда выбора специальности
    public RelayCommand SpecializationCommand { get; set; }

    // команда выбора работника
    public RelayCommand SelectCommand { get; set; }

    // команда отмены
    public RelayCommand CancelCommand { get; set; }


    public AddEmployeeWindowViewModel(AddEmployeeWindow hostWindow, ServiceStationController controller)
    {
        HostWindow = hostWindow;

        _controller = controller;

        PersonCommand = new(PersonExec);

        SpecializationCommand = new(SpecializationExec);

        SelectCommand = new(async void (o) => await SelectExec(o));

        CancelCommand = new(CancelExec);

    } // AddEmployeeWindowViewModel
}