using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddColorWindow.xaml
/// </summary>
public partial class AddColorWindow : Window
{
    public AddColorWindow(List<Color> colors)
    {
        InitializeComponent();

        LvColors.ItemsSource = colors;

        TbxColor.Focus();

    } // AddColorWindow

    // вернуть выбранный цвет
    public string Color => TbxColor.Text;

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Color))
        {
            MessageBox.Show("Цвет не указан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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