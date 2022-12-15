using HotelBooking.Controllers.Menu;
using HotelBooking.Data;

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
    public void LoopMenu(int selectionFromMenu, ApplicationDbContext dbContext)
    {
        while (true)
        {
            var sel = ShowAndReturnSelection();
            if (sel == 0) break;
            switch (sel)
            {
                case 1:
                {
                    var selectedFromCustomerMenu = BookingMenu.ShowCustomerMenu();
                    ManageCustomerMenu.CustomerMenu(selectedFromCustomerMenu);
                    break;
                }
                case 2:
                {
                    var selectedFromRoomMenu = BookingMenu.ShowRoomMenu();
                    break;
                }
                case 3:
                    BookingMenu.ShowBookingMenu();
                    break;
            }
        }
    }
}