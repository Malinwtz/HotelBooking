using HotelBooking.Controllers.ErrorController;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.CustomerController;

public class CustomerService
{
    public CustomerService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void SetCustomerPhoneNumber(Customer customerToSetPhone)
    {
        Console.Write(" Ange telefonnummer: ");
        var phoneInput = Console.ReadLine();
        customerToSetPhone.Phone = phoneInput;
    }

    public void SetCustomerLastName(Customer customerToSetLastName)
    {
        Console.Write(" Ange efternamn: ");
        var lastNameInput = Console.ReadLine();
        customerToSetLastName.LastName = lastNameInput;
    }

    public void SetCustomerFirstName(Customer customerToSetFirstName)
    {
        Console.Write(" Ange förnamn: ");
        var updatedFirstName = Console.ReadLine();
        customerToSetFirstName.FirstName = updatedFirstName;
    }

    public Customer FindCustomerById()
    {
        Console.Write(" Välj kund genom att skriva in Id: ");
        var customerId = ErrorHandling.TryInt();
        var customerFoundById = DbContext.Customers
            .Where(c => c.Active == true)
            .First(c => c.CustomerId == customerId);
        return customerFoundById;
    }
}