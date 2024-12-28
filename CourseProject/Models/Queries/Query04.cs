using CourseProject.Models.Entities;

namespace CourseProject.Models.Queries;

public record Query04(
    int Id,
    Person Person,
    DateTime DateOfIssue
);