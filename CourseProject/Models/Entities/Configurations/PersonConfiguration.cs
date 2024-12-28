using CourseProject.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // Surname
        builder
            .Property(p => p.Surname)
            .HasMaxLength(60)
            .IsRequired();

        // Name
        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        // Patronymic
        builder
            .Property(p => p.Patronymic)
            .HasMaxLength(60)
            .IsRequired();

        // начальная инициализация таблицы
        builder.HasData(Factory.GetPeople(20, Factory.GetPerson));
    } // Configure
}