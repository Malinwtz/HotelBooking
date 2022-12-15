using HotelBooking.Controllers.CRUD;
using HotelBooking.Data;

namespace HotelBooking.Controllers.Update;

public class UpdateCustomer : ICrud
{
    public UpdateCustomer(ApplicationDbContext dbContext)
    {
        DatabaseContext = dbContext;
    }

    public ApplicationDbContext DatabaseContext { get; set; }

    public void RunCrud()
    {
        using (DatabaseContext)
        {
            Console.WriteLine("Ändra kundinformation");
            Console.WriteLine("=====================");
            foreach (var c in DatabaseContext.Customers)
                Console.WriteLine($"{c.CustomerId}. {c.FirstName} {c.LastName}");

            Console.Write("Välj Id på den kund du vill uppdatera: ");
            var customerIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var personToUpdate = DatabaseContext.Customers
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
            DatabaseContext.SaveChanges();
        }
    }
}