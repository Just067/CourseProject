using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddSpecializationWindow.xaml
/// </summary>
public partial class AddSpecializationWindow : Window
{
    public AddSpecializationWindow(List<Specialization> specializations)
    {
        InitializeComponent();

        LvSpecializations.ItemsSource = specializations;

        TbxSpecialization.Focus();

    } // AddSpecializationWindow

    // вернуть выбранную специальность
    public string Specialization => TbxSpecialization.Text;

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Specialization))
        {
            MessageBox.Show("Специальность не указана!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        DialogResult = true;
        Close();

    } // BtnSelect_Click

    private void BtnCancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    } //BtnCancel_Click
}