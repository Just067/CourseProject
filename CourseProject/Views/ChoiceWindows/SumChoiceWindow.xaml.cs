using System.Windows;

namespace CourseProject.Views.ChoiceWindows;

/// <summary>
/// Логика взаимодействия для SumChoiceWindow.xaml
/// </summary>
public partial class SumChoiceWindow : Window
{

    public SumChoiceWindow(string[] prices)
    {
        InitializeComponent();

        CbxLo.ItemsSource = CbxHi.ItemsSource = prices;

        CbxLo.Text = CbxHi.Text = CbxLo.Items[0].ToString();

    } // SumChoiceWindow

    public string Lo => CbxLo.Text;

    public string Hi => CbxHi.Text;

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