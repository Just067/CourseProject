using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultClientsWindow.xaml
/// </summary>
public partial class ResultClientsWindow : Window
{
    public ResultClientsWindow(List<Client> clients)
    {
        InitializeComponent();

        DgClients.ItemsSource = clients;
    } // ResultClientsWindow

}