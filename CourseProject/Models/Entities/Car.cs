using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(CarConfiguration))]
public class Car
{
    // Первичный ключ таблицы Cars
    public int Id { get; set; }

    // Внешний ключ: идентификатор владельца автомобиля
    public int OwnerId { get; set; }

    // Навигационное свойство: владелец автомобиля
    public virtual Person Owner { get; set; }

    // Внешний ключ: идентификатор бренда автомобиля
    public int BrandId { get; set; }

    // Навигационное свойство: бренд автомобиля
    public virtual Brand Brand { get; set; }

    // Внешний ключ: идентификатор цвета автомобиля
    public int ColorId { get; set; }

    // Навигационное свойство: цвет автомобиля
    public virtual Color Color { get; set; }

    // Год выпуска автомобиля
    public int ReleaseYear { get; set; }

    // Государственный регистрационный номер автомобиля
    public string StateNumber { get; set; }

    // Путь к фотографии автомобиля
    public string PathPhoto { get; set; }

    // Навигационное свойство: список посещений техобслуживания
    public virtual List<Visit> Visits { get; set; } = [];
}