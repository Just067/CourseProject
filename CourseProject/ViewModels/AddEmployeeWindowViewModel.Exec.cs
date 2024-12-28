using CourseProject.Infrastructure.Factories;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;
using System.Windows;

namespace CourseProject.ViewModels;

public partial class AddEmployeeWindowViewModel
{
    // выбор ФИО работника
    private void PersonExec(object o)
    {
        // передача данных в форму
        var personWindow = new PeopleWindow(_controller.GetAllPeople());

        // показать диалоговое окно, выход если диалог вернул не ОК
        if (personWindow.ShowDialog() == false)
        {
            return;
        } // if

        var person = personWindow.Person;

        HostWindow.TxbPerson.Text = person.FullName;
    }

    // выбор специальности работника
    private void SpecializationExec(object o)
    {
        // передача данных в форму
        var specializationWindow = new SpecializationsWindow(_controller.GetAllSpecializations());

        // показать диалоговое окно, выход если диалог вернул не ОК
        if (specializationWindow.ShowDialog() == false)
        {
            return;
        } // if

        var specialization = specializationWindow.Specialization;

        HostWindow.TxbSpecialization.Text = specialization.Name;
    }

    // добавление работника
    private async Task SelectExec(object o)
    {
        // Проверка всех полей
        if (string.IsNullOrWhiteSpace(HostWindow.TxbCategory.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbExperience.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbPerson.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbSpecialization.Text))
        {
            MessageBox.Show(
                "Пожалуйста, заполните все поля!",
                "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Warning);

            return;
        }

        var personId = _controller.GetAllPeople().First(b => b.FullName == HostWindow.TxbPerson.Text).Id;

        var specializationId = _controller
            .GetAllSpecializations()
            .First(c => c.Name == HostWindow.TxbSpecialization.Text).Id;

        Employee employee = new()
        {
            SpecializationId = specializationId,
            PersonId = personId,
            Category = Convert.ToInt32(HostWindow.TxbCategory.Text),
            Experience = Convert.ToInt32(HostWindow.TxbExperience.Text),
            PathPhoto = Factory.GetRandomPersonImage(),
            IsEmployed = false
        };

        await _controller.AddEmployee(employee);

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