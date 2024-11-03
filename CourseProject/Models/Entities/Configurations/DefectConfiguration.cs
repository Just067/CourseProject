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
            new() { Id = 2, Name = "Разбилась фара"},
            new() { Id = 3, Name = "Испортился двигатель"},
            new() { Id = 4, Name = "Не работает поворотник"},
            new() { Id = 5, Name = "Лопнуло колесо"},
            new() { Id = 6, Name = "Царапина на бампере"}
        ];
        builder.HasData(defects);
    } // Configure
}