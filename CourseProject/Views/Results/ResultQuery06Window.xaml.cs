using System.Windows;
using CourseProject.Models.Queries;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultQuery06Window.xaml
/// </summary>
public partial class ResultQuery06Window : Window
{
    public ResultQuery06Window(List<Query06> items)
    {
        InitializeComponent();

        DgQuery06.ItemsSource = items;
    } // ResultQuery06Window
}