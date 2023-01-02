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

    public RoomService Service = new();


    public void RunCrud()
    {
        RoomPageHeader.UpdateRoomHeader();

        if (!DbContext.Customers.Any())
        {
            Console.WriteLine(" Det finns inga kunder");
        }
        else if (DbContext.Customers.Any())
        {
            var read = new ReadRoom(DbContext);
            read.View();

            var roomToUpdate = Service.GetRoomFromId();
            var selectionFromUpdateRoomMenu = RoomMenu.UpdateRoomMenuShowAndReturnSelection();
            
            switch (selectionFromUpdateRoomMenu)
            {
                case 1:
                {
                    Service.SetRoomSize(roomToUpdate);
                    Service.SetPropertyTypeToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
                    Service.SetPropertyExtraBedToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
                    Service.SetPropertyNumberOfGuestsToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
                    DbContext.SaveChanges();
                    break;
                }
                case 2:
                {
                    var highestNumberOfGuests = GetMaxNumberOfGuests(roomToUpdate);

                    while (true)
                    {
                        var updatedNumberOfGuests = UpdatedNumberOfGuests();
                        if (updatedNumberOfGuests > highestNumberOfGuests)
                        {
                            StringToWrite.NotSuccessfulAction(
                                $" Max antal gäster som får plats i rummet är: {highestNumberOfGuests}");
                        }
                        else if (updatedNumberOfGuests <= highestNumberOfGuests)
                        {
                            SetPropertiesToRoomByNumberOfGuests(updatedNumberOfGuests, roomToUpdate);
                            roomToUpdate.NumberOfGuests = updatedNumberOfGuests;
                            DbContext.SaveChanges();
                            break;
                        }
                    }

                    break;
                }
            }

            StringToWrite.SuccessfulAction($" Rummet är ändrat! \n\n Storlek: {roomToUpdate.SizeSquareMeters}kvm" +
                                           $"\n Antal gäster: {roomToUpdate.NumberOfGuests}\n Antal extrasängar: {roomToUpdate.ExtraBed}");
        }
    }

    private static int UpdatedNumberOfGuests()
    {
        Console.Write(" Uppdatera antal gäster som får plats: ");
        var updatedNumberOfGuests = ErrorHandling.TryInt();
        return updatedNumberOfGuests;
    }

    private static void SetPropertiesToRoomByNumberOfGuests(int updatedNumberOfGuests, Room roomToUpdate)
    {
        if (updatedNumberOfGuests == 1)
        {
            roomToUpdate.Type = StringToWrite.Single;
            roomToUpdate.ExtraBed = 0;
        }
        else if (updatedNumberOfGuests == 2)
        {
            roomToUpdate.Type = StringToWrite.Double;
            roomToUpdate.ExtraBed = 0;
        }
        else if (updatedNumberOfGuests > 2 && updatedNumberOfGuests <= 3)
        {
            roomToUpdate.Type = StringToWrite.Double;
            roomToUpdate.ExtraBed = 1;
        }
        else if (updatedNumberOfGuests > 3)
        {
            roomToUpdate.Type = StringToWrite.Double;
            roomToUpdate.ExtraBed = 2;
        }
    }

    public static int GetMaxNumberOfGuests(Room roomToUpdate)
    {
        var highestNumberOfGuests = 0;
        if (roomToUpdate.SizeSquareMeters < 20)
            highestNumberOfGuests = 1;
        else if (roomToUpdate.SizeSquareMeters >= 20 && roomToUpdate.SizeSquareMeters < 30)
            highestNumberOfGuests = 2;
        else if (roomToUpdate.SizeSquareMeters >= 30 && roomToUpdate.SizeSquareMeters < 40)
            highestNumberOfGuests = 3;
        else if (roomToUpdate.SizeSquareMeters >= 40) highestNumberOfGuests = 4;
        return highestNumberOfGuests;
    }
}