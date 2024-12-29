using CourseProject.Models.Entities;

namespace CourseProject.Infrastructure.Factories;

public static partial class Factory
{
    public static List<Visit> GetVisits(int count, Func<int, int, int, int, int, int, Visit> getVisit) => Enumerable
        .Range(1, count)
        .Select(p => getVisit(p, p, p, p, p, p))
        .ToList();

    // Создание сущности Visit
    public static Visit GetVisit(int id, int carId, int clientId, int defectId, int serviceId, int employeeId) => new()
    {
        Id = id,
        CarId = carId,
        ClientId = clientId,
        DefectId = defectId,
        ServiceId = serviceId,
        EmployeeId = employeeId,
        DateOfApplication = DateTime.Now.AddDays(-Utils.GetRandom(0, 15)),
        DateOfIssue = DateTime.Now.AddDays(Utils.GetRandom(1, 15)),
        IsPaid = Utils.GetRandom(0, 1) == 1
    };
}