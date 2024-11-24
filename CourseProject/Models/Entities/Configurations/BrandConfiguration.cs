using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {
        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // Name
        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        List<Brand> brands = [
            new() { Id = 1, Name = "Dodge"},
            new() { Id = 2,  Name = "BMW"},
            new() { Id = 3,  Name = "Toyota"},
            new() { Id = 4,  Name = "Haval"},
            new() { Id = 5,  Name = "Kia"},
            new() { Id = 6,  Name = "Lada"},
            new() { Id = 7,  Name = "Mercedes-Benz"},
            new() { Id = 8,  Name = "Ford"},
            new() { Id = 9,  Name = "Volkswagen"},
            new() { Id = 10,  Name = "Audi"}
        ];
        builder.HasData(brands);
    } // Configure
}