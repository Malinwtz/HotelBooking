using HotelBooking.Data;

namespace HotelBooking.Controllers.Read;

public class ReadRoom : ICrud
{
    public ReadRoom(ApplicationDbContext dbContext) //skicka in dbcontext i ctor eller in run metod?
    {
        DatabaseContext = dbContext;
    }

    public ApplicationDbContext DatabaseContext { get; set; }

    public void RunCrud()
    {
        using (DatabaseContext)
        {
            Console.WriteLine("Visa alla rum");
            Console.WriteLine("=============");
            View();
        }
    }

    public void View()
    {
        foreach (var room in DatabaseContext.Rooms)
            Console.WriteLine(
                $"Id{room.RoomId}: {room.Type} {room.Size}kvadratmeter. " +
                $"Antal gäster: {room.NumberOfGuests}, möjlighet till extra sängar antal: {room.ExtraBed} ");
    }
}