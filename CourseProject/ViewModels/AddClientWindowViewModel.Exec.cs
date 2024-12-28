using CourseProject.Infrastructure.Factories;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;
using System.Windows;

namespace CourseProject.ViewModels;

public partial class AddClientWindowViewModel
{
    // выбор ФИО клиента
    private void PersonExec(object o)
    {
        // передача данных в форму
        var personWindow = new PeopleWindow(_controller.GetAllPeople().Where(p => p.Client == null).ToList());

        // показать диалоговое окно, выход если диалог вернул не ОК
        if (personWindow.ShowDialog() == false)
        {
            return;
        } // if

        var person = personWindow.Person;

        HostWindow.TxbPerson.Text = person.FullName;
    }

    // добавление клиента
    private async Task SelectExec(object o)
    {
        // Проверка всех полей
        if (string.IsNullOrWhiteSpace(HostWindow.TxbPassport.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbRegistration.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbPerson.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.DpBirthDate.Text))
        {
            MessageBox.Show(
                "Пожалуйста, заполните все поля!",
                "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Warning);

            return;
        }

        var personId = _controller.GetAllPeople().First(b => b.FullName == HostWindow.TxbPerson.Text).Id;

        Client client = new()
        {
            PersonId = personId,
            BirthDate = HostWindow.DpBirthDate.DisplayDate,
            Passport = HostWindow.TxbPassport.Text,
            Registration = HostWindow.TxbRegistration.Text,
            PathPhoto = Factory.GetRandomPersonImage()
        };

        await _controller.AddClient(client);

        HostWindow.DialogResult = true;
        HostWindow.Close();

    }

    // отмена
    private void CancelExec(object o)
    {
        HostWindow.DialogResult = false;
        HostWindow.Close();
    }
}