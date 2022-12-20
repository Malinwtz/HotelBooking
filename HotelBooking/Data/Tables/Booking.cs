using System.ComponentModel.DataAnnotations;

namespace HotelBooking.Data.Tables;

public class Booking
{
    [Key] public int BookingId { get; set; }
    [Required] public Customer Customer { get; set; } 
    [Required] public Room Room { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    //public Room RoomBooking { get; set; }
    public int NumberOfDays { get; set; }
}