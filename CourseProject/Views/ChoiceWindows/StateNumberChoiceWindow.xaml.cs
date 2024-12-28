using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для StateNumberChoiceWindow.xaml
/// </summary>
public partial class StateNumberChoiceWindow : Window
{
    public StateNumberChoiceWindow()
    {
        InitializeComponent();

    } // StateNumberChoiceWindow

    public string StateNumber => TbxStateNumber.Text;

    private void BtnSelect_Click(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(StateNumber))
        {
            MessageBox.Show("Номер не указан!", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
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