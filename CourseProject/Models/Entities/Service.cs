using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ServiceConfiguration))]
public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Cost { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}