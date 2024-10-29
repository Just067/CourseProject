using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для PersonChoiceForm.xaml
/// </summary>
public partial class PersonChoiceForm : Window
{
    public PersonChoiceForm(string[] people)
    {
        InitializeComponent();

        CbxPerson.ItemsSource = people;
        CbxPerson.Text = CbxPerson.Items[0].ToString();
    } // PersonChoiceForm

    // вернуть выбранного человека
    public string Person => CbxPerson.Text;

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