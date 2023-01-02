using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.CustomerController;

public class DeleteCustomer : ICrud
{
    public DeleteCustomer(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public Customer CustomerToDelete { get; set; }
    public ApplicationDbContext DbContext { get; set; }
    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine(" TA BORT KUND");
        PageHeader.LineOne();
        var read = new ReadCustomer(DbContext);
        read.View();

        while (true)
        {
            Console.WriteLine("\n Välj Id på den kund som du vill ta bort");
            var customerIdToDelete = ErrorHandling.TryInt();
            CustomerToDelete = DbContext.Customers
                .FirstOrDefault(c => c.CustomerId == customerIdToDelete);

            if (CustomerToDelete == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Kunden finns inte. Prova ett annat Id. ");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
            {
                break;
            }
        }

        var listOfBookings = DbContext.Bookings
            .Where(b => b.Customer == CustomerToDelete)
            .ToList();

        if (!listOfBookings.Any())
        {
            CustomerToDelete.Active = false;
            DbContext.SaveChanges();

            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Kund avregistrerad!");
            Console.ForegroundColor = ConsoleColor.Gray;
            StringToWrite.PressEnterToContinue();
        }
        else
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Det går inte att ta bort kunden eftersom kunden har en aktiv bokning");
            Console.ForegroundColor = ConsoleColor.Gray;
            StringToWrite.PressEnterToContinue();
        }
    }
}