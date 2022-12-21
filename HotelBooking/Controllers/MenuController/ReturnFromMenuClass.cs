using HotelBooking.Controllers.ErrorController;

namespace HotelBooking.MenuHandler;

public class ReturnFromMenuClass
{
    public static int ReturnFromMenu(int max)
    {
        var sel = -1;
        while (true)
        {
            try { sel = Convert.ToInt32(Console.ReadLine()); }
            catch { ErrorHandling.WrongInputMessage(); }
            if (sel >= 0 && sel <= max) return sel;
            ErrorHandling.WrongInputMessage();
        }
    }
    public static void ExitMenu()
    {
        Console.WriteLine(Environment.NewLine + "0 = Avbryt");
    }
}