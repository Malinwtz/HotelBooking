namespace HotelBooking.Controllers.PageHeaders;

public class RoomPageHeader
{
    public static void CreateRoomHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tREGISTRERA NYTT RUM");
        Lines.LineThreeStar();
    }

    public static void ReadRoomHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tALLA RUM");
        Lines.LineThreeStar();
    }

    public static void UpdateRoomHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tÄNDRA RUM");
        Lines.LineThreeStar();
    }

    public static void DeleteRoomHeader()
    {
        Console.Clear();
        Console.WriteLine("\t\t\t\t\t\tTA BORT RUM");
        Lines.LineThreeStar();
    }
}