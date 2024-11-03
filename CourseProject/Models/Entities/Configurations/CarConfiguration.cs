using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class CarConfiguration : IEntityTypeConfiguration<Car>
{
    public void Configure(EntityTypeBuilder<Car> builder)
    {
        builder
            .HasOne(c => c.Owner)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.OwnerId);

        builder
            .HasOne(c => c.Brand)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.BrandId);

        builder
            .HasOne(c => c.Color)
            .WithMany(p => p.Cars)
            .HasForeignKey(c => c.ColorId);

        builder
            .ToTable(t => t.HasCheckConstraint("ReleaseYear", "ReleaseYear > 1900"))
            .Property(c => c.ReleaseYear)
            .IsRequired();

        builder
            .Property(c => c.StateNumber)
            .HasMaxLength(20)
            .IsUnicode()
            .IsRequired();

        builder.HasIndex(c => c.StateNumber).IsUnique();


        // начальная инициализация таблицы
        List<Car> cars = [
            new() { Id = 1, OwnerId = 1, BrandId = 1, ColorId = 1, ReleaseYear = 2014, StateNumber = "A-180-DF"},
            new() { Id = 2, OwnerId = 2, BrandId = 2, ColorId = 2, ReleaseYear = 2017, StateNumber = "B-180-DF"},
            new() { Id = 3, OwnerId = 3, BrandId = 3, ColorId = 3, ReleaseYear = 2014, StateNumber = "C-180-DF"},
            new() { Id = 4, OwnerId = 4, BrandId = 4, ColorId = 4, ReleaseYear = 2018, StateNumber = "D-180-DF"},
            new() { Id = 5, OwnerId = 5, BrandId = 5, ColorId = 5, ReleaseYear = 2020, StateNumber = "E-180-DF"},
        ];
        builder.HasData(cars);
    } // Configure
}