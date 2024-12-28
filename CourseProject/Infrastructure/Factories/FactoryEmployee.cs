using CourseProject.Models.Entities;

namespace CourseProject.Infrastructure.Factories;

public static partial class Factory
{
    public static List<Employee> GetEmployees(int count, Func<int, int, int, Employee> getEmployee) => Enumerable
        .Range(1, count)
        .Select(p => getEmployee(p, p, p))
        .ToList();

    // Создание сущности Employee
    public static Employee GetEmployee(int id, int personId, int specializationId)
    {
        return new Employee
        {
            Id = id,
            PersonId = personId,
            SpecializationId = specializationId,
            Category = Utils.GetRandom(1, 5),
            Experience = Utils.GetRandom(1, 30),
            PathPhoto = GetRandomPersonImage(),
            IsEmployed = Utils.GetRandom(0, 1) == 1
        };
    }
}