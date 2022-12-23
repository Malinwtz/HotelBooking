﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers.Interface;
using HotelBooking.Controllers.PageHeaders;
using HotelBooking.Data;
using Microsoft.Extensions.Options;

namespace HotelBooking.Controllers.RoomController
{
    public class DeleteRoom : ICrud
    {
        public ApplicationDbContext DbContext { get; set; }

        public DeleteRoom(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;
        }
        public void RunCrud()
        {
            Console.Clear();
                Console.WriteLine(" Ta bort ett rum");
                PageHeader.LineOne();

                foreach (var room in DbContext.Rooms)
                {
                    Console.WriteLine($" Id{room.RoomId}: {room.Type}, {room.SizeSquareMeters}kvadratmeter, antal gäster: {room.NumberOfGuests}, antal möjliga extra sängar: {room.ExtraBed}");
                }

                Console.Write(" Välj Id på det rum som du vill ta bort");
                var roomIdToDelete = Convert.ToInt32(Console.ReadLine());
                var roomToDelete = DbContext.Rooms.First(p => p.RoomId == roomIdToDelete);
                DbContext.Rooms.Remove(roomToDelete);

                DbContext.SaveChanges();
                Console.WriteLine(" Rum borttaget!");
                StringToWrite.PressEnterToContinue();
        }
    }
}
