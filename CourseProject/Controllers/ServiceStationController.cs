using CourseProject.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourseProject.Controllers;


public class ServiceStationController(ServiceStationContext db)
{
    public ServiceStationController() : this(new ServiceStationContext()) { }

    // чтение всех записей

    public List<Person> GetAllPeople() => db.People.ToList();

    public List<Client> GetAllClients() => db.Clients.ToList();

    public List<Specialization> GetAllSpecializations() => db.Specializations.ToList();

    public List<Employee> GetAllEmployees() => db.Employees.ToList();

    public List<Service> GetAllServices() => db.Services.ToList();

    public List<Defect> GetAllDefects() => db.Defects.ToList();

    public List<Color> GetAllColors() => db.Colors.ToList();

    public List<Brand> GetAllBrands() => db.Brands.ToList();

    public List<Car> GetAllCars() => db.Cars.ToList();

    public List<Visit> GetAllVisits() => db.Visits.ToList();

   public void AddColor(Color color)
   {
        db.Colors.Add(color);
        db.SaveChanges();
    }

   public void AddBrand(Brand brand)
   {
       db.Brands.Add(brand);
       db.SaveChanges();
   }

   public void AddCar(Car car)
   {
       db.Cars.Add(car);
       db.SaveChanges();
   }

   public void UpdateClient(Client client)
   {
       db.Clients.Update(client);
       db.SaveChanges();
   }

   public void UpdateCar(Car car)
   {
       db.Cars.Update(car);
       db.SaveChanges();
   }

} // class ServiceStationController
