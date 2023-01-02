using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class CreateRoom : ICrud
{
    public RoomService Service = new();

    public CreateRoom(ApplicationDbContext dbContext)
    {
        DbContext = dbContext;
    }

    public ApplicationDbContext DbContext { get; set; }

    public void RunCrud()
    {
        var newRoom = new Room();

        RoomPageHeader.CreateRoomHeader();

        var sizeInput = Service.SetRoomSize(newRoom);

        Service.SetPropertyTypeToRoomBySizeInput(sizeInput, newRoom);
        Service.SetPropertyExtraBedToRoomBySizeInput(sizeInput, newRoom);
        Service.SetPropertyNumberOfGuestsToRoomBySizeInput(sizeInput, newRoom);

        DbContext.Rooms.Add(newRoom);
        DbContext.SaveChanges();

        StringToWrite.SuccessfulAction(" Nytt rum registrerat!");
    }
}