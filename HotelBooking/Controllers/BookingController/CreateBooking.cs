using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.CustomerController;

public class CreateBooking : ICrud
{
    public CreateBooking(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public ApplicationDbContext DbContext { get; set; }
    public void RunCrud()
    {
        BookingPageHeader.CreateBookingHeader();
        var bookingMethod = new BookingController.BookingServices(DbContext);
        var bookingToCreate = new Booking();
        bookingToCreate.NumberOfDays = bookingMethod.GetNumberOfDays();
        bookingMethod.GetStartDate(bookingToCreate);
        bookingMethod.SetEndDate(bookingToCreate);

        var roomsBigEnough = new List<Room>();
        while (true)
        {
            while (true)
            {
                Console.Write(" Hur många gäster vill du boka: ");
                var numberOfGuestsToBook = ErrorHandling.TryInt();
                if (numberOfGuestsToBook >= 5)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(
                        " Det går bara att boka fyra personer i ett rum. Gör en till bokning om antal gäster överstiger fyra. \n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                else
                {
                    bookingToCreate.GuestCount = numberOfGuestsToBook;
                    break;
                }
            }

            //var availableRoomNumberOfGuests = DbContext.Rooms
            //    .Where(r => r.NumberOfGuests > bookingToCreate.GuestCount)
            //    .ToList();
            //return availableRoomNumberOfGuests;
            foreach (var room in DbContext.Rooms)
            {
                if (bookingToCreate.GuestCount <= room.NumberOfGuests)
                    roomsBigEnough.Add(room);
            }

            if (!roomsBigEnough.Any())
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" Det finns inga tillräckligt stora rum lediga. \n");
                Console.ForegroundColor = ConsoleColor.Gray;
            }
            else
                break;
        }

        var listOfBookings = new BookingList();
        bookingMethod.AddAllNewBookingDatesToList(bookingToCreate, listOfBookings);
        
        var availableRoomBothDateAndNumberOfGuests = bookingMethod.MakeListOfRoomsFreeForBooking(listOfBookings, roomsBigEnough);
        bookingMethod.ShowSelectedBookingOptions(bookingToCreate);
        bookingMethod.IfRoomIsAvailable(availableRoomBothDateAndNumberOfGuests);

        bookingMethod.SelectRoomFromListOfAvailableRooms(bookingToCreate,  DbContext);
        bookingMethod.AssignRoomToCustomer(bookingToCreate, DbContext);
        bookingMethod.SaveNewBookingToDatabase(bookingToCreate);
        bookingMethod.SuccessfulBooking(bookingToCreate, "genomförd");
    }
    
  
}