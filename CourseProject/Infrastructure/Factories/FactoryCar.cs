using CourseProject.Models.Entities;

namespace CourseProject.Infrastructure.Factories;

public static partial class Factory
{
    public static List<Car> GetCars(int count, Func<int, int, int, int, Car> getCar) => Enumerable
        .Range(1, count)
        .Select(p => getCar(p, p, p, p))
        .ToList();

    // Создание сущности Car
    public static Car GetCar(int id, int ownerId, int brandId, int colorId)
    {
        return new Car
        {
            Id = id,
            OwnerId = ownerId,
            BrandId = brandId,
            ColorId = colorId,
            ReleaseYear = Utils.GetRandom(1990, 2023),
            StateNumber = $"{Utils.GetRandom(1000, 9999)}-{GetRandomLetter()}{GetRandomLetter()}-{Utils.GetRandom(1, 99)}",
            PathPhoto = GetRandomCarPhoto()
        };
    }

    public static string GetRandomCarPhoto() =>
        $"car_{Utils.GetRandom(1, 13):D3}.png";

    private static char GetRandomLetter() =>
        (char)('A' + Utils.GetRandom(0, 25));
}