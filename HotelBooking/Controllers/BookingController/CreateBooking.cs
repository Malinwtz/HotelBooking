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
        var numberOfDays = GetNumberOfDays();

        //undvik DaisyChain till olika metoder. 

        // Keep asking for a valid date in the future ---> egen metod GetStartDate
        bookingToCreate.StartDate = new DateTime(2001, 01, 01, 23, 59, 59);
        while (bookingToCreate.StartDate < DateTime.Now.Date)
        {
           GetStartDate(bookingToCreate);
        }

        // set dateEnd
        if (numberOfDays == 1) bookingToCreate.EndDate = bookingToCreate.StartDate;
        else if (numberOfDays > 1) bookingToCreate.EndDate = bookingToCreate.StartDate.AddDays(numberOfDays);

        // Now we need to create a list of available cars for the user to choose from.
        // Lets start by making a list of ALL the dates included in the new booking
        List<DateTime> newBookingAllDates = new List<DateTime>();
        for (var dt = bookingToCreate.StartDate; dt <= bookingToCreate.EndDate; dt = dt.AddDays(1))
        {
            newBookingAllDates.Add(dt);
        }

        // Lets loop through all the cars in the system 
        // and check if they have booking dates that block our new booking,
        List<Room> availableRoom = new List<Room>();

        foreach (var car in DbContext.Rooms.ToList())
        {
            bool carIsFree = true;
            foreach (var booking in DbContext.Bookings
                                            .Include(b => b.RoomBooking)
                                            .Where(b => b.RoomBooking == car))
            {
                for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                {
                    if (newBookingAllDates.Contains(dt))
                    {
                        carIsFree = false;

                    }
                }

                // if the car is already booked on the date of the new booking...
                // we dont need to check any of the other bookings... the car isnt available
                // so we break out of the loop and check the next car
                if (!carIsFree)
                {
                    break;
                }
            }


            // finally if the car is free we can add it to our list of available cars
            if (carIsFree)
            {
                availableRoom.Add(car);
            }
        }

        // Lets show the bookings details
        Console.Clear();
        Console.WriteLine(" Your booking details");
        Console.WriteLine(" ==================================================================");
        Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
        Console.WriteLine($" {bookingToCreate.StartDate.ToShortDateString()}\t{bookingToCreate.EndDate.ToShortDateString()}\t{numberOfDays}");

        // FAIL! Display if no avaialable cars
        if (availableRoom.Count() < 1)
        {
            RoomIsNotAvailable();
        }
        else
        {
            DisplayAvailableRooms(availableRoom);
        }

        // Assign the car the user chose to the booking 
        Console.WriteLine("\n Please choose a car (license plate) from the available cars");
        string roomsForBooking = Console.ReadLine();
        bookingToCreate.RoomBooking = DbContext.Rooms
            .Where(c => c.RoomId == roomsForBooking)
        .FirstOrDefault();

        DbContext.Add(bookingToCreate);
        DbContext.SaveChanges(); //kom ihåg!!!!!

        // SUCCESS!
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Clear();
        Console.WriteLine(" Booking successful!");
        Console.WriteLine(" ==============================================================================");
        Console.WriteLine(" Start\t\tEnd\t\tNo. of days");
        Console.WriteLine($" {bookingToCreate.StartDate.ToShortDateString()}\t{bookingToCreate.EndDate.ToShortDateString()}\t{numberOfDays}");
        Console.ForegroundColor = ConsoleColor.Gray;

        Console.WriteLine("\n Press any key to continue");
        Console.ReadLine();
    }

    private void DisplayAvailableRooms(List<Room> availableRoom)
    {
        Console.WriteLine("\n\n\n These rooms are available for booking");
        Console.WriteLine("\n License Plate\tMake\t\tModel");
        Console.WriteLine(" ==================================================================");

        foreach (var room in availableRoom.OrderBy(r => r.RoomId))
        {
            Console.WriteLine($" {room.Type}\t\t{room.SizeSquareMeters}\t\t{room.NumberOfGuests}");
            Console.WriteLine(" ------------------------------------------------------------------");
        }
    }

    private void GetStartDate(Booking bookingToCreate)
    {
        Console.Write("Skriv in startdatum för bokningen: ");
        bookingToCreate.StartDate = Convert.ToDateTime(Console.ReadLine());
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