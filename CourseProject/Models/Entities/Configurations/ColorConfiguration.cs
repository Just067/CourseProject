using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
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
        List<Color> colors = [
            new() { Id = 1, Name = "красный"},
            new() { Id = 2, Name = "синий"},
            new() { Id = 3, Name = "голубой"},
            new() { Id = 4, Name = "зеленый"},
            new() { Id = 5, Name = "черный"},
            new() { Id = 6, Name = "фиолетовый"},
            new() { Id = 7, Name = "желтый"},
            new() { Id = 8, Name = "розовый"},
            new() { Id = 9, Name = "белый"},
            new() { Id = 10, Name = "серый"}
        ];
        builder.HasData(colors);
    } // Configure
}