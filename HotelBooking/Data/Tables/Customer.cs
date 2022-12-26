using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Tables;

public class Customer
{
    [Key] public int CustomerId { get; set; }
    [Required][MaxLength(100)] public string FirstName { get; set; }
    [Required][MaxLength(100)] public string LastName { get; set; }
    public int Phone { get; set; }
    public bool Active { get; set; }
    public List<Booking> Bookings { get; set; }
}