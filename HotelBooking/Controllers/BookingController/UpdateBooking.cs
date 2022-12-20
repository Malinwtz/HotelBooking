using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class UpdateBooking : ICrud
{
    public UpdateBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine("Ändra bokning");
        Console.WriteLine("=============");
        foreach (var b in DbContext.Bookings.Include(b=>b.Customer)
                                                   .Include(b=>b.Room))
            Console.WriteLine($"{b.BookingId} {b.Customer.FirstName} {b.Customer.LastName} " +
                              $"{b.StartDate.ToShortDateString()}.{b.EndDate.ToShortDateString()}");

        Console.Write("Välj Id på den bokning du vill uppdatera: ");
        var bookingIdToUpdate = Convert.ToInt32(Console.ReadLine());
        var bookingToUpdate = DbContext.Bookings
            .First(c => c.BookingId == bookingIdToUpdate);

        Console.Write("Ange startdatum: ");
        var updatedStartDate = Convert.ToDateTime(Console.ReadLine());
        Console.Write("Ange antal dagar: ");
        var updatedNumberOfDays = Convert.ToInt32(Console.ReadLine());
        Console.Write("Ange rummets Id: ");
        var updatedRoomId = Convert.ToInt32(Console.ReadLine());

        var updatedEndDate = updatedStartDate.AddDays(updatedNumberOfDays);
        
        bookingToUpdate.Room.RoomId = updatedRoomId;
        bookingToUpdate.StartDate = updatedStartDate;
        bookingToUpdate.EndDate = updatedEndDate;
        bookingToUpdate.BookingId = bookingIdToUpdate;
        
        DbContext.SaveChanges();
    }
}