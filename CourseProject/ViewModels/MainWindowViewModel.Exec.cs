﻿using System.Windows;
using CourseProject.Models.Entities;
using CourseProject.Views.Results;

namespace CourseProject.ViewModels;

public partial class MainWindowViewModel
{
    // добавление нового цвета
    private void AddColorExec(object o)
    {
        var dictionary = _controller.GetAllColors()
            .ToDictionary(c => c.Name);

        AddColorWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string color = dialog.Color.ToLower();

        if (!dictionary.ContainsKey(color))
        {
            _controller.AddColor(new Color { Name = color });

            MessageBox.Show($"Цвет '{color}' успешно добавлен.");

        }
        else
        {
            MessageBox.Show($"Цвет '{color}' уже существует.");
        }
    }

    // открытие окна клиента
    private void ShowClientExec(object o)
    {
        var client = (Client)HostWindow.DgClients.SelectedItem;

        var prefix = "/Assets/Clients/";
        client.PathPhoto = (client.PathPhoto.StartsWith(prefix) ? "" : prefix) + client.PathPhoto;
        var win = new EditClientWindow(client, _controller);

        win.ShowDialog();

        FillDataGrids();
    } // ShowClientExec

    // открытие окна автомобиля
    private void ShowCarExec(object o)
    {
        var car = (Car)HostWindow.DgCars.SelectedItem;

        var prefix = "/Assets/Cars/";
        car.PathPhoto = (car.PathPhoto.StartsWith(prefix) ? "" : prefix) + car.PathPhoto;
        var win = new EditCarWindow(car, _controller);

        win.ShowDialog();

        FillDataGrids();
    } // ShowCarExec

    // добавление новой марки автомобиля
    private void AddBrandExec(object o)
    {
        // Получить словарь всех названий марок из базы данных
        var brands = _controller.GetAllBrands()
            .ToDictionary(item => item.Name.ToLower());

        // Открыть диалог для ввода новой марки
        AddBrandWindow dialog = new();

        if (dialog.ShowDialog() != true)
        {
            return;
        }

        string brand = dialog.Brand;

        // Проверить наличие марки и добавить, если его нет
        if (!brands.ContainsKey(brand.ToLower()))
        {
            _controller.AddBrand(new Brand { Name = brand });
            MessageBox.Show($"Марка '{brand}' успешно добавлена.");
        }
        else
        {
            MessageBox.Show($"Марка '{brand}' уже существует.");
        }
    }

    // добавление автомобиля
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