USE Hotel;

SELECT c.FirstName, c.LastName, c.Phone, r.RoomId, r.[Type], r.Size 
FROM Customers c
INNER JOIN Bookings b ON c.CustomerId=b.CustomerId
INNER JOIN Rooms r ON b.RoomId=r.RoomId
ORDER BY c.CustomerId Desc

SELECT *
FROM Rooms
ORDER BY NumberOfGuests DESC