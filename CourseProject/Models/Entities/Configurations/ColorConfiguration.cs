using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ColorConfiguration : IEntityTypeConfiguration<Color>
{
    public void Configure(EntityTypeBuilder<Color> builder)
    {

        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

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
            new() { Id = 6, Name = "фиолетовый"}
        ];
        builder.HasData(colors);
    } // Configure
}