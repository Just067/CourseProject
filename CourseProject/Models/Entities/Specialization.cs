namespace CourseProject.Models.Entities;

public class Specialization
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Employee> Employees { get; set; } = [];
}