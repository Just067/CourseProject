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
            new() { Id = 2, Name = "инженер"},
            new() { Id = 3, Name = "инженер"},
            new() { Id = 4, Name = "инженер"},
            new() { Id = 5, Name = "инженер"},
        ];
        builder.HasData(specializations);
    } // Configure
}