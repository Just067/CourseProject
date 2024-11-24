using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class DefectConfiguration : IEntityTypeConfiguration<Defect>
{
    public void Configure(EntityTypeBuilder<Defect> builder)
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
        List<Defect> defects = [
            new() { Id = 1, Name = "Кузов отвалился"},
            new() { Id = 2, Name = "Разбилась фара"},
            new() { Id = 3, Name = "Испортился двигатель"},
            new() { Id = 4, Name = "Не работает поворотник"},
            new() { Id = 5, Name = "Лопнуло колесо"},
            new() { Id = 6, Name = "Царапина на бампере"},
            new() { Id = 7, Name = "Тормоза не работают"},
            new() { Id = 8, Name = "Шум в подвеске"},
            new() { Id = 9, Name = "Не заводится"},
            new() { Id = 10, Name = "Проблемы с электроникой"}
        ];
        builder.HasData(defects);
    } // Configure
}