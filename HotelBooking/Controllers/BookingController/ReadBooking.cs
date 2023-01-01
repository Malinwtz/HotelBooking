using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class ReadBooking : ICrud
{
    public ApplicationDbContext DbContext { get; set; }
    public ReadBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public void RunCrud()
    {
        BookingPageHeader.ReadBookingHeader();
        View();
        Console.WriteLine(Environment.NewLine + "Tryck på enter för att fortsätta");
        Console.ReadKey();
    }

    public void View() 
    {
        if (!DbContext.Bookings.Any()) 
        {
            Console.WriteLine(" Det finns inga bokningar");
        }
        else if (DbContext.Bookings.Any())
        {
            Console.WriteLine(String.Format("{0,-15} {1,-30} {2,-30} {3,-15} {4,-10}",
                $"Bokningens Id", "Kundnamn", "Startdatum - Slutdatum", "Antal dagar", "Rummets Id"));

            foreach (var b in DbContext.Bookings.Include(b => b.Customer).Include(b => b.Room))
                Console.WriteLine(String.Format("{0,-15} {1,-30} {2,-30} {3,-15} {4,-10}", $" {b.BookingId}", $"{b.Customer.FirstName} {b.Customer.LastName}",
                    $"{b.StartDate.ToString("dd MM yyyy")} - {b.EndDate.ToString("dd MM yyyy")}", $"{b.NumberOfDays}", $"{b.Room.RoomId}"));
        }
    }
}

//Console.WriteLine($"{booking.Customer.FirstName} {booking.Customer.LastName}" +
//                  $"\t{booking.Room.RoomId}\t{booking.StartDate.ToString("dd MM yyyy")}" +
//                  $"-{booking.EndDate.ToString("MM/dd/yyyy")}");