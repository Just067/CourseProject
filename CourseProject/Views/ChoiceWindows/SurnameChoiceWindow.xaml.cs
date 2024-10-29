using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для SurnameChoiceWindow.xaml
/// </summary>
public partial class SurnameChoiceWindow : Window
{

    public SurnameChoiceWindow(string[] surnames)
    {
        InitializeComponent();

        CbxSurname.ItemsSource = surnames;

        CbxSurname.Text = CbxSurname.Items[0].ToString();
    } // SurnameChoiceWindow

    // вернуть выбранную фамилию
    public string Surname => CbxSurname.Text;

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