namespace HotelBooking.MenuHandler;

public class ShowMenu
{
    

    public static int ShowRoomMenu()
    {
        var endAlternative = 2;
        Console.WriteLine("1. Registrera rum");
        Console.WriteLine($"{endAlternative}. Ändra rumsuppgifter");
        ReturnFromMenuClass.ExitMenu();
        var selectFromRooMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromRooMenu;
    }

    public static int ShowBookingMenu()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Visa lediga rum");
        Console.WriteLine("2. Ta bort bokning");
        Console.WriteLine($"{endAlternative}. Sök på tillgängliga datum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromBookingMenu;
    }
}


//public static int AllMenus(string menuSelection)
//{
//    var endAlternative = -1;
//    if (menuSelection.ToLower() == "start")
//    {
//        endAlternative= ShowStartMenu();
//    }
//    else if (menuSelection.ToLower() == "customer")
//    {
//        endAlternative = ShowCustomerMenu();
//    }
//    else if (menuSelection == "room")
//    {
//        endAlternative = ShowRoomMenu();
//    }
//    else if (menuSelection == "booking")
//    {
//        endAlternative = ShowBookingMenu();
//    }
//    ReturnFromMenuClass.ExitMenu();
//    var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
//    return sel;
//}