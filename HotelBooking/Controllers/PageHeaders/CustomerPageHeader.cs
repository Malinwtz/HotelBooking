namespace HotelBooking.Controllers.PageHeaders;

public class CustomerPageHeader
{
    public static void CreateCustomerHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tSKAPA NY KUND");
        Lines.LineThreeStar();
    }

    public static void ReadCustomerHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tALLA KUNDER");
        Lines.LineThreeStar();
    }

    public static void UpdateCustomerHeader()
    {
        Console.Clear();
        Console.WriteLine(" \t\t\t\t\t\tÄNDRA KUND");
        Lines.LineThreeStar();
    }

    public static void DeleteCustomerHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tTA BORT KUND");
        Lines.LineThreeStar();
    }
}