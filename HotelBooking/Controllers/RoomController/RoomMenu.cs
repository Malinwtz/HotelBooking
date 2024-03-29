﻿using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.RoomController;

public class RoomMenu : IMenu
{
    public int ReturnSelectionFromMenu()
    {
        Console.Clear();
        var endAlternative = 4;
        Console.WriteLine(" RUMSMENY");
        Lines.LineThreeStar();
        Console.WriteLine(" 1. Visa alla rum");
        Console.WriteLine(" 2. Registrera rum");
        Console.WriteLine(" 3. Ändra rum");
        Console.WriteLine($" {endAlternative}. Ta bort rum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromRooMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        Console.Clear();
        return selectFromRooMenu;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
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

    public static int UpdateRoomMenuShowAndReturnSelection()
    {
        Console.Clear();
        var endAlternative = 2;
        Console.WriteLine(" 1. Ändra storlek (kvadratmeter) ");
        Console.WriteLine($" {endAlternative}. Ändra antal gäster som får plats");
        ReturnFromMenuClass.ExitMenu();
        var selectFromUpdateBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        Console.Clear();
        return selectFromUpdateBookingMenu;
    }

    public static int MenuDeleteRoomWithBooking()
    {
        var endAlternative = 2;
        Console.WriteLine("\n 1. Ta bort rum");
        Console.WriteLine($" {endAlternative}. Fortsätt utan att ta bort rum");
        var selectedFromDeleteRoomOptions = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        Console.Clear();
        return selectedFromDeleteRoomOptions;
    }
}