using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(SpecializationConfiguration))]
public class Specialization
{
    // Первичный ключ таблицы Specializations
    public int Id { get; set; }

    // Название специализации
    public string Name { get; set; }

    // Навигационное свойство: список сотрудников, имеющих эту специализацию
    public virtual List<Employee> Employees { get; set; } = [];
}