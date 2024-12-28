using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class AddVisitWindowViewModel
{
    private ServiceStationController _controller;

    public VisitWindow HostWindow { get; set; }


    // команда выбора посещения
    public RelayCommand SelectCommand { get; set; }

    // команда отмены
    public RelayCommand CancelCommand { get; set; }


    public AddVisitWindowViewModel(VisitWindow hostWindow, ServiceStationController controller)
    {
        HostWindow = hostWindow;

        _controller = controller;

        SelectCommand = new(async void (o) => await SelectExec(o));

        CancelCommand = new(CancelExec);

    } // AddVisitWindowViewModel
}