using HotelBooking.Controllers.ErrorController;
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
        Console.Clear();
            Console.WriteLine(" REGISTRERA NY KUND");
            PageHeader.LineOne();
            Console.Write(" Förnamn: ");
            var firstNameInput = Console.ReadLine();
            Console.Write(" Efternamn: ");
            var lastNameInput = Console.ReadLine();
            Console.Write(" Telefon: ");
            var phoneInput = Console.ReadLine();

            DbContext.Customers.Add(new Customer
            {
                FirstName = firstNameInput,
                LastName = lastNameInput,
                Phone = phoneInput,
                Active = true
            });
        DbContext.SaveChanges();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine($" Ny kund {firstNameInput} {lastNameInput} med telefonnummer {phoneInput} sparad!");
        Console.ForegroundColor = ConsoleColor.Gray;
        StringToWrite.PressEnterToContinue();
    }
}