namespace HotelBooking;

public class ManageCustomer
{
    public Customer CreateCustomer()
    {
        //SKRIV IN KUND
        Console.Write("Förnamn: ");
        var firstName = Console.ReadLine();
        Console.Write("Efternamn: ");
        var lastName = Console.ReadLine();
        //GENERERA ID till kund - egen metod?
        //CREATE CUSTOMER
        var customer = new Customer(firstName, lastName);
        return customer;
    }

    public void SaveCustomerToList(Customer customer)
    {
        CustomerController controller = new CustomerController();
        controller.ListOfCustomers.Add(customer);
    }

    public void SaveCustomerToDatabase()
    {

        CustomerController controller = new CustomerController();
        foreach (var VARIABLE in controller.ListOfCustomers.ToString())
        {
            Console.WriteLine(VARIABLE);
        }          

        //skicka in till DATABAS
    }
}