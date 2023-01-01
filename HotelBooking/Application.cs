using HotelBooking.Controllers;
using HotelBooking.MenuHandler;

namespace HotelBooking;

public class Application
{
    public bool ContinueLoop { get; set; } = true;
    public void Run()
    {
        var builder = new Builder();
        builder.BuildProject();
        var dbContext = builder.ConnectProject();
        while (ContinueLoop)
        {
            var startMenu = new StartMenu();
            var selectedFromStartMenu = startMenu.ReturnSelectionFromMenu();
            if (selectedFromStartMenu == 0) break;
                startMenu.LoopMenu(selectedFromStartMenu, dbContext);
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