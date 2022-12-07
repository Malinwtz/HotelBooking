namespace HotelBooking.CustomerHandler;

public class CustomerController
{
    public List<Customer> ListOfCustomers = new List<Customer>();

    public List<Customer> GetList()
    {
        return ListOfCustomers;
    }
}