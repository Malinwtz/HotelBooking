using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class UpdateCustomer : ICrud
{
    public UpdateCustomer(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine(" ÄNDRA KUND");
        PageHeader.LineOne();
            foreach (var c in DbContext.Customers)
                Console.WriteLine($" {c.CustomerId}. {c.FirstName} {c.LastName}");

            Console.Write(" Välj Id på den kund du vill uppdatera: ");
            var customerIdToUpdate = Convert.ToInt32(Console.ReadLine());
            var personToUpdate = DbContext.Customers
                .First(c => c.CustomerId == customerIdToUpdate);
        
            CustomerMenu.UpdateCustomerMenuShowAndReturnSelection();
            //skriv en meny 
            //ändra förnamn
            //ändra efternamn
            //ändra telefonnummer
            Console.Write(" Ange förnamn: ");
            var updatedFirstName = Console.ReadLine();
            Console.Write(" Ange efternamn: ");
            var updatedLastName = Console.ReadLine();
            Console.Write(" Ange telefonnummer: ");
            var updatedPhone = Convert.ToInt32(Console.ReadLine());

            personToUpdate.FirstName = updatedFirstName;
            personToUpdate.LastName = updatedLastName;
            personToUpdate.Phone = updatedPhone;
            DbContext.SaveChanges();
        
    }
}