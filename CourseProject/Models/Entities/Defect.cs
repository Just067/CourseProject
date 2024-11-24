using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(DefectConfiguration))]
public class Defect
{

    // Первичный ключ таблицы Defects
    public int Id { get; set; }

    // Название неисправности
    public string Name { get; set; }

    // Навигационное свойство: список посещений техобслуживания
    public virtual List<Visit> Visits { get; set; } = [];
}