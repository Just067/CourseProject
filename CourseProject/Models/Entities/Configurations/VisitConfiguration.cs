using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class VisitConfiguration : IEntityTypeConfiguration<Visit>
{
    public void Configure(EntityTypeBuilder<Visit> builder)
    {

        builder.HasOne(v => v.Client)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.ClientId);

        builder.HasOne(v => v.Car)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.CarId);

        builder.HasOne(v => v.Employee)
            .WithMany(c => c.Visits)
            .HasForeignKey(v => v.EmployeeId);

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

        // // Инициализация записей таблицы
        // List<Visit> contracts = [
        //     new() { Id = 1, ClientId = 20, InsuranceAgentId = 40, InsuranceType = "Личное", InsurancePrice = 60_000, Tariff = 10, ContractDate = new DateTime(2024, 03, 25) },
        //     new() { Id = 2, ClientId = 21, InsuranceAgentId = 41, InsuranceType = "Имущественное", InsurancePrice = 25_000, Tariff = 12, ContractDate = new DateTime(2024, 04, 21) },
        //     new() { Id = 3, ClientId = 22, InsuranceAgentId = 42, InsuranceType = "Страхование гражданской ответственности", InsurancePrice = 30_000, Tariff = 9, ContractDate = new DateTime(2023, 10, 10) },
        //     new() { Id = 4, ClientId = 23, InsuranceAgentId = 43, InsuranceType = "Страхование финансовых рисков", InsurancePrice = 160_000, Tariff = 8, ContractDate = new DateTime(2024, 04, 18) },
        //     new() { Id = 5, ClientId = 24, InsuranceAgentId = 44, InsuranceType = "Личное", InsurancePrice = 40_000, Tariff = 10, ContractDate = new DateTime(2024, 04, 27) },
        //     new() { Id = 6, ClientId = 25, InsuranceAgentId = 45, InsuranceType = "Имущественное", InsurancePrice = 30_000, Tariff = 15, ContractDate = new DateTime(2023, 10, 09) },
        //     new() { Id = 7, ClientId = 26, InsuranceAgentId = 46, InsuranceType = "Страхование гражданской ответственности", InsurancePrice = 100_000, Tariff = 9, ContractDate = new DateTime(2024, 03, 28) },
        //     new() { Id = 8, ClientId = 27, InsuranceAgentId = 47, InsuranceType = "Страхование финансовых рисков", InsurancePrice = 80_000, Tariff = 10, ContractDate = new DateTime(2024, 04, 18) },
        //     new() { Id = 9, ClientId = 28, InsuranceAgentId = 48, InsuranceType = "Личное", InsurancePrice = 90_000, Tariff = 12, ContractDate = new DateTime(2024, 02, 19) },
        //     new() { Id = 10, ClientId = 29, InsuranceAgentId = 49, InsuranceType = "Имущественное", InsurancePrice = 50_000, Tariff = 13, ContractDate = new DateTime(2024, 02, 27) }
        //
        // ];
        // builder.HasData(contracts);
    } // Configure
}