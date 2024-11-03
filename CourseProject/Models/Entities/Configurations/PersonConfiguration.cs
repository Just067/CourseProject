using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class PersonConfiguration : IEntityTypeConfiguration<Person>
{
    public void Configure(EntityTypeBuilder<Person> builder)
    {
        builder
            .Property(p => p.Surname)
            .HasMaxLength(60)
            .IsRequired();

        builder
            .Property(p => p.Name)
            .HasMaxLength(50)
            .IsRequired();

        builder
            .Property(p => p.Patronymic)
            .HasMaxLength(60)
            .IsRequired();

        // начальная инициализация таблицы
        List<Person> people = [
            new() { Id = 1, Surname = "Романова", Name = "Александра", Patronymic = "Павловна"},
            new() { Id = 2, Surname = "Иванов", Name = "Павел", Patronymic = "Викторович"},
            new() { Id = 3, Surname = "Филимонов", Name = "Александр", Patronymic = "Павлович"},
            new() { Id = 4, Surname = "Павловская", Name = "Елена", Patronymic = "Петровна"},
            new() { Id = 5, Surname = "Петров", Name = "Павел", Patronymic = "Петрович"},
            new() { Id = 6, Surname = "Шорохов", Name = "Виктор", Patronymic = "Евгеньевич"},
            new() { Id = 7, Surname = "Петров", Name = "Павел", Patronymic = "Петрович"},
            new() { Id = 8, Surname = "Павлов", Name = "Павел", Patronymic = "Петрович"},
            new() { Id = 9, Surname = "Петров", Name = "Павел", Patronymic = "Петрович"},
            new() { Id = 10, Surname = "Петров", Name = "Павел", Patronymic = "Петрович"},
        ];
        builder.HasData(people);
    } // Configure
}