namespace HotelBooking;

public class ManageCustomer
{
    public void CreateCustomer()
    {
        //CREATE CUSTOMER
        var customer = new Customer();
        //SKRIV IN KUND
        Console.Write("Förnamn: ");
        var firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        var lastName = Console.ReadLine();
        //GENERERA ID till kund - egen metod?
    }

    public void SaveCustomerToList(Customer customer)
    {
        CustomerController controller = new CustomerController();
        controller.ListOfCustomers.Add(customer);
    }

    public void SaveCustomerToDatabase()
    {

        //skicka in till DATABAS
    }
}

public class CustomerController
{
    public List<Customer> ListOfCustomers = new List<Customer>();
}