using HotelBooking.Controllers.Interface;
using HotelBooking.Data;
using HotelBooking.MenuHandler;

namespace HotelBooking.Controllers.CustomerController;

public class CustomerMenu : IMenu
{
    public int ShowAndReturnSelection()
    {
        Console.Clear();
        var endAlternative = 4;
        Console.WriteLine("KUNDMENY");
        Console.WriteLine("********");
        Console.WriteLine("1. Visa alla kunder");
        Console.WriteLine("2. Registrera kund");
        Console.WriteLine("3. Ändra kunduppgifter");
        Console.WriteLine($"{endAlternative}. Avregistrera kund");
        ReturnFromMenuClass.ExitMenu();
        var sel = ReturnFromMenuClass.ReturnFromMenu(endAlternative);
        return sel;
    }

    public void LoopMenu(int selectedFromMenu, ApplicationDbContext dbContext)
    {
        switch (selectedFromMenu)
        {
            case 0:
                //avsluta
                break;
            case 1:
                var read = new ReadCustomer(dbContext);
                read.RunCrud();
                break;
            case 2:
            {
                var create = new CreateCustomer(dbContext);
                create.RunCrud();
                break;
            }
            case 3:
                var update = new UpdateCustomer(dbContext);
                update.RunCrud();
                break;
            case 4:
            {
                var delete = new DeleteCustomer(dbContext);
                delete.RunCrud();
                break;
            }
        }
    }
}