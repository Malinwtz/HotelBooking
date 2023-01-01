using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;

namespace HotelBooking.Controllers.CustomerController;

public class ReadCustomer : ICrud
{
    public ApplicationDbContext DbContext { get; set; }
    public ReadCustomer(ApplicationDbContext dbContext) 
    {
        DbContext = dbContext;
    }
    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine(" VISA ALLA KUNDER");
        PageHeader.LineOne();
        View();
        StringToWrite.PressEnterToContinue();
    }

    public void View()
    {
        Console.WriteLine(String.Format("{0,-10}  {1,-30}  {2,5}", "Id", "Namn", "Telefon"));
        foreach (var customer in DbContext.Customers.Where(c => c.Active == true))
        {
            Console.WriteLine(String.Format("{0,-10}  {1,-30}  {2,5}", 
                $"{customer.CustomerId}", $"{customer.FirstName} {customer.LastName}", $"{customer.Phone}"));
        }
    }
}