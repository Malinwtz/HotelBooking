using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Tables;

public class Booking
{
    [Key] public int BookingId { get; set; }
    [Required] public int CustomerId { get; set; }
    [Required] public int RoomId { get; set; }
    public Room Room { get; set; }
    public Customer Customer { get; set; }
}