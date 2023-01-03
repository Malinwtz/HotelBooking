using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;

namespace HotelBooking.Controllers.RoomController;

public class ReadRoom : ICrud
{
    public ReadRoom(ApplicationDbContext dbContext) 
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        RoomPageHeader.ReadRoomHeader();
        if (!DbContext.Rooms.Any())
        {
            Console.WriteLine(" Det finns inga rum");
            StringToWrite.PressEnterToContinue();
        }
        else if (DbContext.Rooms.Any())
        {
            View();
            StringToWrite.PressEnterToContinue();
        }
            
    }

    public void View()
    {
        Console.WriteLine(String.Format("{0,-10}{1,-20}{2,-20}{3,-10}", " Id", "Typ/Storlek", "Möjlig extrasäng", "Antal gäster"));
        foreach (var room in DbContext.Rooms)
        {
            Console.WriteLine(String.Format("{0,-10}{1,-20}{2,-20}{3,-10}",
                $"{room.RoomId}", $"{room.Type}, {room.SizeSquareMeters}kvm", $"{room.ExtraBed}", $"{room.NumberOfGuests}"));
        }
        Lines.LineTwoHyphen();
    }
}