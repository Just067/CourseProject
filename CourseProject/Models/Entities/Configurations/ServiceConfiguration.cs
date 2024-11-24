using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ServiceConfiguration : IEntityTypeConfiguration<Service>
{
    public void Configure(EntityTypeBuilder<Service> builder)
    {

        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // Name
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
            new() {Id = 3, Name = "Поменять колесо", Cost = 9000},
            new() {Id = 4, Name = "Починить двигатель", Cost = 58000},
            new() {Id = 5, Name = "Покрасить автомобиль", Cost = 1000},
            new() {Id = 6, Name = "Заменить масло", Cost = 2000},
            new() {Id = 7, Name = "Заменить тормозные колодки", Cost = 80000},
            new() {Id = 8, Name = "Отрегулировать сход-развал", Cost = 30000},
            new() {Id = 9, Name = "Заменить фару", Cost = 6500},
            new() {Id = 10, Name = "Починить электронику", Cost = 50000},
        ];
        builder.HasData(services);
    } // Configure
}