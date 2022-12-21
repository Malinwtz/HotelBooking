using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Tables;

public class Room
{
    [Key] public int RoomId { get; set; }
    [Required] [Range(10, 50)] public int SizeSquareMeters { get; set; }
    [Required] public int NumberOfGuests { get; set; }
    [Required] public string Type { get; set; }
    [Required] public int ExtraBed { get; set; }
    public List<Booking> Bookings { get; set; }
}