using CourseProject.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class ClientConfiguration : IEntityTypeConfiguration<Client>
{
    public void Configure(EntityTypeBuilder<Client> builder)
    {
        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // связь с People
        builder
            .HasOne(c => c.Person)
            .WithOne(p => p.Client)
            .HasForeignKey<Client>(c => c.PersonId);

        // BirthDate
        builder
            .Property(c => c.BirthDate)
            .IsRequired();

        // Passport
        builder
            .Property(c => c.Passport)
            .HasMaxLength(15)
            .IsUnicode()
            .IsRequired();

        // Registration
        builder
            .Property(c => c.Registration)
            .HasMaxLength(60)
            .IsUnicode()
            .IsRequired();

        // PathPhoto
        builder
            .Property(p => p.PathPhoto)
            .HasMaxLength(255)
            .IsUnicode()
            .IsRequired();

        builder.HasIndex(c => c.Passport).IsUnique();

        // начальная инициализация таблицы
        builder.HasData(Factory.GetClients(10, Factory.GetClient));
    } // Configure
}