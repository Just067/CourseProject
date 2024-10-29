using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultAgentsWindow.xaml
/// </summary>
public partial class ResultAgentsWindow : Window
{
    public ResultAgentsWindow(List<Employee> agents)
    {
        InitializeComponent();

        DgAgents.ItemsSource = agents;
    } // ResultAgentsWindow
}