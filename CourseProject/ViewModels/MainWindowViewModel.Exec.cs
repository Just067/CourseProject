using System.Windows;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class MainWindowViewModel
{
    // добавление нового цвета
    private void AddColorExec(object o)
    {
        var colors = _controller.GetAllColors()
            .Select(item => item.Name);

        AddColorWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string color = dialog.Color.ToLower();

        if (!colors.Contains(color))
        {
            _controller.AddColor(new Color { Name = color });

            colors = _controller.GetAllColors()
                .Select(item => item.Name);

            var colorNames = string.Join(", ", colors.Select(c => c));

            MessageBox.Show($"Цвет '{colorNames}' успешно добавлен.");

        }
        else
        {
            colors = _controller.GetAllColors()
                .Select(item => item.Name);

            var colorNames = string.Join(", ", colors.Select(c => c));

            MessageBox.Show($"Цвет '{colorNames}' уже существует.");
        }
    }

    // добавление новой марки автомобиля
    private void AddBrandExec(object o)
    {
        // Получить список всех названий марок из базы данных
        var brands = _controller.GetAllBrands()
            .Select(item => item.Name.ToLower())
            .Distinct();

        // Открыть диалог для ввода новой марки
        AddBrandWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string brand = dialog.Brand;

        // Проверить наличие марки и добавить, если его нет
        if (!brands.Contains(brand.ToLower()))
        {
            _controller.AddBrand(new Brand { Name = brand });
            MessageBox.Show($"Марка '{brand}' успешно добавлена.");
        }
        else
        {
            MessageBox.Show($"Марка '{brand}' уже существует.");
        }
    }

    private void AddCarExec(object o)
    {
        AddCarWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        FillDataGrids();
    }
}