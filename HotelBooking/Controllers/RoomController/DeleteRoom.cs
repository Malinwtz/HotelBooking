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
        public RoomService Service { get; set; }

        public DeleteRoom(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void RunCrud()
        {
            RoomPageHeader.DeleteRoomHeader();
                var read = new ReadRoom(DbContext);
                read.View();

               var roomToDelete = Service.GetRoomFromId();

                var listOfBookings = DbContext.Bookings
                    .Where(b => b.Room == roomToDelete)
                    .ToList();

                if (listOfBookings.Any()) 
                {
                    StringToWrite.NotSuccessfulAction(" Det finns en aktiv bokning på rummet. Om du tar bort rummet kommer bokningen att raderas.");
                       
                        var selectedFromDeleteRoomOptions = RoomMenu.MenuDeleteRoomWithBooking();
                    
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
