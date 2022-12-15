using HotelBooking.Controllers.Menu;

namespace HotelBooking.MenuHandler;

public class CustomerMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        
        var endAlternative = 3;
        Console.WriteLine("1. Registrera kund");
        Console.WriteLine("2. Ändra kunduppgifter");
        Console.WriteLine($"{endAlternative}. Avregistrera kund");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
        
    }

    public void LoopMenu()
    {
        throw new NotImplementedException();
    }
}