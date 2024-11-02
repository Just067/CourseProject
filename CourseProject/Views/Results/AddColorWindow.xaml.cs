using System.Windows;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для AddColorWindow.xaml
/// </summary>
public partial class AddColorWindow : Window
{
    public AddColorWindow()
    {
        InitializeComponent();

    } // AddColorWindow

    // вернуть выбранный цвет
    public string Color => TbxColor.Text;

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