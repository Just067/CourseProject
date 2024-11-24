using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
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
        List<Specialization> specializations = [
            new() { Id = 1, Name = "инженер"},
            new() { Id = 2, Name = "автослесарь"},
            new() { Id = 3, Name = "автоэлектрик"},
            new() { Id = 4, Name = "рихтовщик"},
            new() { Id = 5, Name = "автомаляр"},
            new() { Id = 6, Name = "механик"},
            new() { Id = 7, Name = "кузовщик"},
            new() { Id = 8, Name = "мастер шиномонтажа"},
            new() { Id = 9, Name = "диагност"},
            new() { Id = 10, Name = "мастер-приемщик"},
        ];
        builder.HasData(specializations);
    } // Configure
}