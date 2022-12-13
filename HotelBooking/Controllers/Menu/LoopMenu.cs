using HotelBooking.Controllers;
using HotelBooking.Data;

namespace HotelBooking.MenuHandler;

public class LoopMenu
{
    public static void MenuLoop(ApplicationDbContext dbContext) //skicka med dbcontext, skapa upp den en gång och skicka med den
    {
        while (true)
        {
            var sel = ShowMenu.ShowStartMenu();
            if (sel == 0) break;
            switch (sel)
            {
                case 1:
                {
                    var sel2 = ShowMenu.ShowCustomerMenu();
                    ManageCustomerMenu.CustomerMenu(sel2);

                    var action = new CreateCustomer(dbContext); ///vill göra nästan samma sak men lite olika varje gång. strategy pattern och kanske factory pattern
                    action.Run(); //använd interface för att crud ska ha samma metoder ex Run() Interface ICrud med metod run()
                    
                    break;
                }
                case 2:
                    ShowMenu.ShowRoomMenu();
                    break;
                case 3:
                    ShowMenu.ShowBookingMenu();
                    break;
            }
        }
    }
}