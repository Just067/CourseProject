using CourseProject.Views.Results;
using CourseProject.Models.Entities;

namespace CourseProject.ViewModels;

public partial class AddCarWindowViewModel
{
    // выбор цвета
    private void ColorExec(object o)
    {
        var colors = _controller.GetAllColors();

        // передача данных в форму
        var colorForm = new ColorsWindow(colors);

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (colorForm.ShowDialog() == false)
        {
            return;
        } // if

        var color = colorForm.Color;

        HostWindow.TxbColor.Text = color.Name;
    }

    // выбор владельца авто
    private void OwnerExec(object o)
    {
        var owners = _controller.GetAllPeople();

        // передача данных в форму
        var ownerWindow = new PeopleWindow(owners);

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (ownerWindow.ShowDialog() == false)
        {
            return;
        } // if

        var person = ownerWindow.Person;

        HostWindow.TxbOwner.Text = person.FullName;
    }

    private void BrandExec(object o)
    {
        var brands = _controller.GetAllBrands();

        // передача данных в форму
        var brandWindow = new BrandsWindow(brands);

        // показать диалоговое окно редактирования, выход если диалог вернул не ОК
        if (brandWindow.ShowDialog() == false)
        {
            return;
        } // if

        var brand = brandWindow.Brand;

        HostWindow.TxbBrand.Text = brand.Name;
    }

    private void SelectExec(object o)
    {
        HostWindow.DialogResult = true;

        var brandId = _controller.GetAllBrands().First(b => b.Name == HostWindow.TxbBrand.Text).Id;

        var colorId = _controller.GetAllColors().First(c => c.Name == HostWindow.TxbColor.Text).Id;

        var ownerId = _controller.GetAllPeople().First(p => p.FullName == HostWindow.TxbOwner.Text).Id;

        Car car = new()
        {
            BrandId = brandId,
            ColorId = colorId,
            OwnerId = ownerId,
            ReleaseYear = Convert.ToInt32(HostWindow.TxbReleaseYear.Text),
            StateNumber = HostWindow.TxbStateNumber.Text
        };

        _controller.AddCar(car);

        HostWindow.Close();

    } // BtnSelect

    private void CancelExec(object o)
    {
        HostWindow.DialogResult = false;
        HostWindow.Close();
    } //BtnCancel
}