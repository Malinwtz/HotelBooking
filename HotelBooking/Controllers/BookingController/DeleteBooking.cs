using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
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
        Console.Clear();
        Console.WriteLine("Ta bort en bokning");
        Console.WriteLine("==================");

        Console.WriteLine("Rum\t\t\tKundnamn\t\t\tDatum");
        foreach (var booking in DbContext.Bookings.Include(b=>b.Customer)
                                                  .Include(b=>b.Room))
            Console.WriteLine($"{booking.BookingId}\t\t\t{booking.Customer.FirstName} {booking.Customer.LastName}" +
                              $"\t\t\t{booking.StartDate.ToShortDateString()}-¨{booking.EndDate.ToShortDateString()}");

        Console.WriteLine("Välj Id på den bokning som du vill ta bort");
        var bookingIdToDelete = Convert.ToInt32(Console.ReadLine());
        var bookingToDelete = DbContext.Bookings.First(p => p.BookingId == bookingIdToDelete);

        DbContext.Bookings.Remove(bookingToDelete); 
        DbContext.SaveChanges();
    }
}