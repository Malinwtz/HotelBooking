using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.BookingController;

public class BookingMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        Console.Clear();
        var endAlternative = 3;
        Console.WriteLine("BOKNINGSMENY");
        Console.WriteLine("************");
        Console.WriteLine("1. Visa alla bokningar");
        Console.WriteLine("2. Registrera bokning");
        Console.WriteLine("3. Ändra bokning");
        Console.WriteLine("2. Ta bort bokning");
        Console.WriteLine($"{endAlternative}. Sök på tillgängliga datum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromBookingMenu;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        var loop = true;
        while (loop)
        {

            switch (selectedFromMenu)
            {
                case 0:
                    loop = false;
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
}