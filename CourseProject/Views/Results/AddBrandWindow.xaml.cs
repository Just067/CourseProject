using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddBrandWindow.xaml
/// </summary>
public partial class AddBrandWindow : Window
{
    public AddBrandWindow(List<Brand> brands)
    {
        InitializeComponent();

        LvBrands.ItemsSource = brands;

        TbxBrand.Focus();

    } // AddBrandWindow

    // вернуть выбранную марку
    public string Brand => TbxBrand.Text;

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Brand))
        {
            MessageBox.Show("Марка не указана!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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