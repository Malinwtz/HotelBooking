using HotelBooking.Controllers.ErrorController;
using HotelBooking.Data.Tables;

namespace HotelBooking.Controllers.RoomController;

public class RoomService
{
    public void SetPropertyExtraBedToRoomBySizeInput(int sizeInput, Room roomToSetPropertyExtraBedTo)
    {
        if (sizeInput < 25)
            roomToSetPropertyExtraBedTo.ExtraBed = 0;
        else if (sizeInput >= 25 && sizeInput < 40)
            roomToSetPropertyExtraBedTo.ExtraBed = 1;
        else if (sizeInput >= 40) roomToSetPropertyExtraBedTo.ExtraBed = 2;
    }

    public void SetPropertyTypeToRoomBySizeInput(int sizeInput, Room roomToSetPropertyTypeTo)
    {
        if (sizeInput < 20)
            roomToSetPropertyTypeTo.Type = StringToWrite.Single;
        else if (sizeInput >= 20) roomToSetPropertyTypeTo.Type = StringToWrite.Double;
    }

    public void SetPropertyNumberOfGuestsToRoomBySizeInput(int sizeInput, Room roomToSetPropertyNumberOfGuestsTo)
    {
        if (sizeInput < 20)
            roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 1;
        else if (sizeInput >= 20 && sizeInput < 30)
            roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 2;
        else if (sizeInput >= 30 && sizeInput < 40)
            roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 3;
        else if (sizeInput >= 40) roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 4;
    }


    public int GetSizeSquareMetersInput(Room roomToGetASize)
    {
        var sizeInput = 0; // det går att registerera fel size
        while (true)
        {
            Console.Write(" Storlek i kvadratmeter: ");
            sizeInput = ErrorHandling.TryInt();
            if (sizeInput > 10 || sizeInput < 50)
            {
                break;
            }
            Console.WriteLine("Rummet kan bara vara mellan 10 och 50 kvadratmeter");
        }
        
        roomToGetASize.SizeSquareMeters = sizeInput;
        return sizeInput;
    }
}