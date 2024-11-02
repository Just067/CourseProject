using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        List<Color> colors = [
            new() { Id = 1, Name = "Красный"},
            new() { Id = 2, Name = "Синий"},
            new() { Id = 3, Name = "Синий"},
            new() { Id = 4, Name = "Синий"},
            new() { Id = 5, Name = "Синий"},
            new() { Id = 6, Name = "Синий"},
            new() { Id = 7, Name = "Синий"},
            new() { Id = 8, Name = "Синий"},
        ];
        builder.HasData(colors);
    } // Configure
}