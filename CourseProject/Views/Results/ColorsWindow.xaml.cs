using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для ColorsWindow.xaml
/// </summary>
public partial class ColorsWindow : Window
{
    public ColorsWindow(List<Color> colors)
    {
        InitializeComponent();

        LvColors.ItemsSource = null;
        LvColors.ItemsSource = colors;
        LvColors.SelectedIndex = 0;
    } // ColorsWindow

    public Color Color => (Color)LvColors.SelectedItem;

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