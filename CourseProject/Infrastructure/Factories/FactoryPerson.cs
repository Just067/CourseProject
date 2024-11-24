using CourseProject.Models.Entities;

namespace CourseProject.Infrastructure.Factories;

public static partial class Factory
{

    public static List<Person> GetPeople(int count, Func<int, Person> getPerson) => Enumerable
        .Range(1, count)
        .Select(getPerson)
        .ToList();

    // Создание сущности Person
    public static Person GetPerson(int id)
    {
        return new Person
        {
            Id = id,
            Surname = Surnames[Utils.GetRandom(0, Surnames.Length - 1)],
            Name = Names[Utils.GetRandom(0, Names.Length - 1)],
            Patronymic = Patronymics[Utils.GetRandom(0, Patronymics.Length - 1)]
        };
    }

    private static readonly string[] Surnames =
    [
        "Иванов", "Петров", "Сидоров", "Кузнецов", "Воробьёв",
        "Зайцев", "Павлов", "Васильев"
    ];

    private static readonly string[] Names =
    [
        "Александр", "Дмитрий", "Максим", "Егор", "Владимир",
        "Станислав", "Роман"
    ];

    private static readonly string[] Patronymics =
    [
        "Иванович", "Петрович", "Сидорович", "Александрович", "Дмитриевич",
        "Сергеевич", "Владимирович"
    ];
}