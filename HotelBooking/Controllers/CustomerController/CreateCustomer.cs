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
       CustomerPageHeader.CreateCustomerHeader();
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
        StringToWrite.SuccessfulAction($" Ny kund {firstNameInput} {lastNameInput} med telefonnummer {phoneInput} sparad!");
    }
}