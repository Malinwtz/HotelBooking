using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

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
        CustomerPageHeader.UpdateCustomerHeader();
        if (!DbContext.Customers.Any())
        {
            Console.WriteLine(" Det finns inga kunder");
        }
        else if (DbContext.Customers.Any())
        {
            var read = new ReadCustomer(DbContext);
            read.View();
            var personToUpdate = FindCustomerToUpdate();

            var selectionFromUpdateCustomerMenu = CustomerMenu.UpdateCustomerMenuShowAndReturnSelection();
            Console.Clear();
            switch (selectionFromUpdateCustomerMenu)
            {
                case 1:
                {
                    SetNewFirstName(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
                case 2:
                {
                    SetNewLastName(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
                case 3:
                {
                    SetNewPhoneNumber(personToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
            }
            StringToWrite.SuccessfulAction(" Kund ändrad!");
        }
    }

    private static void SetNewPhoneNumber(Customer personToUpdate)
    {
        Console.Write(" Ange nytt telefonnummer: ");
        var updatedPhone = Console.ReadLine();
        personToUpdate.Phone = updatedPhone;
    }

    private static void SetNewLastName(Customer personToUpdate)
    {
        Console.Write(" Ange nytt efternamn: ");
        var updatedLastName = Console.ReadLine();
        personToUpdate.LastName = updatedLastName;
    }

    private static void SetNewFirstName(Customer personToUpdate)
    {
        Console.Write(" Ange nytt förnamn: ");
        var updatedFirstName = Console.ReadLine();
        personToUpdate.FirstName = updatedFirstName;
    }

    private Customer FindCustomerToUpdate()
    {
        Console.Write(" Välj Id på den kund du vill uppdatera: ");
        var customerIdToUpdate = ErrorHandling.TryInt();
        var personToUpdate = DbContext.Customers
            .Where(c => c.Active == true)
            .First(c => c.CustomerId == customerIdToUpdate);
        return personToUpdate;
    }
}