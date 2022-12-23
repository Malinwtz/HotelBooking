using System.Threading.Channels;
using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class UpdateRoom : ICrud
{
    public UpdateRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }
    public ApplicationDbContext DbContext { get; set; }
    public RoomService Service = new RoomService();
    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine(" ÄNDRA RUM");
        PageHeader.LineOne();
            foreach (var room in DbContext.Rooms)
                Service.ShowAllRoomDetails(room);
        PageHeader.LineTwo();
        
        Console.Write(" Välj Id på det rum du vill uppdatera: "); 
        var roomIdToUpdate = Convert.ToInt32(Console.ReadLine()); 
        var roomToUpdate = DbContext.Rooms.First(c => c.RoomId == roomIdToUpdate);
        
        Console.Clear();
        Console.Write(" Uppdatera rummets storlek: ");
        roomToUpdate.SizeSquareMeters = ErrorHandling.TryInt();
        
        Service.SetPropertyTypeToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
        Service.SetPropertyExtraBedToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
        Service.SetPropertyNumberOfGuestsToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);

        DbContext.SaveChanges();

        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Rummet ändrat!");
        Service.ShowAllRoomDetails(roomToUpdate);
        Console.ForegroundColor = ConsoleColor.Gray;
        StringToWrite.PressEnterToContinue();
    }
}