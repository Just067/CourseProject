using Microsoft.EntityFrameworkCore;

namespace CourseProject.Models.Entities;

public class ServiceStationContext : DbContext
{
    public DbSet<Client> Clients => Set<Client>();
    public DbSet<Specialization> Specializations => Set<Specialization>();
    public DbSet<Employee> Employees => Set<Employee>();
    public DbSet<Visit> Visits => Set<Visit>();
    public DbSet<Person> People => Set<Person>();
    public DbSet<Brand> Brands => Set<Brand>();
    public DbSet<Color> Colors => Set<Color>();
    public DbSet<Service> Services => Set<Service>();
    public DbSet<Defect> Defects => Set<Defect>();
    public DbSet<Car> Cars => Set<Car>();

    public ServiceStationContext()
    {
        Database.EnsureDeleted();
        Database.EnsureCreated();
    } // ServiceStationContext


    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        // строка подключения
        optionsBuilder
            // подключение lazy loading, сначала установить NuGet-пакет Microsoft.EntityFrameworkCore.Proxies
            .UseLazyLoadingProxies()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ServiceStationDb;Trusted_Connection=True;");
    } // OnConfiguring

}