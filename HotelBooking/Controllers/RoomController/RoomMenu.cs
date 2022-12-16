﻿using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.RoomController;

public class RoomMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        var endAlternative = 2;
        Console.WriteLine("1. Visa alla rum");
        Console.WriteLine("2. Registrera rum");
        Console.WriteLine("3. Ändra rum");
        Console.WriteLine($"{endAlternative}. Ta bort rum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromRooMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromRooMenu;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
            case 0:
                //avsluta
                break;
            case 1:
                var read = new ReadRoom(dbContext);
                read.RunCrud();
                break;
            case 2:
            {
                var create = new CreateRoom(dbContext);
                create.RunCrud();
                break;
            }
            case 3:
                var update = new UpdateRoom(dbContext);
                update.RunCrud();
                break;
            case 4:
            {
                var delete = new DeleteRoom(dbContext);
                delete.RunCrud();
                break;
            }
        }
    }
}