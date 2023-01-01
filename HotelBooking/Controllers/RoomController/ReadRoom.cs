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
    public RoomService Service = new RoomService();

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine(" Visa alla rum");
        PageHeader.LineOne();
        View();
        PageHeader.LineTwo();
        StringToWrite.PressEnterToContinue();
    }

    public void View()
    {
        Console.WriteLine(String.Format("{0,-10}{1,-20}{2,-20}{3,-10}", " Id", "Typ/Storlek", "Möjlig extrasäng", "Antal gäster"));
        foreach (var room in DbContext.Rooms)
        {
            Console.WriteLine(String.Format("{0,-10}{1,-20}{2,-20}{3,-10}",
                $"{room.RoomId}", $"{room.Type}, {room.SizeSquareMeters}kvm", $"{room.ExtraBed}", $"{room.NumberOfGuests}"));
        }
        Console.WriteLine(Environment.NewLine);
    }
}