using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HotelBooking.Controllers;
using HotelBooking.Data;
using HotelBooking.MenuHandler;
using Microsoft.EntityFrameworkCore;

namespace HotelBooking
{
    internal class Application
    {
        public void Run()
        {
            var builder = new Builder();
            builder.BuildProject();

            // LoopMenu.MenuLoop();
        }
    }
}



/*

 Code first

Användare ska kunna: 
        Se och editera alla rum, kunder och bokningar åt ett hotell.  
    •	(C) Lägg till en ny entitet
    •	(R) Se en list över de befintliga entiteter som finns i databasen
    •	(U) Uppdatera en befintlig entitet
    •	(D) Radera en befintlig entitet

Tabeller: valfritt
Tabellkolumner: valfritt
Definiera och dokumentera i form av en Entity Relation Diagram - inkl kardinalitet.

 
 */