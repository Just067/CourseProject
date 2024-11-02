using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(BrandConfiguration))]
public class Brand
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Car> Cars { get; set; } = [];
}