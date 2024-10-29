using System.Windows;
using CourseProject.Models.Queries;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultQuery07Window.xaml
/// </summary>
public partial class ResultQuery07Window : Window
{
    public ResultQuery07Window(List<Query07> items)
    {
        InitializeComponent();

        DgQuery07.ItemsSource = items;
    } // ResultQuery07Window
}