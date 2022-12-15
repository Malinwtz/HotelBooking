using HotelBooking.Controllers.Menu;

namespace HotelBooking.MenuHandler;

public class BookingMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Visa lediga rum");
        Console.WriteLine("2. Ta bort bokning");
        Console.WriteLine($"{endAlternative}. Sök på tillgängliga datum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromBookingMenu;
    }

    public void LoopMenu()
    {
        throw new NotImplementedException();
    }
}