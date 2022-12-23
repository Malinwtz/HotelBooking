using HotelBooking.Controllers.ErrorController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class CreateRoom : ICrud
{
    public CreateRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public RoomService Service = new RoomService();

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        var newRoom = new Room();

        RegisterNewRoomHeader();

        var sizeInput = Service.GetSizeSquareMetersInput(newRoom);

        Service.SetPropertyTypeToRoomBySizeInput(sizeInput, newRoom);
        Service.SetPropertyExtraBedToRoomBySizeInput(sizeInput, newRoom);
        Service.SetPropertyNumberOfGuestsToRoomBySizeInput(sizeInput, newRoom);

        DbContext.Rooms.Add(newRoom);
        DbContext.SaveChanges();

        SuccessfullyCreatedNewRoom(newRoom);
        StringToWrite.PressEnterToContinue();
    }

    private void SuccessfullyCreatedNewRoom(Room newRoom)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(" Nytt rum registrerat!");
        PageHeader.LineTwo();
        Service.ShowAllRoomDetails(newRoom);
        Console.WriteLine(Environment.NewLine);
        Console.ForegroundColor = ConsoleColor.Gray;
    }

    private static void RegisterNewRoomHeader()
    {
        Console.Clear();
        Console.WriteLine(" Registrera rum");
        PageHeader.LineOne();
    }
}