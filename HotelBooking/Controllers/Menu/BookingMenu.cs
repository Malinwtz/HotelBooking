using HotelBooking.Controllers.Create;
using HotelBooking.Controllers.Delete;
using HotelBooking.Controllers.Menu;
using HotelBooking.Controllers.Read;
using HotelBooking.Controllers.Update;
using HotelBooking.Data;

namespace HotelBooking.MenuHandler;

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
        //switch (selectionFromMenu)
        //{
        //    case 0:
        //        //avsluta
        //        break;
        //    case 1:
        //        var read = new ReadBookings(dbContext);
        //        read.RunCrud();
        //        break;
        //    case 2:
        //    {
        //        var create = new CreateBookings(dbContext);
        //        create.RunCrud();
        //        break;
        //    }
        //    case 3:
        //        var update = new UpdateBookings(dbContext);
        //        update.RunCrud();
        //        break;
        //    case 4:
        //    {
        //        var delete = new DeleteBookings(dbContext);
        //        delete.RunCrud();
        //        break;
        //    }
        //}
    }
}