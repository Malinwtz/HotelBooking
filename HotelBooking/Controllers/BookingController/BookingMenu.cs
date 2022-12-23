using HotelBooking.Controllers.CustomerController;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.BookingController;

public class BookingMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        Console.Clear();
        var endAlternative = 4;
        Console.WriteLine(" BOKNINGSMENY");
        PageHeader.LineThree();
        Console.WriteLine(" 1. Visa alla bokningar");
        Console.WriteLine(" 2. Registrera bokning");
        Console.WriteLine(" 3. Ändra bokning");
        Console.WriteLine($" {endAlternative}. Ta bort bokning");
        ReturnFromMenuClass.ExitMenu();
        var selectFromBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromBookingMenu;
    }

    public static int UpdateBookingMenuShowAndReturnSelection()
    {
        var endAlternative = 3;
        Console.WriteLine(" 1. Ändra datum");
        Console.WriteLine(" 2. Ändra kund");
        Console.WriteLine($" {endAlternative}. rum");
        ReturnFromMenuClass.ExitMenu();
        var selectFromUpdateBookingMenu = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return selectFromUpdateBookingMenu;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
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