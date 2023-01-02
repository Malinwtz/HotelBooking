using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;
using Microsoft.Extensions.Options;

namespace HotelBooking.Controllers.RoomController
{
    public class DeleteRoom : ICrud
    {
        public ApplicationDbContext DbContext { get; set; }

        public DeleteRoom(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void RunCrud()
        {
            Console.Clear();
                Console.WriteLine(" Ta bort ett rum");
                PageHeader.LineOne();

                var read = new ReadRoom(DbContext);
                read.View();

                Console.Write(" Välj Id på det rum som du vill ta bort");
                var roomIdToDelete = Convert.ToInt32(Console.ReadLine());
                var roomToDelete = DbContext.Rooms.FirstOrDefault(p => p.RoomId == roomIdToDelete);

                var listOfBookings = DbContext.Bookings
                    .Where(b => b.Room == roomToDelete)
                    .ToList();

                if (listOfBookings.Any()) 
                {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine(" Det finns en aktiv bokning på rummet. Om du tar bort rummet kommer bokningen att raderas.");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine("\n 1. Ta bort rum");
                        Console.WriteLine(" 2. Fortsätt utan att ta bort rum");
                        var selectedFromDeleteRoomOptions = ErrorHandling.TryInt();
                        Console.Clear();
                        switch (selectedFromDeleteRoomOptions)
                        {
                            case 1:
                            {
                                DeleteRoomFromDatabase(roomToDelete);
                                break;
                            }
                            case 2:
                            {

                                break;
                            }
                        }
                }
                else if (!listOfBookings.Any())
                {
                    DeleteRoomFromDatabase(roomToDelete);
                }
        }

        private void DeleteRoomFromDatabase(Room? roomToDelete)
        {
            DbContext.Rooms.Remove(roomToDelete);
            DbContext.SaveChanges();
            StringToWrite.SuccessfulAction(" Rum borttaget!");
        }
    }
}
