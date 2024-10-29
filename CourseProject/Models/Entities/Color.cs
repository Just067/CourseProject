namespace CourseProject.Models.Entities;

public class Color
{
    public int Id { get; set; }
    public string Name { get; set; }

    public virtual List<Car> Cars { get; set; } = [];
}