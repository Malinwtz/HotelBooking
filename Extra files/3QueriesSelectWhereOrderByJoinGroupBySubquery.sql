USE Hotel;

--Show all rooms bigger than 20 square meters ordered by number of guests------
SELECT 
	*
FROM 
	Rooms
WHERE 
	SizeSquareMeters > 20
ORDER BY 
	NumberOfGuests DESC;

--Show all rooms and average room size-----------------------------------------
SELECT
	RoomId,
	[Type],
	SizeSquareMeters, 
		(
		SELECT 
			AVG(SizeSquareMeters) 
		FROM 
			Rooms
		) AS AverageRoomSize
FROM 
	Rooms;

--Show bookings ordered by booking id------------------------------------------
SELECT 
	b.BookingId, 
	c.FirstName, 
	c.LastName,  
	r.RoomId, r.[Type], 
	r.SizeSquareMeters 
FROM 
	Customers c
INNER JOIN 
	Bookings b ON c.CustomerId=b.CustomerId
INNER JOIN 
	Rooms r ON b.RoomId=r.RoomId
ORDER BY 
	b.BookingId;

--Show bookings/room-----------------------------------------------------------
SELECT 
	RoomId,
	COUNT(*) AS NumberOfBookings
FROM
	Bookings
GROUP BY
	RoomId;

--Show all bookings where days booked are more than average--------------------
SELECT
	BookingId,
	NumberOfDays,
	RoomId,
	CONVERT(char(10), StartDate, 23) AS StartDate,
	CONVERT(char(10), EndDate, 23) AS EndDate
FROM 
	Bookings
WHERE 
	NumberOfDays > 
		(
		SELECT 
			AVG(NumberOfDays) 
		FROM 
			Bookings
		);