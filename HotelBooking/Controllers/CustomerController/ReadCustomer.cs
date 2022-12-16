using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class ReadCustomer : ICrud
{
    public ReadCustomer(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DatabaseContext = dbContext;
    }

    public ApplicationDbContext DatabaseContext { get; set; }

    public void RunCrud()
    {
        using (DatabaseContext)
        {
            Console.WriteLine("Visa alla kunder");
            Console.WriteLine("================");
            View();
        }
    }

    public void View()
    {
        foreach (var customer in DatabaseContext.Customers)
            Console.WriteLine(
                $"Id{customer.CustomerId}: {customer.FirstName} {customer.LastName} Telefon: {customer.Phone} ");
    }
}