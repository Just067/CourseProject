using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        builder
            .ToTable(t => t.HasCheckConstraint("Cost", "Cost > 0"))
            .Property(s => s.Cost)
            .IsRequired();

        // начальная инициализация таблицы
        List<Service> services = [
            new() {Id = 1, Name = "Поменять кузов", Cost = 10000},
            new() {Id = 2, Name = "Сделать технический осмотр", Cost = 95000},
            new() {Id = 3, Name = "Поменять колесо", Cost = 20000},
            new() {Id = 4, Name = "Починить двигатель", Cost = 58000},
            new() {Id = 5, Name = "Покрасить автомобиль", Cost = 50500},
            new() {Id = 6, Name = "Поменять кузов", Cost = 70000},
            new() {Id = 7, Name = "Поменять кузов", Cost = 80000},
            new() {Id = 8, Name = "Поменять кузов", Cost = 30000},
        ];
        builder.HasData(services);
    } // Configure
}