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
        CustomerPageHeader.DeleteCustomerHeader();
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
                StringToWrite.NotSuccessfulAction(" Kunden finns inte. Prova ett annat Id. ");
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
            StringToWrite.SuccessfulAction(" Kund avregistrerad!");
        }
        else
        {
            StringToWrite.NotSuccessfulAction(" Det går inte att ta bort kunden eftersom kunden har en aktiv bokning");
        }
    }
}