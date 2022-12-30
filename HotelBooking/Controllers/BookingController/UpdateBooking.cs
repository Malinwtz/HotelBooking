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
    public Booking BookingToUpdate { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        var bookingMethod = new BookingService(DbContext);
        BookingPageHeader.UpdateBookingHeader();
        BookingPageHeader.BookingDetailsHeader();
        foreach (var b in DbContext.Bookings.Include(b => b.Customer)
                     .Include(b => b.Room))
            Console.WriteLine($" {b.BookingId}\t\t{b.Customer.FirstName} {b.Customer.LastName} " +
                              $"\t\t{b.StartDate.ToString("dd MM yyyy")} - {b.EndDate.ToString("dd MM yyyy")} " +
                              $"\t{b.Room.RoomId}");

        SelectBookingToUpdate();
        BookingPageHeader.BookingDetailsHeader();
        bookingMethod.BookingDetails(BookingToUpdate);

        var selectionUpdateBookingMenu = BookingMenu.UpdateBookingMenuShowAndReturnSelection();
        switch (selectionUpdateBookingMenu)
        {
            case 1:
            {
                var newStartDate = DateTime.Now;
                var newEndDate = DateTime.Now;
                var newNumberOfDays = 0;
                var roomIsFree = false;
                while (!roomIsFree)
                {
                    Console.Clear();
                    //header ändra bokningens datum
                    Console.Write(" Skriv in nytt startdatum: "); //kolla så datum är i framtiden
                    newStartDate = ErrorHandling.TryDate();
                    Console.Write(" Skriv in antal dagar du vill boka: ");
                    newNumberOfDays = ErrorHandling.TryInt();
                    newEndDate = DateTime.Now;
                    if (newNumberOfDays == 1)
                        newEndDate = newStartDate;
                    else if (newNumberOfDays > 1)
                        newEndDate = newStartDate.AddDays(newNumberOfDays - 1);

                    //LOOPAR IGENOM DE UPPDATERADE DATUMEN OCH LÄGGER IN DEM I EN DATUMLISTA
                    var listOfBookingDates = new List<DateTime>();
                    for (var dt = newStartDate; dt <= newEndDate; dt = dt.AddDays(1))
                        listOfBookingDates.Add(dt);

                    //HITTAR OCH GÅR IGENOM ALLA bokningar SOM FINNS PÅ RUMMET
                    roomIsFree = IfRoomIsFree(listOfBookingDates);
                }

                BookingToUpdate.StartDate = newStartDate;
                BookingToUpdate.EndDate = newEndDate;
                BookingToUpdate.NumberOfDays = newNumberOfDays;
                break;
            }
            case 2:
            {
                bookingMethod.AssignRoomToCustomer(BookingToUpdate, DbContext);
                break;
            }
            case 3: //ÄNDRA RUM
            {
                var roomsBigEnough = new List<Room>();

                foreach (var room in DbContext.Rooms)
                    if (BookingToUpdate.GuestCount <= room.NumberOfGuests)
                        roomsBigEnough.Add(room);

                if (!roomsBigEnough.Any())
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Det finns inga tillräckligt stora rum lediga. \n");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
                }

                if (roomsBigEnough.Any())
                {
                    var listOfBookings = new BookingList();
                    bookingMethod.AddAllNewBookingDatesToList(BookingToUpdate, listOfBookings);

                    var availableRoomBothDateAndNumberOfGuests =
                        bookingMethod.MakeListOfRoomsFreeForBooking(listOfBookings, roomsBigEnough);
                    bookingMethod.ShowSelectedBookingOptions(BookingToUpdate);
                    bookingMethod.IfRoomIsAvailable(availableRoomBothDateAndNumberOfGuests);

                    bookingMethod.SelectRoomFromListOfAvailableRooms(BookingToUpdate, DbContext);
                }

                break;
            }
        }

        DbContext.SaveChanges();
        bookingMethod.SuccessfulBooking(BookingToUpdate, "uppdaterad");
    }

    private bool IfRoomIsFree(List<DateTime> listOfBookingDates)
    {
        var roomIsFree = true;
        foreach (var b in DbContext.Bookings
                     .Include(b => b.Room) //behövs inte??
                     .Where(b => b.Room == BookingToUpdate.Room))
            //FÖR VARJE BOKNING SOM FINNS - KOLLA OM BOKNINGENS DATUM FINNS I DATUMLISTAN MED DE NYA DATUMEN
            for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                //OM RUMMET ÄR BOKAT NÅGON AV DATUMEN SOM FINNS I LISTAN SÅ GÅR INTE RUMMET ATT BOKA
                if (listOfBookingDates.Contains(dt))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Rummet är redan bokat! Prova ett annat datum");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    roomIsFree = false;
                    return roomIsFree;
                }

        return roomIsFree;
    }

    private void SelectBookingToUpdate()
    {
        Console.Write("\n\nVälj Id på den bokning du vill uppdatera: ");
        var selectId = ErrorHandling.TryInt();
        BookingToUpdate = DbContext.Bookings
            .First(c => c.BookingId == selectId);
    }
}