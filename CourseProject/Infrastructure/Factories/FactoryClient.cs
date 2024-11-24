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
        BirthDate = new DateTime(Utils.GetRandom(1940, 2005), Utils.GetRandom(1, 12), Utils.GetRandom(1, 28)),
        PathPhoto = GetRandomPersonImage()
    };

    public static List<Client> GetClients(int count, Func<int, int, Client> getClient) => Enumerable
        .Range(1, count)
        .Select(p => getClient(p, p))
        .ToList();

    private static string GetRandomRegistration() =>
        $"{Cities[Utils.GetRandom(0, Cities.Length - 1)]}, {Streets[Utils.GetRandom(0, Streets.Length - 1)]}";

    private static string GetRandomPassport()
    {
        
        // Выбрать случайный паспорт
        int index = Utils.GetRandom(0, Passports.Count - 1);
        string passport = Passports[index];

        // Удалить выбранный паспорт из списка
        Passports.RemoveAt(index);

        return passport;
    }

    private static string GetRandomPersonImage() =>
        $"man_{Utils.GetRandom(1, 14):D3}.jpg";

    private static readonly List<string> Passports = [
        "13 12 158736", "13 52 985176", "15 18 186321", "75 61 753964",
        "48 14 471652", "51 12 789153", "13 13 789127", "90 16 145320",
        "33 50 429415", "94 12 147935", "78 45 478223", "95 32 178102",
        "11 44 283748", "22 33 193845", "77 88 647291", "88 99 394857",
        "12 22 938475", "14 55 827364", "19 78 627394", "91 11 384756",
        "63 21 495837", "84 32 716485", "29 48 926374", "17 39 825491",
        "61 71 834675", "74 14 583927", "36 28 492817", "48 55 294817",
        "21 39 938745", "99 41 847391", "66 22 735891", "42 13 295847",
        "55 66 102938", "33 44 928475", "82 11 384627", "18 34 726493",
        "39 48 192837", "46 57 384957", "93 12 294857", "67 89 493726",
        "72 15 849273", "81 63 726483", "29 47 384621", "49 23 837462",
        "11 29 938475", "92 43 726394", "56 81 384762", "24 39 928475",
        "37 62 183947", "78 94 273849", "83 22 948372", "15 64 726483",
        "42 11 384726", "61 93 938472", "85 47 394827", "33 29 847562",
        "12 82 938475", "49 13 726394", "75 19 384762", "28 62 948372",
        "19 88 726483", "41 54 384726", "67 91 938472", "53 76 394827",
        "82 33 847562", "31 29 938475", "26 54 726394", "95 17 384762",
        "62 38 948372", "39 94 726483", "57 63 384726", "43 81 938472"
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