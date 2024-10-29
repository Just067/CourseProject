using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(PersonConfiguration))]
public class Person
{
    public int Id { get; set; }
    public string Surname { get; set; }
    public string Name { get; set; }
    public string Patronymic { get; set; }

    // Вычисляемое свойство: фамилия и инициалы
    public string FullName => $"{Surname} {Name[0]}.{Patronymic[0]}.";

    public virtual Client Client { get; set; }

    public virtual List<Employee> Employees { get; set; } = [];

    public virtual List<Car> Cars { get; set; } = [];
}