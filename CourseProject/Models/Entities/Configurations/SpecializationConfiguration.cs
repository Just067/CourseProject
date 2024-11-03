using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        List<Specialization> specializations = [
            new() { Id = 1, Name = "инженер"},
            new() { Id = 2, Name = "автослесарь"},
            new() { Id = 3, Name = "автоэлектрик"},
            new() { Id = 4, Name = "шиномонтажник"},
            new() { Id = 5, Name = "автомаляр"},
        ];
        builder.HasData(specializations);
    } // Configure
}