using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(EmployeeConfiguration))]
public class Employee
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }

    public int SpecializationId { get; set; }
    public virtual Specialization Specialization { get; set; }

    public int Category { get; set; }
    public int Experience { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}