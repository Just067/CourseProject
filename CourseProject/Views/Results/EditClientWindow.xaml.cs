using CourseProject.Controllers;
using CourseProject.Infrastructure;
using CourseProject.Models.Entities;
using System.Windows;
using System.Windows.Controls;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для EditClientWindow.xaml
/// </summary>
public partial class EditClientWindow : Window
{
    private ServiceStationController _controller;

    private Client _client;
    public EditClientWindow(Client client, ServiceStationController controller)
    {
        InitializeComponent();

        _controller = controller;

        _client = client;

        DataContext = _client;

    } // EditClientWindow

    private void BtnSelect_Click(object sender, RoutedEventArgs e)
    {
        var client = _controller.GetAllClients().FirstOrDefault(item => item.Id == _client.Id);
        if (client == null) return;

        _controller.UpdateClient(client);

        Close();
    }

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
        => Close();
}