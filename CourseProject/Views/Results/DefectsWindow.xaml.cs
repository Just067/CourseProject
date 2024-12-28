using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для DefectsWindow.xaml
/// </summary>
public partial class DefectsWindow : Window
{
    public DefectsWindow(List<Defect> defects)
    {
        InitializeComponent();

        LvDefects.ItemsSource = defects;
        LvDefects.SelectedIndex = 0;
    } // DefectsWindow

    public Defect Defect => (Defect)LvDefects.SelectedItem;

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