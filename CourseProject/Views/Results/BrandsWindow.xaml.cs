using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для BrandsWindow.xaml
/// </summary>
public partial class BrandsWindow : Window
{
    public BrandsWindow(List<Brand> brands)
    {
        InitializeComponent();

        LvBrands.ItemsSource = brands;
        LvBrands.SelectedIndex = 0;
    } // BrandsWindow

    public Brand Brand => (Brand)LvBrands.SelectedItems[0]!;

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