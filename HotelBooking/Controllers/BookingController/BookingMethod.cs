using HotelBooking.Controllers.CustomerController;
using HotelBooking.Data.Tables;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.PageHeaders;

namespace HotelBooking.Controllers.BookingController
{
    public class BookingMethod
    {

        public string Line1 = " ------------------------------------------------------" +
                              "-------------------------------------------------------"; 
        public string Line2 = " ======================================================" +
                             "=======================================================";

        public ApplicationDbContext DbContext { get; set; }
        public BookingMethod(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void SaveBookingToDatabase(Booking bookingToCreate)
        {
            DbContext.Add(bookingToCreate);
            DbContext.SaveChanges();
        }

        public void MakeListOfRoomsFreeForBooking(BookingList listOfBookings, List<Room> availableRoom)
        {
            foreach (var room in DbContext.Rooms)
            {
                bool roomIsFree = true;
                //går igenom alla bokningar som finns i databasen
                foreach (var booking in DbContext.Bookings
                             .Include(b => b.Room)
                             .Where(b => b.Room == room))
                {
                    for (var dt = booking.StartDate; dt <= booking.EndDate; dt = dt.AddDays(1))
                    {//om det valda datumet återfinns i listan med bokningar så är rummet bokat 
                        if (listOfBookings.NewBookingAllDates.Contains(dt))
                        {
                            roomIsFree = false;
                        }
                    }//loopen börjar om från början med nästa rum
                    if (!roomIsFree)
                    {
                        break;
                    }
                }//om rummet är ledigt läggs det till i den nya listan med lediga rum
                if (roomIsFree)
                {
                    availableRoom.Add(room);
                }
            }
        }

        public bool IfRoomIsAvailable(List<Room> availableRoom)
        {
            if (availableRoom.Count() < 1)
            {
                RoomIsNotAvailable();
                return true;
            }
            else
            {
                DisplayAvailableRooms(availableRoom);
                return false;
            }
        }

        public void SelectRoomFromListOfAvailableRooms(Booking bookingToCreate, ApplicationDbContext dbContext)
        {
            Console.Write("\n\n Välj ett rum (ID) från tillgängliga rum: ");
            int roomIdForBooking = Convert.ToInt32(Console.ReadLine());
            bookingToCreate.Room = DbContext.Rooms.FirstOrDefault(r => r.RoomId == roomIdForBooking);
            ReadCustomer readCustomer = new ReadCustomer(dbContext);
            readCustomer.View();
        }

        public void AssignRoomToCustomer(Booking bookingToCreate, ApplicationDbContext dbContext)
        {
            Console.Write("Välj kund (ID): ");
            int customerIdForBooking = Convert.ToInt32(Console.ReadLine());
            bookingToCreate.Customer = DbContext.Customers.FirstOrDefault(c => c.CustomerId == customerIdForBooking);
        }
        public void BookingDetails(Booking booking)
        {
            Console.WriteLine($" {booking.BookingId}\t\t{booking.Customer.FirstName} {booking.Customer.LastName}" +
                              $"\t\t\t{booking.StartDate.ToString("dd MM yyyy")} - {booking.EndDate.ToString("dd MM yyyy")} " +
                              $"\t{booking.NumberOfDays}\t{booking.Room.RoomId}");
        }
        public void SuccessfulBooking(Booking booking, string text)
        {
            Console.Clear(); 
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($" Bokning {text}!");
            BookingDetails(booking);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("\n Tryck på enter för att fortsätta");
            Console.ReadLine();
        }

        public void AddAllNewBookingDatesToList(Booking bookingToCreate, BookingList listOfBookings)
        {
            listOfBookings.NewBookingAllDates = new List<DateTime>();
            //   List<DateTime> NewBookingAllDates = new List<DateTime>();

            //börjar på valda startdatumet, loopar igenom alla datum till slutdatumet
            for (var dt = bookingToCreate.StartDate; dt <= bookingToCreate.EndDate; dt = dt.AddDays(1))
            {//lägger den nya bokningens alla datum till en lista
                listOfBookings.NewBookingAllDates.Add(dt);
            }
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
                              $"\t\t{room.NumberOfGuests}\t\t\t{room.ExtraBed}");
        }
        public void DisplayAvailableRooms(List<Room> availableRoom)
        {
            BookingPageHeader.AvailableRoomHeader();
            foreach (var room in availableRoom.OrderBy(r => r.RoomId))
            {
                RoomDetails(room);
            }
        }

        public void GetStartDate(Booking bookingToCreate)
        {
            bookingToCreate.StartDate = new DateTime(2001, 01, 01, 23, 59, 59);
            while (bookingToCreate.StartDate < DateTime.Now.Date)
            {
                Console.Write("Skriv in startdatum för bokningen: ");
                bookingToCreate.StartDate = Convert.ToDateTime(Console.ReadLine());
            }
        }
        public int GetNumberOfDays()
        {
            Console.WriteLine("Skriv in hur många dagar du vill boka: ");
            return Convert.ToInt32(Console.ReadLine());
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
}
