using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ClientsWindow.xaml
/// </summary>
public partial class ClientsWindow : Window
{
    public ClientsWindow(List<Client> clients)
    {
        InitializeComponent();

        LvClients.ItemsSource = clients;
        LvClients.SelectedIndex = 0;
    }

    public Client Client => (Client)LvClients.SelectedItem;

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        DialogResult = true;
        Close();

    } // BtnSelect_Click

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    } //BtnCancel_Click
}