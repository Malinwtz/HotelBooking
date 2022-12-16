using HotelBooking.Controllers.Interface;
using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class UpdateBooking : ICrud
{
    public UpdateBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine("Ändra kundinformation");
        Console.WriteLine("=====================");
        foreach (var c in DbContext.Customers)
            Console.WriteLine($"{c.CustomerId}. {c.FirstName} {c.LastName}");

        Console.Write("Välj Id på den kund du vill uppdatera: ");
        var customerIdToUpdate = Convert.ToInt32(Console.ReadLine());
        var personToUpdate = DbContext.Customers
            .First(c => c.CustomerId == customerIdToUpdate);

        Console.Write("Ange förnamn: ");
        var updatedFirstName = Console.ReadLine();
        Console.Write("Ange efternamn: ");
        var updatedLastName = Console.ReadLine();
        Console.Write("Ange telefonnummer: ");
        var updatedPhone = Convert.ToInt32(Console.ReadLine());

        personToUpdate.FirstName = updatedFirstName;
        personToUpdate.LastName = updatedLastName;
        personToUpdate.Phone = updatedPhone;
        DbContext.SaveChanges();
    }
}