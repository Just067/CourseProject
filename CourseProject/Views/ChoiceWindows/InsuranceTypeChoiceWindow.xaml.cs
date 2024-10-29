using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для InsuranceTypeChoiceWindow.xaml
/// </summary>
public partial class InsuranceTypeChoiceWindow : Window
{
    public InsuranceTypeChoiceWindow(string[] passports)
    {
        InitializeComponent();

        CbxInsuranceType.ItemsSource = passports;
        CbxInsuranceType.Text = CbxInsuranceType.Items[0].ToString();
    } // InsuranceTypeChoiceWindow

    // вернуть выбранный вид
    public string InsuranceType => CbxInsuranceType.Text;

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