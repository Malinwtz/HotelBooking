﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.ErrorController
{
    public class ErrorHandling
    {
        public static void WrongInputMessage()
        {
            Console.WriteLine("Felaktig input");
        }
        public static DateTime TryDate()
        {
            while (true)
                try
                {
                    var date = DateTime.ParseExact(Console.ReadLine(), "yyyy-MM-dd", CultureInfo.CurrentCulture);
                    return date;
                }
                catch
                {
                    WrongInputMessage();
                }
        }

        public static int TryInt()
        {
            while (true)
                try
                {
                    int.TryParse(Console.ReadLine(), out var saldo);
                    if (saldo > 0)
                        return saldo;
                }
                catch
                {

                }
        }

        public static decimal TryPrice()
        {
            while (true)
                try
                {
                    var price = Convert.ToDecimal(Console.ReadLine());
                    if (price >= 1) return price;
                    WrongInputMessage();
                }
                catch
                {
                    WrongInputMessage();
                }
        }

        public static string TryUnit()
        {
            while (true)
            {
                var unit = Console.ReadLine();
                if (unit == "kilopris" || unit == "styckpris") return unit;
                WrongInputMessage();
            }
        }

        public static string TryName()
        {
            while (true)
            {
                var name = Console.ReadLine();
                if (name != null && name.Length > 1) return name;
                WrongInputMessage();
            }
        }

        public static string TryId()
        {
            while (true)
                try
                {
                    var newId = Convert.ToInt32(Console.ReadLine());
                    if (newId >= 1)
                        return Convert.ToString(newId);
                    WrongInputMessage();
                }
                catch
                {
                    WrongInputMessage();
                }
        }
    }
}
