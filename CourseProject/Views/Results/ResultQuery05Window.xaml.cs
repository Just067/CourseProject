using System.Windows;
using CourseProject.Models.Queries;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultQuery05Window.xaml
/// </summary>
public partial class ResultQuery05Window : Window
{
    public ResultQuery05Window(List<Query05> items)
    {
        InitializeComponent();

        DgQuery05.ItemsSource = items;
    } // ResultQuery05Window
}