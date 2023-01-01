using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking.Controllers.BookingController;

public class BookingService
{
    public BookingService(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void SaveNewBookingToDatabase(Booking bookingToCreate)
    {
        DbContext.Add(bookingToCreate);
        DbContext.SaveChanges();
    }

    public List<Room> MakeListOfRoomsFreeForBooking(BookingList listOfBookings, List<Room> availableRoom)
    {
        var availableRoomDateAndNumberOfGuests = new List<Room>();
        foreach (var room in availableRoom)
        {
            var roomIsFree = true;
            foreach (var booking in DbContext.Bookings
                         .Include(b => b.Room)
                         .Where(b => b.Room == room))
            {
                for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                    if (listOfBookings.NewBookingAllDates.Contains(dt))
                        roomIsFree = false;

                if (!roomIsFree) break;
            }

            if (roomIsFree) availableRoomDateAndNumberOfGuests.Add(room);
        }

        return availableRoomDateAndNumberOfGuests;
    }

    public bool IfRoomIsAvailable(List<Room> availableRoom)
    {
        if (availableRoom.Count() < 1)
        {
            RoomIsNotAvailable();
            return true;
        }

        DisplayAvailableRooms(availableRoom);
        return false;
    }

    public void ShowSelectedBookingOptions(Booking booking)
    {
        Console.Clear();
        var method = new BookingService(DbContext);
        Console.WriteLine("\n\n Dina bokningsuppgifter:");
        PageHeader.LineTwo();
        Console.WriteLine(" Startdatum    Slutdatum\tAntal dagar\tAntal gäster");
        Console.WriteLine($" {booking.StartDate.ToString("dd MM yyyy")} " +
                          $"- {booking.EndDate.ToString("dd MM yyyy")} " +
                          $"\t{booking.NumberOfDays}\t\t{booking.GuestCount}");
    }

    public void SelectRoomFromListOfAvailableRooms(Booking bookingToCreate, ApplicationDbContext dbContext)
    {
        Console.Write("\n\n Välj ett rum (ID) från tillgängliga rum: ");
        var roomIdForBooking = ErrorHandling.TryInt();
        bookingToCreate.Room = DbContext.Rooms.FirstOrDefault(r => r.RoomId == roomIdForBooking);
    }

    public void AssignRoomToCustomer(Booking bookingToAssignCustomerTo, ApplicationDbContext dbContext)
    {
        Console.Clear();
        var readCustomer = new ReadCustomer(dbContext);
        readCustomer.View();
        Console.Write(" Välj kund (ID): ");
        var customerIdForBooking = ErrorHandling.TryInt();
        bookingToAssignCustomerTo.Customer = DbContext.Customers
            .Where(c => c.Active == true)
            .FirstOrDefault(c => c.CustomerId == customerIdForBooking);
    }

    public void BookingDetails(Booking booking)
    {
        Console.WriteLine($" {booking.BookingId}\t\t\t{booking.StartDate.ToString("dd MM yyyy")} - {booking.EndDate.ToString("dd MM yyyy")} " +
                          $"\t{booking.NumberOfDays}\t{booking.GuestCount}\t{booking.Room.RoomId}\t\t\t{booking.Customer.FirstName} {booking.Customer.LastName}\n");
    }

   

    public List<DateTime> AddAllNewBookingDatesToList(Booking bookingToCreate, BookingList listOfBookings)
    {
        listOfBookings.NewBookingAllDates = new List<DateTime>();
        for (var dt = bookingToCreate.StartDate; dt <= bookingToCreate.EndDate; dt = dt.AddDays(1))
            listOfBookings.NewBookingAllDates.Add(dt);

        return listOfBookings.NewBookingAllDates;
    }

    public void SetEndDate(Booking bookingToCreate)
    {
        if (bookingToCreate.NumberOfDays == 1)
            bookingToCreate.EndDate = bookingToCreate.StartDate;
        else if (bookingToCreate.NumberOfDays > 1)
            bookingToCreate.EndDate = bookingToCreate.StartDate.AddDays(bookingToCreate.NumberOfDays);
    }

    public void RoomDetails(Room room)
    {
        Console.WriteLine($" {room.RoomId}\t\t{room.Type}\t\t{room.SizeSquareMeters}" +
                          $"\t\t{room.NumberOfGuests}\t\t\t\t{room.ExtraBed}");
    }

    public void DisplayAvailableRooms(List<Room> availableRoom)
    {
        BookingPageHeader.AvailableRoomHeader();
        foreach (var room in availableRoom.OrderBy(r => r.RoomId)) RoomDetails(room);
    }

    public void GetStartDate(Booking bookingToCreate)
    {
        bookingToCreate.StartDate = new DateTime(2001, 01, 01, 23, 59, 59);
        while (bookingToCreate.StartDate < DateTime.Now.Date)
        {
            Console.Write(" Skriv in startdatum för bokningen (yyyy-MM-dd): ");
            bookingToCreate.StartDate = ErrorHandling.TryDate();
        }
    }

    public int GetNumberOfDays()
    {
        Console.WriteLine("Skriv in hur många dagar du vill boka: ");
        return ErrorHandling.TryInt();
    }

    public void RoomIsNotAvailable()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n Det finns inga tillgängliga rum för dessa datum. Prova ett annat datum");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" Tryck på enter för att fortsätta");
        Console.ReadLine();
    }
}