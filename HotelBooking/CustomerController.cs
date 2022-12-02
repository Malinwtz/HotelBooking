namespace HotelBooking;

public class CustomerController
{
    public List<Customer> ListOfCustomers = new List<Customer>();

    public List<Customer> GetList()
    {
        return ListOfCustomers;
    }
}