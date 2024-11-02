using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(SpecializationConfiguration))]
public class Specialization
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Employee> Employees { get; set; } = [];
}