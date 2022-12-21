using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class UpdateBooking : ICrud
{
    public UpdateBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }
    public int BookingIdToUpdate { get; set; }
    public Booking BookingToUpdate { get; set; }

    public void RunCrud()
    {
        var bookingMethod = new BookingMethod(DbContext);
        BookingPageHeader.UpdateBookingHeader();
        BookingPageHeader.BookingDetailsHeader();
        foreach (var b in DbContext.Bookings.Include(b=>b.Customer)
                                                   .Include(b=>b.Room))
            Console.WriteLine($" {b.BookingId}\t\t{b.Customer.FirstName} {b.Customer.LastName} " +
                              $"\t\t{b.StartDate.ToShortDateString()} - {b.EndDate.ToShortDateString()} " +
                              $"\t{b.Room.RoomId}");
        //ändra formatering på datumen - använd inte toshortdatestring
        //formatering så att bokningarna hamnar under rubriken...
        SelectIdForBookingToUpdate();
        BookingPageHeader.BookingDetailsHeader();
        bookingMethod.BookingDetails(BookingToUpdate);

        var createUpdatedBooking = new CreateBooking(DbContext);
        var continueLoop = true;
        while (continueLoop)
        {
            //gör en meny så anv kan välja vad som kan ändras
            Console.Write("Ange startdatum: ");
            BookingToUpdate.StartDate = ErrorHandling.TryDate();
            Console.Write("Ange antal dagar: ");
            BookingToUpdate.NumberOfDays = ErrorHandling.TryInt();
            //Console.Write("Ange rummets Id: ");
            //BookingToUpdate.Room.RoomId = ErrorHandling.TryInt();
            
            var listOfBookings = new BookingList();
            var availableRoom = new List<Room>();
            bookingMethod.AddAllNewBookingDatesToList(BookingToUpdate, listOfBookings);
            bookingMethod.MakeListOfRoomsFreeForBooking(listOfBookings, availableRoom);
            continueLoop = bookingMethod.IfRoomIsAvailable(availableRoom);
        }

        bookingMethod.AssignRoomToCustomer(BookingToUpdate, DbContext);
        bookingMethod.SuccessfulBooking(BookingToUpdate, "uppdaterad");
        
        var updatedEndDate = BookingToUpdate.StartDate.AddDays(BookingToUpdate.NumberOfDays);
        BookingToUpdate.EndDate = updatedEndDate;

        bookingMethod.SaveBookingToDatabase(BookingToUpdate); //SqlException: Cannot insert explicit
                                                              //value for identity column in table 'Bookings'
                                                              //when IDENTITY_INSERT is set to OFF.
    }
    private void SelectIdForBookingToUpdate()
    {
        Console.Write("\nVälj Id på den bokning du vill uppdatera: ");
        BookingIdToUpdate = Convert.ToInt32(Console.ReadLine());
        BookingToUpdate = DbContext.Bookings
            .First(c => c.BookingId == BookingIdToUpdate);
    }
}