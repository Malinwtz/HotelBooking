--CREATE HOTEL DATABASE-----------------------------------------------

CREATE DATABASE Hotel;

CREATE TABLE Bookings(
[BookingId] int NOT NULL PRIMARY KEY,
[CustomerId] int NOT NULL FOREIGN KEY REFERENCES Customers(CustomerId),
[RoomId] int NOT NULL FOREIGN KEY REFERENCES Rooms(RoomId),
[StartDate] datetime2(7) NOT NULL,
[EndDate] datetime2(7) NOT NULL,
[NumberOfDays] int NOT NULL,
[GuestCount] int NOT NULL,
);

CREATE TABLE Customers(
[CustomerId] int NOT NULL PRIMARY KEY,
[FirstName] nvarchar(100) NOT NULL,
[LastName] nvarchar(100) NOT NULL,
[Phone] nvarchar(20) NOT NULL,
[Active] bit NOT NULL,
);

CREATE TABLE Rooms(
[RoomId] int NOT NULL PRIMARY KEY,
[SizeSquareMeters] int NOT NULL,
[NumberOfGuests] int NOT NULL,
[Type] nvarchar(10) NOT NULL,
[ExtraBed] int NOT NULL,
);

------------------------------------------------------------------------
