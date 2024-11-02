using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CourseProject.Models.Entities.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {

        builder.HasOne(v => v.Client)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(v => v.Car)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.CarId);

        builder.HasOne(v => v.Employee)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(v => v.Defect)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.DefectId);

        builder.HasOne(v => v.Service)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ServiceId);

        builder.Property(v => v.DateOfApplication)
            .IsRequired();

        builder.Property(v => v.DateOfIssue)
            .IsRequired();

        builder.Property(v => v.IsPaid)
            .IsRequired();

        // Инициализация записей таблицы
        List<Visit> visits = [
            new() { Id = 1, ClientId = 1, EmployeeId = 1, ServiceId = 1, CarId = 1, DefectId = 1, DateOfApplication = new DateTime(2024, 03, 25), DateOfIssue = new DateTime(2024, 04, 20), IsPaid = false},
             new() { Id = 2, ClientId = 2, EmployeeId = 2, ServiceId = 2, CarId = 2, DefectId = 2, DateOfApplication = new DateTime(2024, 04, 21), DateOfIssue = new DateTime(2024, 04, 20), IsPaid = true },
             new() { Id = 3, ClientId = 3, EmployeeId = 3, ServiceId = 3, CarId = 3, DefectId = 3, DateOfApplication = new DateTime(2023, 10, 10), DateOfIssue = new DateTime(2024, 04, 20), IsPaid = false },
             new() { Id = 4, ClientId = 4, EmployeeId = 4, ServiceId = 4, CarId = 4, DefectId = 4, DateOfApplication = new DateTime(2024, 04, 18), DateOfIssue = new DateTime(2024, 04, 20), IsPaid = true },
             new() { Id = 5, ClientId = 5, EmployeeId = 5, ServiceId = 5, CarId = 5, DefectId = 5, DateOfApplication = new DateTime(2024, 04, 27), DateOfIssue = new DateTime(2024, 04, 20), IsPaid = false },

        ];
        builder.HasData(visits);
    } // Configure
}