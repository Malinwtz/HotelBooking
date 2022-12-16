using HotelBooking.Controllers.Interface;
using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class ReadBooking : ICrud
{
    public ReadBooking(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        using (DbContext)
        {
            Console.WriteLine("Visa alla kunder");
            Console.WriteLine("================");
            View();
        }
    }

    public void View()
    {
        foreach (var customer in DbContext.Customers)
            Console.WriteLine(
                $"Id{customer.CustomerId}: {customer.FirstName} {customer.LastName} Telefon: {customer.Phone} ");
    }
}