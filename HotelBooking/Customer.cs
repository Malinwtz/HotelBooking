namespace HotelBooking;

public class Customer
{
   // public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }

    public Customer(string firstName, string lastName)
    {
        FirstName = firstName;
        LastName = lastName;
    }
}