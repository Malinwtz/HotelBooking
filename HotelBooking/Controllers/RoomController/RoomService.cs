using HotelBooking.Controllers.ErrorController;
using HotelBooking.Data.Tables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.RoomController
{
    public class RoomService
    {
        public void SetPropertyExtraBedToRoomBySizeInput(int sizeInput, Room roomToSetPropertyExtraBedTo)
        {
            if (sizeInput < 25) 
            {
                roomToSetPropertyExtraBedTo.ExtraBed = 0;
            }
            else if (sizeInput >= 25)
            {
                roomToSetPropertyExtraBedTo.ExtraBed = 1;
            }
        }
        public void SetPropertyTypeToRoomBySizeInput(int sizeInput, Room roomToSetPropertyTypeTo)
        {
            var singleRoom = "Single";
            var doubleRoom = "Double";

            if (sizeInput < 20) 
            {
                roomToSetPropertyTypeTo.Type = singleRoom;
            }
            else if (sizeInput >= 20)
            {
                roomToSetPropertyTypeTo.Type = doubleRoom;
            }
        }
        public void SetPropertyNumberOfGuestsToRoomBySizeInput(int sizeInput, Room roomToSetPropertyNumberOfGuestsTo)
        {
            if (sizeInput < 20) 
            {
                roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 1;
            }
            else if (sizeInput >= 20 && sizeInput < 30)
            {
                roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 2;
            }
            else if (sizeInput >= 30 && sizeInput < 40)
            {
                roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 3;
            }
            else if (sizeInput >= 40)
            {
                roomToSetPropertyNumberOfGuestsTo.NumberOfGuests = 4;
            }
        }

        public void ShowAllRoomDetails(Room roomToShow)
        {
            Console.WriteLine($"Id: {roomToShow.RoomId} " +
                              $"\nStorlek: {roomToShow.Type}, {roomToShow.SizeSquareMeters}kvm" +
                              $"\nAntal möjliga extrasängar: {roomToShow.ExtraBed}" +
                              $"\nAntal gäster: {roomToShow.NumberOfGuests}");
        }
        public int GetSizeSquareMetersInput(Room roomToGetASize)
        {
            Console.Write("SizeSquareMeters: ");
            var sizeInput = ErrorHandling.TryInt();
            roomToGetASize.SizeSquareMeters = sizeInput;
            return sizeInput;
        }
    }
}
