using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(VisitConfiguration))]
public class Visit
{
    // Первичный ключ таблицы Visits
    public int Id { get; set; }

    // Связь с автомобилем, участвующем в посещении
    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    // Связь с клиентом, обратившемся на станцию
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }

    // Связь с выявленным дефектом
    public int DefectId { get; set; }
    public virtual Defect Defect { get; set; }

    // Связь с услугой, оказаннойв рамках посещения
    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }

    // Связь с сотрудником, выполняющим обслуживание
    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }

    // Дата обращения клиента на станцию
    public DateTime DateOfApplication { get; set; }

    // Дата завершения и выдачи автомобиля
    public DateTime DateOfIssue { get; set; }

    // Статус оплаты посещения
    public bool IsPaid { get; set; }
}