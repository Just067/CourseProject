using System.Windows;
using CourseProject.Models.Entities;

namespace CourseProject.Views.Results;

/// <summary>
/// Логика взаимодействия для PeopleWindow.xaml
/// </summary>
public partial class PeopleWindow : Window
{
    public PeopleWindow(List<Person> people)
    {
        InitializeComponent();

        DgPeople.ItemsSource = people;
        DgPeople.SelectedIndex = 0;
    } // PeopleWindow

    public Person Person => (Person)DgPeople.SelectedItems[0]!;

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