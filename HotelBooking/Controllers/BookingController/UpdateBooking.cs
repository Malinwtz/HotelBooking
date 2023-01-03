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
        var bookingService = new BookingService(DbContext);
        BookingPageHeader.UpdateBookingHeader();

        if (!DbContext.Bookings.Any())
        {
            Console.WriteLine(" Det finns inga bokningar");
        }
        else if (DbContext.Bookings.Any())
        {
            var read = new ReadBooking(DbContext);
            read.View();
            SelectBookingToUpdate();
            
            while (true)
            {
                BookingPageHeader.BookingDetailsHeader();
                bookingService.BookingDetails(BookingToUpdate);
                var selectionUpdateBookingMenu = BookingMenu.UpdateBookingMenuShowAndReturnSelection();
                if (selectionUpdateBookingMenu == 0)
                    break;
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
                                newStartDate = GetUpdatedStartDate();
                                newNumberOfDays = bookingService.GetNumberOfDays();
                                newEndDate = SetUpdatedEndDate(newNumberOfDays, newEndDate, newStartDate);
                                var listOfBookingDates = MakeListOfBookingDates(newStartDate, newEndDate);
                                roomIsFree = IfRoomIsFree(listOfBookingDates);
                                if (roomIsFree == true) break;
                            }
                            SetPropertiesToBooking(newStartDate, newEndDate, newNumberOfDays);
                            DbContext.SaveChanges();
                            StringToWrite.SuccessfulAction(" Bokningen är uppdaterad!");
                            break;
                        }
                    case 2:
                        {
                            bookingService.AssignRoomToCustomer(BookingToUpdate, DbContext);
                            DbContext.SaveChanges();
                            StringToWrite.SuccessfulAction(" Bokningen är uppdaterad!");
                            break;
                        }
                    case 3:
                        {
                            var roomsBigEnough = GetListOfRoomsBigEnough();
                            if (!roomsBigEnough.Any())
                            {
                                StringToWrite.NotSuccessfulAction(" Det finns inga tillräckligt stora rum lediga.");
                                StringToWrite.PressEnterToContinue();
                            }
                            else if (roomsBigEnough.Any())
                            {
                                var listOfBookings = new BookingList();
                                bookingService.AddAllNewBookingDatesToList(BookingToUpdate, listOfBookings);
                                var availableRoomBothDateAndNumberOfGuests =
                                    bookingService.MakeListOfRoomsFreeForBooking(listOfBookings, roomsBigEnough);
                                bookingService.ShowSelectedBookingOptions(BookingToUpdate);
                                var availableRoomBool = bookingService.IfRoomIsAvailable(availableRoomBothDateAndNumberOfGuests);
                                if (availableRoomBool == true)
                                {
                                    bookingService.SelectRoomFromListOfAvailableRooms(BookingToUpdate, DbContext);
                                    DbContext.SaveChanges();
                                    StringToWrite.SuccessfulAction(" Bokningen är uppdaterad!");
                                }
                            }
                            break;
                        }
                }
            }
        }
    }

    private static List<DateTime> MakeListOfBookingDates(DateTime newStartDate, DateTime newEndDate)
    {
        var listOfBookingDates = new List<DateTime>();
        for (var dt = newStartDate; dt <= newEndDate; dt = dt.AddDays(1))
            listOfBookingDates.Add(dt);
        return listOfBookingDates;
    }

    private static DateTime SetUpdatedEndDate(int newNumberOfDays, DateTime newEndDate, DateTime newStartDate)
    {
        if (newNumberOfDays == 1)
            newEndDate = newStartDate;
        else if (newNumberOfDays > 1)
            newEndDate = newStartDate.AddDays(newNumberOfDays - 1);
        return newEndDate;
    }

    private void SetPropertiesToBooking(DateTime newStartDate, DateTime newEndDate, int newNumberOfDays)
    {
        BookingToUpdate.StartDate = newStartDate;
        BookingToUpdate.EndDate = newEndDate;
        BookingToUpdate.NumberOfDays = newNumberOfDays;
    }

    private List<Room> GetListOfRoomsBigEnough()
    {
        var roomsBigEnough = new List<Room>();

        foreach (var room in DbContext.Rooms)
            if (BookingToUpdate.GuestCount <= room.NumberOfGuests)
                roomsBigEnough.Add(room);
        return roomsBigEnough;
    }

    private static DateTime GetUpdatedStartDate()
    {
        DateTime newStartDate;
        Console.Clear();
        Console.Write(" Skriv in nytt startdatum: ");
        newStartDate = ErrorHandling.TryDate();
        return newStartDate;
    }

    private bool IfRoomIsFree(List<DateTime> listOfBookingDates)
    {
        var roomIsFree = true;
        foreach (var b in DbContext.Bookings
                     .Include(b => b.Room)
                     .Where(b => b.Room == BookingToUpdate.Room))
            for (var dt = b.StartDate; dt <= b.EndDate; dt = dt.AddDays(1))
                if (listOfBookingDates.Contains(dt))
                {
                    StringToWrite.NotSuccessfulAction(" Rummet är redan bokat! Prova ett annat datum");
                    StringToWrite.PressEnterToContinue();
                    roomIsFree = false;
                    return roomIsFree;
                }
        return roomIsFree;
    }

    private void SelectBookingToUpdate()
    {
        Console.Write("\n\n Välj Id på den bokning du vill uppdatera: ");
        var selectId = ErrorHandling.TryInt();
        BookingToUpdate = DbContext.Bookings
            .First(c => c.BookingId == selectId);
    }
}