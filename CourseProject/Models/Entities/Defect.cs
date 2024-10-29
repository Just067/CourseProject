namespace CourseProject.Models.Entities;

public class Defect
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Visit> Visits { get; set; } = [];
}