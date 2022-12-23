using HotelBooking.Controllers.CustomerController;
using HotelBooking.Data.Tables;
using HotelBooking.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.PageHeaders;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Security.Principal;

namespace HotelBooking.Controllers.BookingController
{
    public class BookingServices
    {

        public string Line1 = " ------------------------------------------------------" +
                              "-------------------------------------------------------"; 
        
        public ApplicationDbContext DbContext { get; set; }
        public BookingServices(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void SaveNewBookingToDatabase(Booking bookingToCreate)
        {
            DbContext.Add(bookingToCreate);
            DbContext.SaveChanges(); 
            Console.WriteLine("Sparat till databas");
        }

        public List<Room> MakeListOfRoomsFreeForBooking(BookingList listOfBookings, List<Room> availableRoom)
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
            return availableRoom;
        }

        public bool IsRoomFreeForBooking(List<DateTime> listOfBookingDates, Booking bookingToUpdate)
        {
            var roomIsFree = true;
            //går igenom alla bokningar på det rummet som finns i databasen
            foreach (var b in DbContext.Bookings
                         .Include(b => b.Room) //behövs inte??
                         .Where(b => b.Room == bookingToUpdate.Room))
            {
                for (var dt = bookingToUpdate.StartDate; dt <= bookingToUpdate.EndDate; dt = dt.AddDays(1))
                {
                    //om det valda datumet återfinns i listan med bokningar så är rummet bokat 
                    if (listOfBookingDates.Contains(dt))
                    {
                        roomIsFree = false;
                        return roomIsFree;
                    }
                }
               
            }
            return roomIsFree;
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
            int roomIdForBooking = ErrorHandling.TryInt();
            bookingToCreate.Room = DbContext.Rooms.FirstOrDefault(r => r.RoomId == roomIdForBooking);
        }

        public void AssignRoomToCustomer(Booking bookingToCreate, ApplicationDbContext dbContext)
        {
            Console.Clear();
            ReadCustomer readCustomer = new ReadCustomer(dbContext);
            readCustomer.View();
            Console.Write(" Välj kund (ID): ");
            int customerIdForBooking = Convert.ToInt32(Console.ReadLine());
            bookingToCreate.Customer = DbContext.Customers.FirstOrDefault(c => c.CustomerId == customerIdForBooking);
        }
        public void BookingDetails(Booking booking)
        {
            BookingPageHeader.BookingDetailsHeader();
            Console.WriteLine($" {booking.BookingId}\t\t{booking.Customer.FirstName} {booking.Customer.LastName}" +
                              $"\t\t\t{booking.StartDate.ToString("dd MM yyyy")} - {booking.EndDate.ToString("dd MM yyyy")} " +
                              $"\t{booking.NumberOfDays}\t{booking.Room.RoomId}\n");
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

        public List<DateTime> AddAllNewBookingDatesToList(Booking bookingToCreate, BookingList listOfBookings)
        {
            listOfBookings.NewBookingAllDates = new List<DateTime>();
            //   List<DateTime> NewBookingAllDates = new List<DateTime>();

            //börjar på valda startdatumet, loopar igenom alla datum till slutdatumet
            for (var dt = bookingToCreate.StartDate; dt <= bookingToCreate.EndDate; dt = dt.AddDays(1))
            {//lägger den nya bokningens alla datum till en lista
                listOfBookings.NewBookingAllDates.Add(dt);
            }

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
                Console.Write(" Skriv in startdatum för bokningen (yyyy-MM-dd): ");
                bookingToCreate.StartDate = ErrorHandling.TryDate();
               /// DbContext.SaveChanges();
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
}
