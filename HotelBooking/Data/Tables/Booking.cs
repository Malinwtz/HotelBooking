using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Tables;

public class Booking
{
    [Key] public int BookingId { get; set; }
    [Required] public int CustomerId { get; set; }
    [Required] public int RoomId { get; set; }
    public List<Room> Rooms { get; set; }
}