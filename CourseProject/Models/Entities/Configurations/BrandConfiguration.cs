using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class BrandConfiguration : IEntityTypeConfiguration<Brand>
{
    public void Configure(EntityTypeBuilder<Brand> builder)
    {

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        List<Brand> brands = [
            new() { Id = 1, Name = "Dodge"},
            new() { Id = 2, Name = "BMW"},
            new() { Id = 3, Name = "Toyota"},
            new() { Id = 4, Name = "Haval"},
            new() { Id = 5, Name = "Kia"}
        ];
        builder.HasData(brands);
    } // Configure
}