namespace HotelBooking.MenuHandler;

public class ShowMenu
{
    public static int ShowStartMenu()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Registrera/ändra/avregistrera kund");
        Console.WriteLine("2. Registrera/ändra rumsuppgifter");
        Console.WriteLine($"{endAlternative}. Registrera/ändra bokning");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public static int ShowCustomerMenu()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Registrera kund");
        Console.WriteLine("2. Ändra kunduppgifter");
        Console.WriteLine($"{endAlternative}. Avregistrera kund");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public static int ShowRoomMenu()
    {
        var endAlternative = 2;
        Console.WriteLine("1. Registrera rum");
        Console.WriteLine($"{endAlternative}. Ändra rumsuppgifter");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public static int ShowBookingMenu()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Visa lediga rum");
        Console.WriteLine("2. Ta bort bokning");
        Console.WriteLine($"{endAlternative}. Sök på tillgängliga datum");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
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