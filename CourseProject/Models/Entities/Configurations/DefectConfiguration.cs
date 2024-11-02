using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class DefectConfiguration : IEntityTypeConfiguration<Defect>
{
    public void Configure(EntityTypeBuilder<Defect> builder)
    {

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        List<Defect> defects = [
            new() { Id = 1, Name = "Кузов отвалился"},
            new() { Id = 2, Name = "Кузов отвалился"},
            new() { Id = 3, Name = "Кузов отвалился"},
            new() { Id = 4, Name = "Кузов отвалился"},
            new() { Id = 5, Name = "Кузов отвалился"},
            new() { Id = 6, Name = "Кузов отвалился"},
            new() { Id = 7, Name = "Кузов отвалился"},
            new() { Id = 8, Name = "Кузов отвалился"},
        ];
        builder.HasData(defects);
    } // Configure
}