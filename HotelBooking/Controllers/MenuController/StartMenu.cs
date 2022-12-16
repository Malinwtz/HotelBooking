using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.RoomController;
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
        var loop = true;
        while (loop == true)
        {
            if (selectionFromMenu == 0)
            {
               // loop == false;
            }
            switch (selectionFromMenu)
            {
                case 1:
                {
                    var customerMenu = new CustomerMenu();
                    var selectedFromCustomerMenu = customerMenu.ShowAndReturnSelection();
                    customerMenu.LoopMenu(selectedFromCustomerMenu, dbContext);
                    break;
                }
                case 2:
                {
                    var roomMenu = new RoomMenu();
                    var selectedFromRooMenuMenu = roomMenu.ShowAndReturnSelection();
                    roomMenu.LoopMenu(selectedFromRooMenuMenu, dbContext);
                    break;
                }
                case 3:
                    var bookingMenu = new BookingMenu();
                    var selectedFromBookingMenu = bookingMenu.ShowAndReturnSelection();
                    bookingMenu.LoopMenu(selectedFromBookingMenu, dbContext);
                    break;
            }
        }
    }
}