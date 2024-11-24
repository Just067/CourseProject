using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ColorConfiguration))]
public class Color
{
    // Первичный ключ таблицы Colors
    public int Id { get; set; }

    // Название цвета
    public string Name { get; set; }

    // Навигационное свойство: список автомобилей, связанных с этим цветом
    public virtual List<Car> Cars { get; set; } = [];
}