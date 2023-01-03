using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class DeleteRoom : ICrud
{
    public DeleteRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public Room RoomToDelete { get; set; }
    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        RoomPageHeader.DeleteRoomHeader();
        var read = new ReadRoom(DbContext);
        read.View();
        RoomToDelete = GetRoomById();
        var listOfBookings = DbContext.Bookings
            .Where(b => b.Room == RoomToDelete)
            .ToList();

        if (listOfBookings.Any())
        {
            StringToWrite.NotSuccessfulAction(
                " Det finns en aktiv bokning på rummet. Om du tar bort rummet kommer bokningen att raderas.");

            var selectedFromDeleteRoomOptions = RoomMenu.MenuDeleteRoomWithBooking();
            switch (selectedFromDeleteRoomOptions)
            {
                case 1:
                {
                    DeleteRoomFromDatabase(RoomToDelete);
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
            DeleteRoomFromDatabase(RoomToDelete);
        }
    }

    private Room GetRoomById()
    {
        while (true)
        {
            Console.Write(" Välj rum genom att skriva in Id: ");
            var roomId = ErrorHandling.TryInt();
            var room = DbContext.Rooms.FirstOrDefault(c => c.RoomId == roomId);
            if (room != null) return room;
        }
    }

    private void DeleteRoomFromDatabase(Room? roomToDelete)
    {
        DbContext.Rooms.Remove(roomToDelete);
        DbContext.SaveChanges();
        StringToWrite.SuccessfulAction(" Rum borttaget!");
    }
}