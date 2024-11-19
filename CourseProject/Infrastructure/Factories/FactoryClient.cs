using CourseProject.Models.Entities;

namespace CourseProject.Infrastructure.Factories;

public static partial class Factory
{
    // Создание сущности Client
    public static Client GetClient(int clientId, int personId) => new()
    {
        Id = clientId,
        PersonId = personId,
        Passport = GetRandomPassport(),
        Registration = GetRandomRegistration(),
        BirthDate = 
    };

    // Создание списка сущностей House
    public static List<House> GetHouses(int count, Func<int, int, House> getHouse) => Enumerable
    .Range(1, count)
    .Select(p => getHouse(p, p))
        .ToList();

    // Генерация "случаных" номеров домов
    private const int MinHouseNumber = 1, MaxHouseNumber = 300;
    private static string GetRandomRegistration() =>
        $"{Cities[Utils.GetRandom(0, Cities.Length - 1)]}, {Streets[Utils.GetRandom(0, Streets.Length - 1)]}";

    // Генерация "случаных" названий улиц
    private static string GetRandomPassport() => 
        Passports[Utils.GetRandom(0, Passports.Length - 1)];

    private static readonly string[] Passports = [
        "13 12 158736", "13 52 985176", "15 18 186321", "75 61 753964",
        "48 14 471652", "51 12 789153", "13 13 789127", "90 16 145320",
        "33 50 429415", "94 12 147935", "78 45 478223", "95 32 178102"
    ];

    private static readonly string[] Cities = [
        "Донецк", "Москва", "Санкт-Петербург", "Казань",
        "Грозный", "Архангельск", "Норильск", "Нальчик",
        "Ялта", "Краснодар", "Бирск", "Омск",
        "Ржев", "Самара",  "Екатеринбург"
    ];

    private static readonly string[] Streets = [
        "ул. Ленина, 15", "ул. Лесная, 21", "ул. Солнечная, 78", "ул. Центральная, 1",
        "ул. Тихая, 8", "ул. Зеленая, 20", "ул. Дзержинсвкого, 5", "ул. Вишневая, 40",
        "ул. Крупская, 62", "ул. Садовая, 52", "ул. Мостовая, 9", "ул. Речная, 30",
        "ул. Озерная, 49", "ул. Горная, 11",  "ул. Советская, 22",
        "ул. Октябрьская, 17", "ул. Сказочная, 39"
    ];
}