namespace HotelBooking.MenuHandler;

public class LoopMenu
{
    public static void MenuLoop()
    {
        while (true)
        {
            var sel = ShowMenu.ShowStartMenu();
            if (sel == 0) break;
            if (sel == 1)
            {
                var sel2 = ShowMenu.ShowCustomerMenu();
                ManageCustomerMenu.CustomerMenu(sel2);
            }
            else if (sel == 2)
            {
                ShowMenu.ShowRoomMenu();
            }
            else if (sel == 3)
            {
                ShowMenu.ShowBookingMenu();
            }
        }
    }
}