using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {
        builder
            .HasOne(e => e.Person)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PersonId);

        builder
            .HasOne(e => e.Specialization)
            .WithMany(s => s.Employees)
            .HasForeignKey(e => e.SpecializationId);

        builder
            .ToTable(t => t.HasCheckConstraint("Category", "Category >= 0"))
            .Property(e => e.Category)
            .IsRequired();

        builder
            .ToTable(t => t.HasCheckConstraint("Experience", "Experience >= 0"))
            .Property(e => e.Experience)
            .IsRequired();

        // начальная инициализация таблицы
        List<Employee> employees = [
            new() { Id = 1, PersonId = 5, SpecializationId = 1, Category = 1, Experience = 15},
            new() { Id = 2, PersonId = 6, SpecializationId = 2, Category = 1, Experience = 15},
            new() { Id = 3, PersonId = 7, SpecializationId = 3, Category = 1, Experience = 15},
            new() { Id = 4, PersonId = 8, SpecializationId = 4, Category = 1, Experience = 15},
            new() { Id = 5, PersonId = 9, SpecializationId = 5, Category = 1, Experience = 15},
        ];
        builder.HasData(employees);
    } // Configure
}