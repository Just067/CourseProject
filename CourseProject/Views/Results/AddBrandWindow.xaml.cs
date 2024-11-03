using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddBrandWindow.xaml
/// </summary>
public partial class AddBrandWindow : Window
{
    public AddBrandWindow()
    {
        InitializeComponent();

        TbxBrand.Focus();

    } // AddBrandWindow

    // вернуть выбранную марку
    public string Brand => TbxBrand.Text;

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