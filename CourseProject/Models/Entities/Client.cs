using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ClientConfiguration))]
public class Client
{
    // Первичный ключ таблицы Clients
    public int Id { get; set; }

    // Внешний ключ: идентификатор связанного человека
    public int PersonId { get; set; }

    // Навигационное свойство: данные человека
    public virtual Person Person { get; set; }

    // Дата рождения клиента
    public DateTime BirthDate { get; set; }

    // Паспортные данные клиента
    public string Passport { get; set; }

    // Адрес регистрации клиента
    public string Registration { get; set; }

    // Путь к фотографии клиента
    public string PathPhoto { get; set; }

    // Навигационное свойство: список посещений станции техобслуживания
    public virtual List<Visit> Visits { get; set; } = [];
}