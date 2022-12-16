using HotelBooking.Controllers.Interface;
using HotelBooking.Data;

namespace HotelBooking.Controllers.RoomController;

public class ReadRoom : ICrud
{
    public ReadRoom(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        Console.Clear();
        Console.WriteLine("Visa alla rum");
        Console.WriteLine("=============" + Environment.NewLine);
        View();
        Console.WriteLine(Environment.NewLine + "Tryck på enter för att fortsätta");
        Console.ReadKey();
    }

    public void View()
    {
        foreach (var room in DbContext.Rooms)
            Console.WriteLine(
                $"Id{room.RoomId}: {room.Type} {room.SizeSquareMeters}kvadratmeter. " +
                $"Antal gäster: {room.NumberOfGuests}, möjlighet till extra sängar antal: {room.ExtraBed} ");
    }
}