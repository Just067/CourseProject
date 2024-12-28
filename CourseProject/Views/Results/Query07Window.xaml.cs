using System.Windows;
using CourseProject.Models.Queries;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для Query07Window.xaml
/// </summary>
public partial class Query07Window : Window
{
    public Query07Window(List<Query07> data)
    {
        InitializeComponent();

        LvQuery07.ItemsSource = data;
    }
}