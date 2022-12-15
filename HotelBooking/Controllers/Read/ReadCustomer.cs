using HotelBooking.Data;

namespace HotelBooking.Controllers.Read;

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
            Console.WriteLine("(Visa alla kunder");
            Console.WriteLine("=================");
            ViewCustomers();
        }
    }

    public void ViewCustomers()
    {
        foreach (var customer in DatabaseContext.Customers)
            Console.WriteLine(
                $"Id{customer.CustomerId}: {customer.FirstName} {customer.LastName} Telefon: {customer.Phone} ");
    }
}