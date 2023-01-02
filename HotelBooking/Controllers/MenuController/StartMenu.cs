using HotelBooking.Controllers.BookingController;
using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Controllers.RoomController;
using HotelBooking.Data;

namespace HotelBooking.MenuHandler;

public class StartMenu : IMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 3;
        Console.WriteLine(" STARTMENY");
        Lines.LineThreeStar();
        Console.WriteLine(" 1. KUND      (Registrera - Visa - Ändra - Ta bort)");
        Console.WriteLine(" 2. RUM       (Registrera - Visa - Ändra - Ta bort)");
        Console.WriteLine($" {endAlternative}. BOKNING   (Registrera - Visa - Ändra - Ta bort)");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var loop = true;
        while (loop)
            switch (selectedFromMenu)
            {
                case 1:
                {
                    var customerMenu = new CustomerMenu();
                    var selectedFromCustomerMenu = customerMenu.ReturnSelectionFromMenu();
                    if (selectedFromCustomerMenu == 0) loop = false;
                    customerMenu.LoopMenu(selectedFromCustomerMenu, dbContext);
                    break;
                }
                case 2:
                {
                    var roomMenu = new RoomMenu();
                    var selectedFromRoomMenu = roomMenu.ReturnSelectionFromMenu();
                    if (selectedFromRoomMenu == 0) loop = false;
                    roomMenu.LoopMenu(selectedFromRoomMenu, dbContext);
                    break;
                }
                case 3:
                    var bookingMenu = new BookingMenu();
                    var selectedFromBookingMenu = bookingMenu.ReturnSelectionFromMenu();
                    if (selectedFromBookingMenu == 0) loop = false;
                    bookingMenu.LoopMenu(selectedFromBookingMenu, dbContext);
                    break;
            }
    }
}