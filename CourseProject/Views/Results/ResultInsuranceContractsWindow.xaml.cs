using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ResultVisitsWindow.xaml
/// </summary>
public partial class ResultVisitsWindow : Window
{
    public ResultVisitsWindow(List<Visit> contracts)
    {
        InitializeComponent();

        DgVisits.ItemsSource = contracts;
    } // ResultVisitsWindow
}