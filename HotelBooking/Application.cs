using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.MenuHandler;

namespace HotelBooking
{
    internal class Application
    {
        public void Run()
        {
            while (true)
            {
                var sel = ShowMenu.ShowStartMenu();
                if (sel == 0) break;
                if (sel == 1)
                {
                    var sel2 = ShowMenu.ShowCustomerMenu();
                    ManageCustomerMenu.CustomerMenu(sel2);
                }
                else if (sel == 2)
                {
                    ShowMenu.ShowRoomMenu();
                }
                else if (sel == 3)
                {
                    ShowMenu.ShowBookingMenu();
                }
            }
        }
    }
}



/*

 Code first

Användare ska kunna: 
        Se och editera alla rum, kunder och bokningar år ett hotell.  
    •	(C) Lägg till en ny entitet
    •	(R) Se en list över de befintliga entiteter som finns i databasen
    •	(U) Uppdatera en befintlig entitet
    •	(D) Radera en befintlig entitet

Tabeller: valfritt
Tabellkolumner: valfritt
Definiera och dokumentera i form av en Entity Relation Diagram - inkl kardinalitet.

 
 */