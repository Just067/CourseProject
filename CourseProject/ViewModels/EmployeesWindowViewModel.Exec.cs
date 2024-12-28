using CourseProject.Models.Entities;
using CourseProject.Views.Results;
using System.Windows;

namespace CourseProject.ViewModels;

public partial class EmployeesWindowViewModel
{
    // добавление новой специальности
    private async Task AddSpecializationExec(object o)
    {
        var dictionary = _controller.GetAllSpecializations()
            .ToDictionary(c => c.Name);

        AddSpecializationWindow dialog = new(_controller.GetAllSpecializations());

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string specialization = dialog.Specialization.ToLower();

        if (!dictionary.ContainsKey(specialization))
        {
            await _controller.AddSpecialization(new Specialization { Name = specialization });

            MessageBox.Show($"Специальность '{specialization}' успешно добавлена.");

        }
        else
        {
            MessageBox.Show($"Специальность '{specialization}' уже существует.");
        }
    }

    // открытие окна работника
    private void ShowEmployeeExec(object o)
    {
        var employee = (Employee)HostWindow.DgEmployees.SelectedItem;

        if (employee == null) return;

        var prefix = "/Assets/People/";
        employee.PathPhoto = (employee.PathPhoto.StartsWith(prefix) ? "" : prefix) + employee.PathPhoto;
        var win = new EditEmployeeWindow(employee, _controller);

        win.ShowDialog();

        FillDataGrid();
    } // ShowEmployeeExec

    // удаление работника и связанных с ним посещений
    private void DeleteEmployeeExec(object o)
    {
        var employee = (Employee)HostWindow.DgEmployees.SelectedItem;

        if (employee == null) return;

        _controller
            .GetAllVisits()
            .Where(v => v.EmployeeId == employee.Id)
            .ToList().ForEach(visit => _controller.DeleteVisit(visit));

        _controller.DeleteEmployee(employee);
        FillDataGrid();
    } // DeleteEmployeeExec


    // добавление работника
    private void AddEmployeeExec(object o)
    {
        AddEmployeeWindow dialog = new();

        if (dialog.ShowDialog() == false)
        {
            return;
        }

        FillDataGrid();
    }
}