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

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(" Rummets storlek ändrat!");
                Service.ShowAllRoomDetails(roomToUpdate);
                Console.ForegroundColor = ConsoleColor.Gray;
                StringToWrite.PressEnterToContinue();
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
                            //ändra antal extrasängar efter hur många gäster som får plats?

                            roomToUpdate.NumberOfGuests = updatedNumberOfGuests;
                            DbContext.SaveChanges();
                            break;
                        }
                    }
                    break;
            }
        }
    }
}