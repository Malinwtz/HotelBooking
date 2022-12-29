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
        
            Console.Clear();
            var selectionFromUpdateCustomerMenu = CustomerMenu.UpdateCustomerMenuShowAndReturnSelection();
            switch (selectionFromUpdateCustomerMenu)
            {
                case 1:
                {
                    Console.Clear();
                    Console.Write(" Ange nytt förnamn: ");
                    var updatedFirstName = Console.ReadLine();
                    personToUpdate.FirstName = updatedFirstName;
                    DbContext.SaveChanges();
                    break;
                }
                case 2:
                {
                    Console.Clear();
                    Console.Write(" Ange nytt efternamn: ");
                    var updatedLastName = Console.ReadLine();
                    personToUpdate.LastName = updatedLastName;
                    DbContext.SaveChanges();
                    break;
                }
                case 3:
                {
                    Console.Clear();
                    Console.Write(" Ange nytt telefonnummer: ");
                    var updatedPhone = Convert.ToInt32(Console.ReadLine());
                    personToUpdate.Phone = updatedPhone;
                    DbContext.SaveChanges();
                    break;
                }
            }
    }
}