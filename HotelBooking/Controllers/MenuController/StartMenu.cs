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
        Console.Clear();
        var endAlternative = 3;
        Console.WriteLine("STARTMENY");
        Console.WriteLine("*********");
        Console.WriteLine("1. KUND - Registrera/ändra/avregistrera");
        Console.WriteLine("2. RUM - Registrera/ändra/Ta bort");
        Console.WriteLine($"{endAlternative}. BOKNING - Registrera/ändra/Ta bort");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }
    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var loop = true;
        while (loop == true)
        {
            switch (selectedFromMenu)
            {
                case 1:
                {
                    var customerMenu = new CustomerMenu();
                    var selectedFromCustomerMenu = customerMenu.ShowAndReturnSelection();

                    if (selectedFromCustomerMenu == 0) loop = false; 
                    
                    customerMenu.LoopMenu(selectedFromCustomerMenu, dbContext);
                    break;
                }
                case 2:
                {
                    var roomMenu = new RoomMenu();
                    var selectedFromRoomMenu = roomMenu.ShowAndReturnSelection();

                    if (selectedFromRoomMenu == 0) loop = false;

                    roomMenu.LoopMenu(selectedFromRoomMenu, dbContext);
                    break;
                }
                case 3:
                    var bookingMenu = new BookingMenu();
                    var selectedFromBookingMenu = bookingMenu.ShowAndReturnSelection();

                    if (selectedFromBookingMenu == 0) loop = false;

                    bookingMenu.LoopMenu(selectedFromBookingMenu, dbContext);
                    break;
            }
        }
    }
}