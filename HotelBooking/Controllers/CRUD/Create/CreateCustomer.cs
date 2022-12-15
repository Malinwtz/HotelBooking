using HotelBooking.Controllers.CRUD;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.Create;

public class CreateCustomer : ICrud
{
    public CreateCustomer(ApplicationDbContext dbContext)
    {
        DatabaseContext = dbContext;
    }

    public ApplicationDbContext DatabaseContext { get; set; }

    public void RunCrud()
    {
        using (var dbContext = new ApplicationDbContext())
        {
            Console.WriteLine("Registrera ny kund");
            Console.WriteLine("==================");
            Console.Write("Förnamn: ");
            var firstNameInput = Console.ReadLine();
            Console.Write("Efternamn: ");
            var lastNameInput = Console.ReadLine();
            Console.Write("Telefon: ");
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