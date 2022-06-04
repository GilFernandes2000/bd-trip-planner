GO

CREATE PROCEDURE TripPlanner.AddTrip(
	@TrType INT,
	@TrName varchar(15),
	@Price INT,
	@Duration INT,
	@Departure_Date DATE,
	@TrState VARCHAR(10),
	@Elaborator_CC VARCHAR(8))

AS

BEGIN
	SET nocount ON
	BEGIN
		SET IDENTITY_INSERT TripPlanner.Trip OFF
		INSERT INTO TripPlanner.Trip(TrType,TrName,Price,Duration,Departure_Date,TrState,Elaborator_CC)
		VALUES (@TrType,@TrName,@Price,@Duration,@Departure_Date,@TrState,@Elaborator_CC);
		PRINT 'Criado com sucesso!'
		
	END
END

--Drop Procedure TripPlanner.AddTrip;
--EXEC TripPlanner.AddTrip
	--@TrType = 2,
	--@TrName = 'Viagem a Quintelaaaaa',
	--@Price = 2000,
	--@Duration = 4,
	--@Departure_Date = '2022-06-11',
	--@TrState = 'ON',
	--@Elaborator_CC = '02318473'