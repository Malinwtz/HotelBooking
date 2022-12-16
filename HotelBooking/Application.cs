using HotelBooking.Controllers;
using HotelBooking.MenuHandler;

namespace HotelBooking;

internal class Application
{
    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject();

        var startMenu = new StartMenu();
        var selectedFromStartMenu = startMenu.ShowAndReturnSelection();
        startMenu.LoopMenu(selectedFromStartMenu, dbContext);
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