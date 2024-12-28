using CourseProject.Models.Entities;

namespace CourseProject.Models.Queries;

public record CarInRepair(
    int Id,
    Car Car,
    DateTime StartDate,
    List<string> Defects,
    List<Employee> Employees
);