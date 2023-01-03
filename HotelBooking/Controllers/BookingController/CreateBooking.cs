using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

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
        var bookingService = new BookingService(DbContext);
        var bookingToCreate = new Booking();
        bookingToCreate.NumberOfDays = bookingService.GetNumberOfDays();
        bookingService.GetStartDate(bookingToCreate);
        bookingService.SetEndDate(bookingToCreate);
        var roomsBigEnough = new List<Room>();
        while (true)
        {
            SetNumberOfGuestsToBook(bookingToCreate);
            roomsBigEnough = DbContext.Rooms.Where(r => r.NumberOfGuests >= bookingToCreate.GuestCount).ToList();

            if (!roomsBigEnough.Any())
            {
                StringToWrite.NotSuccessfulAction(" Det finns inga tillräckligt stora rum lediga.");
            }
            else
            {
                break;
            }
        }

        var listOfBookings = new BookingList();
        bookingService.AddAllNewBookingDatesToList(bookingToCreate, listOfBookings);
        var availableRoomBothDateAndNumberOfGuests = bookingService.MakeListOfRoomsFreeForBooking(listOfBookings, roomsBigEnough);
        bookingService.ShowSelectedBookingOptions(bookingToCreate);
        bookingService.IfRoomIsAvailable(availableRoomBothDateAndNumberOfGuests);
        bookingService.SelectRoomFromListOfAvailableRooms(bookingToCreate, DbContext);
        bookingService.AssignRoomToCustomer(bookingToCreate, DbContext);
        bookingService.SaveNewBookingToDatabase(bookingToCreate);
        StringToWrite.SuccessfulAction("Bokning genomförd");
    }

    private void SetNumberOfGuestsToBook(Booking bookingToCreate)
    {
        while (true)
        {
            Console.Write(" Hur många gäster vill du boka: ");
            var numberOfGuestsToBook = ErrorHandling.TryInt();
            if (numberOfGuestsToBook >= 5)
            {
                StringToWrite.NotSuccessfulAction(
                    " Det går bara att boka fyra personer i ett rum. Gör en till bokning om antal gäster överstiger fyra.");
            }
            else
            {
                bookingToCreate.GuestCount = numberOfGuestsToBook;
                return;
            }
        }
    }
}