USE Hotel;

--Show bookings ordered by booking id
SELECT 
	b.BookingId, 
	c.FirstName, 
	c.LastName,  
	r.RoomId, r.[Type], 
	r.SizeSquareMeters 
FROM Customers c
INNER JOIN Bookings b ON c.CustomerId=b.CustomerId
INNER JOIN Rooms r ON b.RoomId=r.RoomId
ORDER BY b.BookingId;

--Show all rooms ordered by number of guests
SELECT *
FROM Rooms
WHERE SizeSquareMeters > 20
ORDER BY NumberOfGuests DESC
