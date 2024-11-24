using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ServiceConfiguration))]
public class Service
{
    // Первичный ключ таблицы Services
    public int Id { get; set; }

    // Название услуги
    public string Name { get; set; }

    // Стоимость услуги
    public int Cost { get; set; }

    // Навигационное свойство: список посещений, в которых была оказана эта услуга
    public virtual List<Visit> Visits { get; set; } = [];
}