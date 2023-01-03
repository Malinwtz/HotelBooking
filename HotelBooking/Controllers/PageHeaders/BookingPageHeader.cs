using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.PageHeaders;

public class BookingPageHeader
{
    public static void CreateBookingHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tSKAPA NY BOKNING");
        Lines.LineThreeStar();
    }

    public static void ReadBookingHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tALLA BOKNINGAR");
        Lines.LineThreeStar();
    }

    public static void UpdateBookingHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tÄNDRA BOKNING");
        Lines.LineThreeStar();
    }

    public static void DeleteBookingHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tTA BORT BOKNING");
        Lines.LineThreeStar();
    }

    public static void BookingDetailsHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tBOKNINGSDETALJER");
        Lines.LineThreeStar();
        Console.WriteLine(String.Format("{0,-15} {1,-30} {2,-30} {3,-10} {4,-10} {5,-5}", 
            $"BokningsId", "Kund", "Startdatum - Slutdatum", "Dagar", "Gäster", "Rummets Id"));
    }

    public static void AvailableRoomHeader()
    {
        Console.WriteLine("\n\n\n\t\t\t\t\t     BOKNINGSBARA RUM");
        Console.WriteLine("\n Id\t\tTyp\t\tStorlek\t\tMax antal gäster\t\tMöjlighet till extrasäng");
        Lines.LineOneEqual();
    }
}