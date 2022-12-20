using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.Interface;
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
        var bookingToCreate = new Booking();
        bookingToCreate.NumberOfDays = GetNumberOfDays();
        GetStartDate(bookingToCreate);
        SetEndDate(bookingToCreate);
        var listOfBookings = new BookingList();
        ShowListOfRooms(bookingToCreate, listOfBookings);
        List<Room> availableRoom = new List<Room>();
        CheckIfRoomIsAlreadyBooked(listOfBookings, availableRoom);
        ShowBookingDetails(bookingToCreate);
        DisplayIfRoomIsAvailable(availableRoom);
        AssignRoomToCustomer(bookingToCreate);
        SuccessfulBooking(bookingToCreate);
    }

    private void CheckIfRoomIsAlreadyBooked(BookingList listOfBookings, List<Room> availableRoom)
    {
        foreach (var room in DbContext.Rooms.ToList())
        {
            bool roomIsFree = true;
            foreach (var booking in DbContext.Bookings
                         .Include(b => b.RoomBooking)
                         .Where(b => b.RoomBooking == room))
            {
                for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                {
                    if (listOfBookings.newBookingAllDates.Contains(dt))
                    {
                        roomIsFree = false;
                    }
                }

                // if the car is already booked on the date of the new booking...
                // we dont need to check any of the other bookings... the car isnt available
                // so we break out of the loop and check the next car
                if (!roomIsFree)
                {
                    break;
                }
            }

            // finally if the car is free we can add it to our list of available cars
            if (roomIsFree)
            {
                availableRoom.Add(room);
            }
        }
    }

    private void DisplayIfRoomIsAvailable(List<Room> availableRoom)
    {
        if (availableRoom.Count() < 1)
        {
            RoomIsNotAvailable();
        }
        else
        {
            DisplayAvailableRooms(availableRoom);
        }
    }

    private void AssignRoomToCustomer(Booking bookingToCreate)
    {
        Console.WriteLine("\n Välj ett rum (ID) från tillgängliga rum");
        int roomsForBooking = Convert.ToInt32(Console.ReadLine());
        bookingToCreate.RoomBooking = DbContext.Rooms.FirstOrDefault(r => r.RoomId == roomsForBooking);
            //.Where(c => c.RoomId == roomsForBooking)
            //.FirstOrDefault();


            //skriv in alla andra prop för booking
        DbContext.Add(bookingToCreate);
        DbContext.SaveChanges(); 
    }

    private void ShowBookingDetails(Booking bookingToCreate)
    {
        Console.Clear();
        Console.WriteLine(" Your booking details");
        Console.WriteLine(" ==================================================================");
        Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
        Console.WriteLine($" {bookingToCreate.StartDate.ToShortDateString()}" +
                          $"\t{bookingToCreate.EndDate.ToShortDateString()}" +
                          $"\t{bookingToCreate.NumberOfDays}");
    }

    private void SuccessfulBooking(Booking bookingToCreate)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(" Booking successful!");
        Console.WriteLine(" ==============================================================================");
        Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
        Console.WriteLine($" {bookingToCreate.StartDate.ToShortDateString()}" +
                          $"\t{bookingToCreate.EndDate.ToShortDateString()}" +
                          $"\t{bookingToCreate.NumberOfDays}");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("\n Press any key to continue");
        Console.ReadLine();
    }

    private void ShowListOfRooms(Booking bookingToCreate, BookingList listOfBookings)
    {
        listOfBookings.newBookingAllDates = new List<DateTime>();
     //   List<DateTime> newBookingAllDates = new List<DateTime>();
        for (var dt = bookingToCreate.StartDate; dt <= bookingToCreate.EndDate; dt = dt.AddDays(1))
        {
            listOfBookings.newBookingAllDates.Add(dt);
        }
    }

    private void SetEndDate(Booking bookingToCreate)
    {
        if (bookingToCreate.NumberOfDays == 1) 
            bookingToCreate.EndDate = bookingToCreate.StartDate;
        else if (bookingToCreate.NumberOfDays > 1) 
            bookingToCreate.EndDate = bookingToCreate.StartDate.AddDays(bookingToCreate.NumberOfDays);
    }

    private void DisplayAvailableRooms(List<Room> availableRoom)
    {
        Console.WriteLine("\n\n\n These rooms are available for booking");
        Console.WriteLine("\nId\tType\t\tSize\tNumberOfGuests");
        Console.WriteLine(" ==================================================================");

        foreach (var room in availableRoom.OrderBy(r => r.RoomId))
        {
            Console.WriteLine($" {room.RoomId}\t{room.Type}\t\t{room.SizeSquareMeters}\t\t{room.NumberOfGuests}");
            Console.WriteLine(" ------------------------------------------------------------------");
        }
    }

    private void GetStartDate(Booking bookingToCreate)
    {
        bookingToCreate.StartDate = new DateTime(2001, 01, 01, 23, 59, 59);
        while (bookingToCreate.StartDate < DateTime.Now.Date)
        {
            Console.Write("Skriv in startdatum för bokningen: ");
            bookingToCreate.StartDate = Convert.ToDateTime(Console.ReadLine());
        }
    }
    private int GetNumberOfDays()
    {
        Console.WriteLine("Skriv in hur många dagar du vill boka: ");
        return Convert.ToInt32(Console.ReadLine());
    }

    private void RoomIsNotAvailable()
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\n\n There are no cars available for these dates. Please try another date");
        Console.ForegroundColor = ConsoleColor.Gray;
        Console.WriteLine(" Press any key to continue");
        Console.ReadLine();
    }
}