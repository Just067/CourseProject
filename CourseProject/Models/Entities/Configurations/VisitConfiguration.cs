using CourseProject.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

namespace CourseProject.Models.Entities.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {

        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // связь с клиентами
        builder.HasOne(v => v.Client)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ClientId)
            .OnDelete(DeleteBehavior.NoAction);

        // связь с автомобилями
        builder.HasOne(v => v.Car)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.CarId);

        // связь с рабочими
        builder.HasOne(v => v.Employee)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.EmployeeId)
            .OnDelete(DeleteBehavior.NoAction);

        // связь с неисправностями
        builder.HasOne(v => v.Defect)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.DefectId);

        // связь с видами услуг
        builder.HasOne(v => v.Service)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ServiceId);

        // DateOfApplication
        builder.Property(v => v.DateOfApplication)
            .IsRequired();

        // DateOfIssue
        builder.Property(v => v.DateOfIssue)
            .IsRequired();

        // IsPaid
        builder.Property(v => v.IsPaid)
            .IsRequired();

        // Инициализация записей таблицы
        builder.HasData(Factory.GetVisits(10, Factory.GetVisit));
    } // Configure
}