namespace HotelBooking.CustomerHandler;

public class Customer
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int Phone { get; set; }

    public Customer(string firstName, string lastName, int phone)
    {
        FirstName = firstName;
        LastName = lastName;
        Phone = phone;
    }
}