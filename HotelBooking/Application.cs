using HotelBooking.Controllers;
using HotelBooking.MenuHandler;

namespace HotelBooking;

public class Application
{
    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject();
        while (true)
        {
            var startMenu = new StartMenu();
            var selectedFromStartMenu = startMenu.ReturnSelectionFromMenu();
            if (selectedFromStartMenu == 0) break;
                startMenu.LoopMenu(selectedFromStartMenu, dbContext);
        }
    }
}