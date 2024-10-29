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
        //List<Person> people = [
        //    new() { Id = 1, Surname = "Романова", Name = "Александра", Patronymic = "Павловна", Passport = "13 12 445432" },
        //    new() { Id = 2, Surname = "Иванов", Name = "Павел", Patronymic = "Викторович", Passport = "12 43 435754" },
        //    new() { Id = 3, Surname = "Филимонов", Name = "Александр", Patronymic = "Павлович", Passport = "14 54 643563" },
        //    new() { Id = 4, Surname = "Павловская", Name = "Елена", Patronymic = "Петровна", Passport = "15 64 741353" },
        //    new() { Id = 5, Surname = "Петров", Name = "Павел", Patronymic = "Петрович", Passport = "18 43 846364" },
        //];
        //builder.HasData(people);
    } // Configure
}