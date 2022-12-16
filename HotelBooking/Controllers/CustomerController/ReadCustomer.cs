using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class ReadCustomer : ICrud
{
    public ApplicationDbContext DbContext { get; set; }
    public ReadCustomer(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DbContext = dbContext;
    }
    public void RunCrud()
    {
        Console.WriteLine("Visa alla kunder");
        Console.WriteLine("================"); 
        View();
    }

    public void View()
    {
        foreach (var customer in DbContext.Customers)
            Console.WriteLine(
                $"Id{customer.CustomerId}: {customer.FirstName} {customer.LastName} Telefon: {customer.Phone} ");
    }
}