using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class ReadBooking : ICrud
{
    public ReadBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        BookingPageHeader.ReadBookingHeader();
        if (!DbContext.Bookings.Any())
        {
            Console.WriteLine(" Det finns inga bokningar");
            StringToWrite.PressEnterToContinue();
        }
        else if (DbContext.Bookings.Any())
        {
            View();
            StringToWrite.PressEnterToContinue();
        }
    }

    public void View()
    {
        Console.WriteLine("{0,-15} {1,-30} {2,-30} {3,-15} {4,-10}", "Bokningens Id", "Kundnamn",
            "Startdatum - Slutdatum", "Antal dagar", "Rummets Id");

        foreach (var b in DbContext.Bookings.Include(b => b.Customer).Include(b => b.Room))
            Console.WriteLine("{0,-15} {1,-30} {2,-30} {3,-15} {4,-10}", $" {b.BookingId}", $"{b.Customer.FirstName} {b.Customer.LastName}",
                $"{b.StartDate.ToString("dd MM yyyy")} - {b.EndDate.ToString("dd MM yyyy")}", $"{b.NumberOfDays}", $"{b.Room.RoomId}");

        Lines.LineTwoHyphen();
    }
}