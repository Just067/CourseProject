using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для SpecializationsWindow.xaml
/// </summary>
public partial class SpecializationsWindow : Window
{
    public SpecializationsWindow(List<Specialization> specializations)
    {
        InitializeComponent();

        LvSpecializations.ItemsSource = specializations;
        LvSpecializations.SelectedIndex = 0;
    } // SpecializationsWindow

    public Specialization Specialization => (Specialization)LvSpecializations.SelectedItems[0]!;

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