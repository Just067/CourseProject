using CourseProject.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
{
    public void Configure(EntityTypeBuilder<Employee> builder)
    {

        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // Связь с People
        builder
            .HasOne(e => e.Person)
            .WithMany(p => p.Employees)
            .HasForeignKey(e => e.PersonId);

        // Связь со специальностями
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

        // PathPhoto
        builder
            .Property(p => p.PathPhoto)
            .HasMaxLength(255)
            .IsUnicode()
            .IsRequired();

        // IsEmployed
        builder.Property(e => e.IsEmployed)
            .IsRequired();

        // начальная инициализация таблицы
        builder.HasData(Factory.GetEmployees(10, Factory.GetEmployee));
    } // Configure
}