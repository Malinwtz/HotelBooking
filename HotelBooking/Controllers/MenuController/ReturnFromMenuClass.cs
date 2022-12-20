﻿using HotelBooking.Controllers.ErrorHandling;

namespace HotelBooking.MenuHandler;

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
        Console.WriteLine(Environment.NewLine + "0 = Avbryt");
    }
}