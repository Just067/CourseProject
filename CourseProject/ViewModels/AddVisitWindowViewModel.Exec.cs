using CourseProject.Infrastructure.Factories;
using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.ViewModels;

public partial class AddVisitWindowViewModel
{
    // добавление посещения
    private async Task SelectExec(object o)
    {
        // Проверка всех полей
        if (string.IsNullOrWhiteSpace(HostWindow.TxbDefect.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.DtpApplication.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.DtpApplication.Text))
        {
            MessageBox.Show(
                "Пожалуйста, заполните все поля!",
                "Ошибка", MessageBoxButton.OK,
                MessageBoxImage.Warning);

            return;
        }


        // Получение ID значений
        var selectedCar = (Car)HostWindow.DgCars.SelectedItem;
        var selectedClient = (Client)HostWindow.DgClients.SelectedItem;
        var selectedEmployee = (Employee)HostWindow.DgEmployees.SelectedItem;

        var carId = _controller.GetAllCars().First(c => c.Id == selectedCar.Id).Id;
        var clientId = _controller.GetAllClients().First(c => c.Id == selectedClient.Id).Id;
        var employeeId = _controller.GetAllEmployees().First(e => e.Id == selectedEmployee.Id).Id;
        var serviceId = _controller.GetAllServices().First(s => s.Name == (string)HostWindow.CxbService.SelectedItem).Id;

        var defectName = HostWindow.TxbDefect.Text;

        var defect = _controller.GetAllDefects().FirstOrDefault(d => d.Name.Equals(defectName, StringComparison.OrdinalIgnoreCase));

        if (defect == null)
        {
            // Если неисправность не найдена, добавить новую
            defect = new Defect { Name = defectName };
            await _controller.AddDefect(defect);
        }

        // Создание объекта посещения
        Visit visit = new()
        {
            CarId = carId,
            ClientId = clientId,
            EmployeeId = employeeId,
            DefectId = defect.Id,
            ServiceId = serviceId,
            DateOfApplication = HostWindow.DtpApplication.SelectedDate!.Value,
            DateOfIssue = HostWindow.DtpIssue.SelectedDate!.Value,
            IsPaid = HostWindow.ChxIsPaid.IsChecked ?? false
        };

        // Добавление посещения
        await _controller.AddVisit(visit);

        // Закрытие окна
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