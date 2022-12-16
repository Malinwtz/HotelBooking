using HotelBooking.Controllers.CustomerController;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.BookingController;

public class BookingMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        var endAlternative = 3;
        Console.WriteLine("1. Visa lediga rum");
        Console.WriteLine("2. Ta bort bokning");
        Console.WriteLine($"{endAlternative}. Sök på tillgängliga datum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromBookingMenu;
    }

    public void LoopMenu(int selectionFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectionFromMenu)
        {
            case 0:
                //avsluta
                break;
            case 1:
                var read = new ReadBooking(dbContext);
                read.RunCrud();
                break;
            case 2:
                {
                    var create = new CreateBooking(dbContext);
                    create.RunCrud();
                    break;
                }
            case 3:
                var update = new UpdateBooking(dbContext);
                update.RunCrud();
                break;
            case 4:
                {
                    var delete = new DeleteBooking(dbContext);
                    delete.RunCrud();
                    break;
                }
        }
    }
}