using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для PassportChoiceWindow.xaml
/// </summary>
public partial class PassportChoiceWindow : Window
{
    public PassportChoiceWindow(string[] passports)
    {
        InitializeComponent();

        CbxPassport.ItemsSource = passports;
        CbxPassport.Text = CbxPassport.Items[0].ToString();
    } // PassportChoiceWindow

    // вернуть выбранного мастера
    public string Passport => CbxPassport.Text;

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