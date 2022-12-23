using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.CustomerController;

public class CreateCustomer : ICrud
{
    public CreateCustomer(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        using (var dbContext = new ApplicationDbContext())
        {
            Console.Clear();
            Console.WriteLine(" REGISTRERA NY KUND");
            PageHeader.LineOne();
            Console.Write(" Förnamn: ");
            var firstNameInput = Console.ReadLine();
            Console.Write(" Efternamn: ");
            var lastNameInput = Console.ReadLine();
            Console.Write(" Telefon (xxxxxxxxxx): ");
            var phoneInput = Convert.ToInt32(Console.ReadLine());

            dbContext.Customers.Add(new Customer
            {
                FirstName = firstNameInput,
                LastName = lastNameInput,
                Phone = phoneInput
            });
            dbContext.SaveChanges();
        }
    }
}