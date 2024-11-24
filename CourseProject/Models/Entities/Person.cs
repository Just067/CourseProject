using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(PersonConfiguration))]
public class Person
{
    // Первичный ключ таблицы People
    public int Id { get; set; }

    // Фамилия человека
    public string Surname { get; set; }

    // Имя человека
    public string Name { get; set; }

    // Отчество человека
    public string Patronymic { get; set; }

    // Вычисляемое свойство: полное имя
    public string FullName => $"{Surname} {Name} {Patronymic}";

    // Навигационное свойство: данные клиента, если человек является клиентом
    public virtual Client Client { get; set; }

    // Навигационное свойство: список записей о сотрудниках, если человек является сотрудником
    public virtual List<Employee> Employees { get; set; } = [];

    // Навигационное свойство: список автомобилей, которыми владеет этот человек
    public virtual List<Car> Cars { get; set; } = [];
}