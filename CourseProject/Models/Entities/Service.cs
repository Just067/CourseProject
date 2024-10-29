namespace CourseProject.Models.Entities;

public class Service
{
    public int Id { get; set; }
    public string Name { get; set; }

    public int Cost { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}