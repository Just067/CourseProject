using CourseProject.Models.Entities;

namespace CourseProject.Models.Queries;

public record RepairedCar(
    int Id,
    Car Car,
    List<string> Defects,
    List<Employee> Employees,
    DateTime StartDate,
    DateTime EndDate
);