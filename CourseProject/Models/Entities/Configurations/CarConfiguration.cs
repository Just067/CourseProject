using CourseProject.Infrastructure.Factories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        // Id
        builder.Property(b => b.Id)
            .ValueGeneratedOnAdd();

        // связь с владельцем
        builder
            .HasOne(c => c.Owner)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.OwnerId);

        // связь с маркой
        builder
            .HasOne(c => c.Brand)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.BrandId);

        // связь с цветом
        builder
            .HasOne(c => c.Color)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.ColorId);

        builder
            .ToTable(t => t.HasCheckConstraint("ReleaseYear", "ReleaseYear > 1900"))
            .Property(c => c.ReleaseYear)
            .IsRequired();

        // StateNumber
        builder
            .Property(c => c.StateNumber)
            .HasMaxLength(20)
            .IsUnicode()
            .IsRequired();

        // PathPhoto
        builder
            .Property(p => p.PathPhoto)
            .HasMaxLength(255)
            .IsUnicode()
            .IsRequired();

        builder.HasIndex(c => c.StateNumber).IsUnique();

        // начальная инициализация таблицы
        builder.HasData(Factory.GetCars(10, Factory.GetCar));
    } // Configure
}