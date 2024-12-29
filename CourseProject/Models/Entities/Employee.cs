using System.ComponentModel;
using System.Runtime.CompilerServices;
using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(EmployeeConfiguration))]
public class Employee:INotifyPropertyChanged
{
    private bool _isEmployed;

    // Первичный ключ таблицы Employees
    public int Id { get; set; }

    // Внешний ключ: идентификатор связанного человека
    public int PersonId { get; set; }

    // Навигационное свойство: данные человека
    public virtual Person Person { get; set; }

    // Внешний ключ: идентификатор специализации сотрудника
    public int SpecializationId { get; set; }

    // Навигационное свойство: специализация сотрудника
    public virtual Specialization Specialization { get; set; }

    // Разряд (категория) сотрудника
    public int Category { get; set; }

    // Опыт работы сотрудника (в годах)
    public int Experience { get; set; }

    // Путь к фотографии сотрудника
    public string PathPhoto { get; set; }

    // Статус занятости сотрудника
    public bool IsEmployed
    {
        get => _isEmployed;
        set
        {
            if (value == _isEmployed) return;
            _isEmployed = value;
            OnPropertyChanged();
        }
    }

    // Навигационное свойство: список посещений станции техобслуживания, связанных с этим сотрудником
    public virtual List<Visit> Visits { get; set; } = [];

    public event PropertyChangedEventHandler? PropertyChanged;
    public void OnPropertyChanged([CallerMemberName] string prop = "")
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
    }
}