using System.Windows;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class MainWindowViewModel
{
    private void AddColorExec(object o)
    {
        // Получить список всех названий цветов из базы данных
        var colors = _controller.GetAllColors()
            .Select(item => item.Name.ToLower())
            .Distinct();

        // Открыть диалог для ввода нового цвета
        AddColorWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string color = dialog.Color;

        // Проверить наличие цвета и добавить, если его нет
        if (!colors.Contains(color))
        {
            _controller.AddColor(new Color { Name = color });
            MessageBox.Show($"Цвет '{color}' успешно добавлен.");
        }
        else
        {
            MessageBox.Show($"Цвет '{color}' уже существует.");
        }
    }

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
        if (!brands.Contains(brand))
        {
            _controller.AddColor(new Color { Name = brand });
            MessageBox.Show($"Марка '{brand}' успешно добавлен.");
        }
        else
        {
            MessageBox.Show($"Марка '{brand}' уже существует.");
        }
    }
}