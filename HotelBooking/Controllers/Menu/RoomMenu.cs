using HotelBooking.Controllers.Create;
using HotelBooking.Controllers.Delete;
using HotelBooking.Controllers.Menu;
using HotelBooking.Controllers.Read;
using HotelBooking.Controllers.Update;
using HotelBooking.Data;

namespace HotelBooking.MenuHandler;

public class RoomMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        var endAlternative = 2;
        Console.WriteLine("1. Registrera rum");
        Console.WriteLine($"{endAlternative}. Ändra rumsuppgifter");
        ReturnFromMenuClass.ExitMenu();
        var selectFromRooMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromRooMenu;
    }

    public void LoopMenu(int selectselectionFromMenuionMenu, ApplicationDbContext dbContext)
    {
        switch (selectionFromMenu)
        {
            case 0:
                //avsluta
                break;
            case 1:
                var read = new ReadCustomer(dbContext);
                read.RunCrud();
                break;
            case 2:
            {
                var create = new CreateCustomer(dbContext);
                create.RunCrud();
                break;
            }
            case 3:
                var update = new UpdateCustomer(dbContext);
                update.RunCrud();
                break;
            case 4:
            {
                var delete = new DeleteCustomer(dbContext);
                delete.RunCrud();
                break;
            }
        }
    }
}