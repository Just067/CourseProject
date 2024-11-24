using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(BrandConfiguration))]
public class Brand
{
    // Первичный ключ таблицы Brands
    public int Id { get; set; }

    // Название бренда автомобиля
    public string Name { get; set; }

    // Навигационное свойство: список автомобилей, относящихся к этому бренду
    public virtual List<Car> Cars { get; set; } = [];
}