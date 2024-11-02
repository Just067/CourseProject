using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(DefectConfiguration))]
public class Defect
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}