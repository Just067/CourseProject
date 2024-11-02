using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ColorConfiguration))]
public class Color
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Car> Cars { get; set; } = [];
}