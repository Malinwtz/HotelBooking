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
        foreach (var room in DbContext.Rooms)
        {
            Service.ShowAllRoomDetails(room);
        }
        Console.WriteLine(Environment.NewLine);
    }
}