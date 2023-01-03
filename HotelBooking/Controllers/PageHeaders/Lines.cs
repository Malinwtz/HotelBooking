namespace HotelBooking.Controllers.PageHeaders;

public class Lines
{
    public static void LineOneEqual()
    {
        Console.WriteLine("======================================================" +
                          "==================================================================" +
                          Environment.NewLine);
    }

    public static void LineTwoHyphen()
    {
        Console.WriteLine("------------------------------------------------------" +
                          "-----------------------------------------------------------------");
    }

    public static void LineThreeStar()
    {
        Console.WriteLine("******************************************************" +
                          "******************************************************************" +
                          Environment.NewLine);
    }
}