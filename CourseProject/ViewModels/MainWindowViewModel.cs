﻿using System.Windows;
using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Views;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

// Команды приложения
public partial class MainWindowViewModel
{
    private ServiceStationController _controller;

    public MainWindow HostWindow { get; set; }

    public RelayCommand ExitCommand { get; set; }

    public RelayCommand EmployeesCommand { get; set; }

    public RelayCommand VisitCommand { get; set; }

    public RelayCommand AddColorCommand { get; set; }

    public RelayCommand AddBrandCommand { get; set; }

    public RelayCommand AddCarCommand { get; set; }

    public RelayCommand EditClientCommand { get; set; }

    public RelayCommand EditCarCommand { get; set; }

    public MainWindowViewModel(MainWindow hostWindow, ServiceStationController controller) {

        HostWindow = hostWindow;
        _controller = controller;

        ExitCommand = new(_ => Application.Current.Shutdown(0));

        EmployeesCommand = new(_ => new EmployeesWindow(_controller.GetAllEmployees()).ShowDialog());

        VisitCommand = new(_ => new VisitWindow(_controller.GetAllEmployees()).ShowDialog());

        AddColorCommand = new(AddColorExec);

        AddBrandCommand = new(AddBrandExec);

        AddCarCommand = new(AddCarExec);

        EditClientCommand = new(ShowClientExec);

        EditCarCommand = new(ShowCarExec);

        FillDataGrids();

    } // MainWindowViewModel

    public void FillDataGrids()
    {
        HostWindow.DgClients.ItemsSource = _controller.GetAllClients();
        HostWindow.DgCars.ItemsSource = _controller.GetAllCars();
        HostWindow.DgVisits.ItemsSource = _controller.GetAllVisits();
    }

} // class MainWindowViewModel
