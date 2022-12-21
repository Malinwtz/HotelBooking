using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelBooking.Controllers.Interface
{
    public interface IPageHeader
    {
        void CreateRoomHeader(); 
        void ReadRoomHeader(); 
        void UpdateRoomHeader();
        void DeleteRoomHeader();
    }
}
