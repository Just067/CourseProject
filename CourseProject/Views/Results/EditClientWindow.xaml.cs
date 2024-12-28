using CourseProject.Controllers;
using CourseProject.Models.Entities;
using System.Windows;
using CourseProject.Infrastructure;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EditClientWindow.xaml
/// </summary>
public partial class EditClientWindow : Window
{
    private ServiceStationController _controller;

    private readonly Client _originalClient;
    private Client _clientCopy;

    public EditClientWindow(Client client, ServiceStationController controller)
    {
        InitializeComponent();

        _controller = controller;

        _originalClient = client;

        _clientCopy = new Client
        {
            Id = client.Id,
            Person = client.Person,
            BirthDate = client.BirthDate,
            Passport = client.Passport,
            PathPhoto = client.PathPhoto,
            Registration = client.Registration
        };

        DataContext = _clientCopy;

    } // EditClientWindow

    private void BtnSelect_Click(object sender, RoutedEventArgs e)
    {
        _originalClient.Passport = _clientCopy.Passport;
        _originalClient.Registration = _clientCopy.Registration;

        _controller.UpdateClient(_originalClient);

        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
        => Close();
}