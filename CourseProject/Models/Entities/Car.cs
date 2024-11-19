using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car
{
    public int Id { get; set; }
    public int OwnerId { get; set; }
    public virtual Person Owner { get; set; }

    public int BrandId { get; set; }
    public virtual Brand Brand { get; set; }

    public int ColorId { get; set; }
    public virtual Color Color { get; set; }

    public int ReleaseYear { get; set; }
    public string StateNumber { get; set; }

    public string PathPhoto { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}