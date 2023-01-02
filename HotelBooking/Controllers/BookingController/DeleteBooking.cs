using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class DeleteBooking : ICrud
{
    public DeleteBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        BookingPageHeader.DeleteBookingHeader();

        var read = new ReadBooking(DbContext);
        read.View();
        
        var bookingToDelete = FindBookingToDelete();

        DbContext.Bookings.Remove(bookingToDelete); 
        DbContext.SaveChanges();

        StringToWrite.SuccessfulAction("Bokning borttagen!");
    }

    private Booking FindBookingToDelete()
    {
        Console.WriteLine("Välj Id på den bokning som du vill ta bort");
        var bookingIdToDelete = Convert.ToInt32(Console.ReadLine());
        var bookingToDelete = DbContext.Bookings.First(p => p.BookingId == bookingIdToDelete);
        return bookingToDelete;
    }
}