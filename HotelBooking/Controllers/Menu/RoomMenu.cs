using HotelBooking.Controllers.Menu;

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

    public void LoopMenu()
    {
        throw new NotImplementedException();
    }
}