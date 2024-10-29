using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CourseProject.Models.Entities.Configurations;

public class SpecializationConfiguration : IEntityTypeConfiguration<Specialization>
{
    public void Configure(EntityTypeBuilder<Specialization> builder)
    {

        builder
            .Property(b => b.Name)
            .IsUnicode()
            .IsRequired();

        // начальная инициализация таблицы
        //        List<Client> clients = [
        //            new() { Id = 20, Surname = "Фадеева", Name = "Эвелина", Patronymic = "Павловна", Passport = "13 12 158736", Discount = 5},
        //            new() { Id = 21, Surname = "Семин", Name = "Олег", Patronymic = "Викторович", Passport = "12 43 146813", Discount = 3 },
        //            new() { Id = 22, Surname = "Павлов", Name = "Алексей", Patronymic = "Павлович", Passport = "14 54 186321", Discount = 2 },
        //            new() { Id = 23, Surname = "Дзержинская", Name = "Евгения", Patronymic = "Петровна", Passport = "15 64 963752", Discount = 7 },
        //            new() { Id = 24, Surname = "Титов", Name = "Егор", Patronymic = "Петрович", Passport = "11 43 841317", Discount = 10 },
        //            new() { Id = 25, Surname = "Васнецова", Name = "Екатерина", Patronymic = "Павловна", Passport = "18 44 361881", Discount = 12 },
        //            new() { Id = 26, Surname = "Носова", Name = "Ирина", Patronymic = "Викторовна", Passport = "14 53 631145", Discount = 5 },
        //            new() { Id = 27, Surname = "Сидоров", Name = "Владимир", Patronymic = "Александрович", Passport = "15 63 961257", Discount = 4 },
        //            new() { Id = 28, Surname = "Андропов", Name = "Виктор", Patronymic = "Степанович", Passport = "13 17 943167", Discount = 8 },
        //            new() { Id = 29, Surname =  "Васильев", Name = "Дмитрий", Patronymic = "Павлович", Passport = "16 46 881372", Discount = 6 },
        //
        //        ];
        //        builder.HasData(clients);
    } // Configure
}