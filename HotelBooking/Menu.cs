namespace HotelBooking;

public class Menu
{
    public static int ShowStartMenu()
    {
        var alt1 = 1;
        var alt2 = 3;
        Console.WriteLine($"{alt1}. Registrera eller avregistrera kund");
        Console.WriteLine("2. Registrera eller ändra rumsuppgifter");
        Console.WriteLine($"{alt2}. Rumsbokning");
        var sel = ReturnFromMenu(alt1, alt1);
        return sel;
    }
    public static int ShowBookingMenu()
    {
        var alt1 = 1;
        var alt2 = 2;
        Console.WriteLine($"{alt1}. Visa lediga rum");
        Console.WriteLine($"{alt2}. Sök på tillgängliga datum");
        var sel = ReturnFromMenu(alt1, alt1);
        return sel;
    }
    public static int ReturnFromMenu(int min, int max)
    {
        var sel = -1;
        while (true)
        {
            try { sel = Convert.ToInt32(Console.ReadLine()); }
            catch { ErrorMessage.WrongInputMessage(); }
            if (sel >= min && sel <= max) return sel;
            ErrorMessage.WrongInputMessage();
        }
    }
}