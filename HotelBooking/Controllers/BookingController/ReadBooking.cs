using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class ReadBooking : ICrud
{
    public ApplicationDbContext DbContext { get; set; }
    public ReadBooking(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DbContext = dbContext;
    }
    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine("Visa alla bokningar");
        Console.WriteLine("===================" + Environment.NewLine);
        View();
        Console.WriteLine(Environment.NewLine + "Tryck på enter för att fortsätta");
        Console.ReadKey();
    }

    public void View()
    {
        if (DbContext.Bookings == null)
            Console.WriteLine("Det finns inga bokningar");

        Console.WriteLine("Gäst\t\tRum\t\tDatum");
        foreach (var booking in DbContext.Bookings.Include(b => b.Customer)
                     .Include(b=>b.Room))
            Console.WriteLine($"{booking.Customer.FirstName} {booking.Customer.LastName}" +
                              $"\t{booking.Room.RoomId}\t{booking.StartDate.ToString("MM/dd/yyyy")}" +
                              $"-{booking.EndDate.ToString("MM/dd/yyyy")}");
    }
}