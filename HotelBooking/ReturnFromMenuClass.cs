namespace HotelBooking;

public class ReturnFromMenuClass
{
    public static int ReturnFromMenu(int max)
    {
        var sel = -1;
        while (true)
        {
            try { sel = Convert.ToInt32(Console.ReadLine()); }
            catch { ErrorMessage.WrongInputMessage(); }
            if (sel >= 0 && sel <= max) return sel;
            ErrorMessage.WrongInputMessage();
        }
    }
    public static void ExitMenu()
    {
        Console.WriteLine("0 = Avbryt");
    }
}