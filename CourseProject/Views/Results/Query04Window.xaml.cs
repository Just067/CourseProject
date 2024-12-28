using System.Windows;
using CourseProject.Models.Queries;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для Query04Window.xaml
/// </summary>
public partial class Query04Window : Window
{
    public Query04Window(List<Query04> data)
    {
        InitializeComponent();
        LvQuery04.ItemsSource = data;
    }
}