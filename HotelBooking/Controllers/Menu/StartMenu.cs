using HotelBooking.Controllers.Menu;

namespace HotelBooking.MenuHandler;

public class StartMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        var endAlternative = 3;
        Console.WriteLine("1. KUND - Registrera/ändra/avregistrera");
        Console.WriteLine("2. RUM - Registrera/ändra/Ta bort");
        Console.WriteLine($"{endAlternative}. BOKNING - Registrera/ändra/Ta bort");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
    public void LoopMenu()
    {
        while (true)
        {
            var sel = ShowAndReturnSelection();
            if (sel == 0) break;
            switch (sel)
            {
                case 1:
                {
                    var selectedFromCustomerMenu = ShowMenu.ShowCustomerMenu();
                    ManageCustomerMenu.CustomerMenu(selectedFromCustomerMenu);
                    break;
                }
                case 2:
                {
                    var selectedFromRoomMenu = ShowMenu.ShowRoomMenu();
                    break;
                }
                case 3:
                    ShowMenu.ShowBookingMenu();
                    break;
            }
        }
    }
}