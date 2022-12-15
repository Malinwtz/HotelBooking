using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers;

public class CustomerController
{
    public List<Customer> ListOfCustomers = new List<Customer>();

    public List<Customer> GetList()
    {
        return ListOfCustomers;
    }
}