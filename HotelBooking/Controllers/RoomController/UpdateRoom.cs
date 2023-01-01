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
        var read = new ReadRoom(DbContext);
        read.View();

        PageHeader.LineTwo();
        
        Console.Write(" Välj Id på det rum du vill uppdatera: "); 
        var roomIdToUpdate = Convert.ToInt32(Console.ReadLine()); 
        var roomToUpdate = DbContext.Rooms.First(c => c.RoomId == roomIdToUpdate);
        
        Console.Clear();
        var selectionFromUpdateRoomMenu = RoomMenu.UpdateRoomMenuShowAndReturnSelection();
        Console.Clear();
        switch (selectionFromUpdateRoomMenu)
        {
            case 1:
            {
                Console.Write(" Uppdatera rummets storlek: ");
                roomToUpdate.SizeSquareMeters = ErrorHandling.TryInt();
                Service.SetPropertyTypeToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
                Service.SetPropertyExtraBedToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);
                Service.SetPropertyNumberOfGuestsToRoomBySizeInput(roomToUpdate.SizeSquareMeters, roomToUpdate);

                DbContext.SaveChanges();
                break;
            }
            case 2:
            {
                var highestNumberOfGuests = 0;
                    if (roomToUpdate.SizeSquareMeters < 20)
                    highestNumberOfGuests = 1;
                else if (roomToUpdate.SizeSquareMeters >= 20 && roomToUpdate.SizeSquareMeters < 30)
                    highestNumberOfGuests = 2;
                else if (roomToUpdate.SizeSquareMeters >= 30 && roomToUpdate.SizeSquareMeters < 40)
                    highestNumberOfGuests = 3;
                else if (roomToUpdate.SizeSquareMeters >= 40) highestNumberOfGuests = 4;
                
                    while (true)
                    {
                        Console.Write(" Uppdatera antal gäster som får plats: ");
                        var updatedNumberOfGuests = ErrorHandling.TryInt();
                        if (updatedNumberOfGuests > highestNumberOfGuests)
                        {
                            Console.Clear();
                            Console.WriteLine($" Max antal gäster som får plats i rummet är: {highestNumberOfGuests}");
                        }
                        else if (updatedNumberOfGuests <= highestNumberOfGuests)
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

                            roomToUpdate.NumberOfGuests = updatedNumberOfGuests;
                            DbContext.SaveChanges();

                            break;
                        }
                    }
                    break;
            }
        }

        StringToWrite.SuccessfulAction($" Rummet är ändrat! \n" +
                                       $"\n Storlek: {roomToUpdate.SizeSquareMeters}kvm" +
                                       $"\n Antal gäster: {roomToUpdate.NumberOfGuests}" +
                                       $"\n Antal extrasängar: {roomToUpdate.ExtraBed}");
    }
}