﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.PageHeaders
{
    public class BookingPageHeader
    {
        public static void CreateBookingHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tSKAPA NY BOKNING");
            PageHeader.LineThree();
        }
        public static void ReadBookingHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tALLA BOKNINGAR");
            PageHeader.LineThree();
        }
        public static void UpdateBookingHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tÄNDRA BOKNING");
            PageHeader.LineThree();
        }
        public static void DeleteBookingHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tTA BORT BOKNING");
            PageHeader.LineThree();
        }

        public static void BookingDetailsHeader()
        {
            Console.Clear();
            Console.WriteLine("\t\t\t\t\t\tBOKNINGSDETALJER");
            PageHeader.LineThree();
        }

        public static void AvailableRoomHeader()
        {
            Console.WriteLine("\n\n\n\t\t\t\t\t     BOKNINGSBARA RUM");
            Console.WriteLine("\n Id\t\tTyp\t\tStorlek\t\tMax antal gäster\t\tMöjlighet till extrasäng");
            PageHeader.LineOne();
        }
    }
}
