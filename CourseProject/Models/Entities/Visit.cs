using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(VisitConfiguration))]
public class Visit
{
    public int Id { get; set; }

    public int CarId { get; set; }
    public virtual Car Car { get; set; }

    // клиент
    public int ClientId { get; set; }
    public virtual Client Client { get; set; }


    public int DefectId { get; set; }
    public virtual Defect Defect { get; set; }

    public int ServiceId { get; set; }
    public virtual Service Service { get; set; }

    public int EmployeeId { get; set; }
    public virtual Employee Employee { get; set; }


    public DateTime DateOfApplication { get; set; }

    public DateTime DateOfIssue { get; set; }  

}