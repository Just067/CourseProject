using CourseProject.Models.Entities.Configurations;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

[EntityTypeConfiguration(typeof(ClientConfiguration))]
public class Client
{
    public int Id { get; set; }
    public int PersonId { get; set; }
    public virtual Person Person { get; set; }

    public DateTime BirthDate { get; set; }
    public string Passport { get; set; }

    public string Registration { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}