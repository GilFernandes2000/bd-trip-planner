GO 
CREATE FUNCTION getTripById (@ID INT) RETURNS TABLE AS
	RETURN(SELECT * FROM TripPlanner.Trip
		   WHERE ID = @ID)
GO

SELECT * FROM getTripById(1);

--------------------------------------------

GO 
CREATE FUNCTION getTripByType (@TrType INT) RETURNS TABLE AS
	RETURN(SELECT * FROM TripPlanner.Trip
		   WHERE TrType = @TrType)
GO

SELECT * FROM getTripByType(1);

----------------------------------------------------

GO 
CREATE FUNCTION getTripByPrice (@Price INT) RETURNS TABLE AS
	RETURN(SELECT * FROM TripPlanner.Trip
		   WHERE price < @Price)
GO

SELECT * FROM getTripByPrice(1000);

--------------------------------------------------

GO 
CREATE FUNCTION getTripByName (@TrName VARCHAR(30)) RETURNS TABLE AS
	RETURN(SELECT * FROM TripPlanner.Trip
		   WHERE TrName = @TrName)
GO

SELECT * FROM getTripByName('Trip Quintela');

--------------------------------------------------
--------------------------------------------------

GO 
CREATE FUNCTION getPoIByCity (@City VARCHAR(15)) RETURNS TABLE AS
	RETURN(SELECT * 
		   FROM TripPlanner.POInterest
		   WHERE City = @City)
GO

SELECT * FROM getPoIByCity('New York');

---------------------------------------------------

GO 
CREATE FUNCTION getStayByCity (@City VARCHAR(15)) RETURNS TABLE AS
	RETURN(SELECT * 
		   FROM TripPlanner.Stay
		   WHERE City = @City)
GO

SELECT * FROM getStayByCity('Paris');

----------------------------------------------------------

GO 
CREATE FUNCTION getPersonByTrip (@Trip VARCHAR(15)) RETURNS TABLE AS
	RETURN(SELECT PfName, PmName, PlName 
		   FROM TripPlanner.Has, TripPLanner.Trip, TripPlanner.Person
		   WHERE @Trip = TrName AND ID = Trip_ID AND Person_CC = CC)
GO

SELECT * FROM getPersonByTrip('Trip Aveiro');

-----------------------------------------------------------

GO 
CREATE FUNCTION getPersonByCC (@CC VARCHAR(8)) RETURNS TABLE AS
	RETURN(SELECT PfName, PmName, PlName 
		   FROM TripPlanner.Person
		   WHERE CC = @CC)
GO

SELECT * FROM getPersonByCC('02030402');


---------------------------------------------------------------

GO 
CREATE FUNCTION getTripVisit (@Trip VARCHAR(15)) RETURNS TABLE AS
	RETURN(SELECT PoIName, PoIAddress
		   FROM TripPlanner.Visit,TripPlanner.Trip,TripPlanner.POInterest
		   WHERE TrName = @Trip AND ID = Trip_ID AND POIContact = Contact)
GO

SELECT * FROM getTripVisit('Trip Aveiro');

--------------------------------------------------------------

GO 
CREATE FUNCTION getTripbyTripType (@TrType VARCHAR(15)) RETURNS TABLE AS
	RETURN(SELECT *
		   FROM TripPlanner.Trip t,TripPlanner.TripType tp
		    WHERE @TrType = TypeName AND t.ID = tp.ID)
GO

SELECT * FROM getTripbyTripType('Cultural');
