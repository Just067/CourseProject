using CourseProject.Infrastructure.Factories;
using CourseProject.Views.Results;
using CourseProject.Models.Entities;
using System.Windows;

namespace CourseProject.ViewModels;

public partial class AddCarWindowViewModel
{
    // выбор цвета автомобиля
    private void ColorExec(object o)
    {
        // передача данных в форму
        var colorForm = new ColorsWindow(_controller.GetAllColors());

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (colorForm.ShowDialog() == false)
        {
            return;
        } // if

        var color = colorForm.Color;

        HostWindow.TxbColor.Text = color.Name;
    }

    // выбор владельца автомобиля
    private void OwnerExec(object o)
    {
        // передача данных в форму
        var ownerWindow = new PeopleWindow(_controller.GetAllPeople());

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (ownerWindow.ShowDialog() == false)
        {
            return;
        } // if

        var person = ownerWindow.Person;

        HostWindow.TxbOwner.Text = person.FullName;
    }

    // выбор марки автомобиля
    private void BrandExec(object o)
    {
        // передача данных в форму
        var brandWindow = new BrandsWindow(_controller.GetAllBrands());

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (brandWindow.ShowDialog() == false)
        {
            return;
        } // if

        var brand = brandWindow.Brand;

        HostWindow.TxbBrand.Text = brand.Name;
    }

    // добавление автомобиля
    private async Task SelectExec(object o)
    {
        // Проверка всех полей
        if (string.IsNullOrWhiteSpace(HostWindow.TxbBrand.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbColor.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbOwner.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbReleaseYear.Text) ||
            string.IsNullOrWhiteSpace(HostWindow.TxbStateNumber.Text))
        {
            MessageBox.Show(
                "Пожалуйста, заполните все поля!", 
                "Ошибка", MessageBoxButton.OK, 
                MessageBoxImage.Warning);

            return;
        }


        // Получение ID значений
        var brandId = _controller.GetAllBrands().First(b => b.Name == HostWindow.TxbBrand.Text).Id;
        var colorId = _controller.GetAllColors().First(c => c.Name == HostWindow.TxbColor.Text).Id;
        var ownerId = _controller.GetAllPeople().First(p => p.FullName == HostWindow.TxbOwner.Text).Id;

        // Создание объекта автомобиля
        Car car = new()
        {
            BrandId = brandId,
            ColorId = colorId,
            OwnerId = ownerId,
            ReleaseYear = Convert.ToInt32(HostWindow.TxbReleaseYear.Text),
            StateNumber = HostWindow.TxbStateNumber.Text,
            PathPhoto = Factory.GetRandomCarPhoto()
        };

        // Добавление автомобиля
        await _controller.AddCar(car);

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