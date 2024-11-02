using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        builder
            .HasOne(c => c.Person)
            .WithOne(p => p.Client)
            .HasForeignKey<Client>(c => c.PersonId);

        builder
            .Property(c => c.BirthDate)
            .IsRequired();

        builder
            .Property(c => c.Passport)
            .HasMaxLength(15)
            .IsUnicode()
            .IsRequired();

        builder
            .Property(c => c.Registration)
            .HasMaxLength(60)
            .IsUnicode()
            .IsRequired();

        builder.HasIndex(c => c.Passport).IsUnique();

        // начальная инициализация таблицы
        List<Client> clients = [
            new() { Id = 1, PersonId = 1, Passport = "13 12 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 2, PersonId = 2, Passport = "13 13 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 3, PersonId = 3, Passport = "13 14 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 4, PersonId = 4, Passport = "13 15 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 5, PersonId = 5, Passport = "13 16 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 6, PersonId = 6, Passport = "13 17 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"},
            new() { Id = 7, PersonId = 7, Passport = "13 18 158736", BirthDate = new DateTime(2000, 11, 12), Registration = "ул. Ленина 15"}
        ];
        builder.HasData(clients);
    } // Configure
}