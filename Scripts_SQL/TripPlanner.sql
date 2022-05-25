USE p1g1
GO

CREATE SCHEMA TripPlanner
GO


CREATE TABLE TripPlanner.Person(
	Sex CHAR NOT NULL,
	PfName VARCHAR(15) NOT NULL,
	PmName VARCHAR(15) NOT NULL,
	PlName VARCHAR(15) NOT NULL,
	Email VARCHAR(30) NOT NULL,
	CC VARCHAR(8) NOT NULL PRIMARY KEY,
	PAddress VARCHAR(30) NOT NULL,
	CHECK(Sex='F' OR Sex='M'),
	CHECK(CC LIKE '[0-9][0-9][0-9][0-9][0-9][0-9][0-9][0-9]')
);


CREATE TABLE TripPlanner.Trip(
	TrType VARCHAR(15) NOT NULL,
	TrInclude VARCHAR(50) NOT NULL,
	TrNoInclude VARCHAR(50) NOT NULL,
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Price INT NOT NULL,
	Duration INT NOT NULL,
	Departure_Date DATE NOT NULL,
	TrState VARCHAR(10) NOT NULL,
	Elaborator_CC VARCHAR(8) NOT NULL FOREIGN KEY REFERENCES TripPlanner.Person(CC)
);


CREATE TABLE TripPlanner.POInterest(
	Email VARCHAR(30) NOT NULL,
	Rating INT NOT NULL,
	PoIName VARCHAR(15) NOT NULL,
	Contact VARCHAR(15) NOT NULL PRIMARY KEY,
	Price VARCHAR(10) NOT NULL,
	PoIAddress VARCHAR(30) NOT NULL,
	CHECK(Rating >= 0 and Rating <= 5)
);

CREATE TABLE TripPlanner.Restaurant(
	RContact VARCHAR(15) PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.POInterest(Contact),
	Stars INT NOT NULL,
	Specialty VARCHAR(15) NOT NULL,
	CHECK(Stars>=0 and Stars <=3)
);

CREATE TABLE TripPlanner.Museum(
	MContact VARCHAR(15) PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.POInterest(Contact),
	Synopsis VARCHAR(100) NOT NULL,
	Theme VARCHAR(20) NOT NULL 
);

CREATE TABLE TripPlanner.Store(
	RContact VARCHAR(15) PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.POInterest(Contact),
	SType VARCHAR(15) NOT NULL 
);

CREATE TABLE TripPlanner.PoIEvent(
	RContact VARCHAR(15) PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.POInterest(Contact),
	EType VARCHAR(15) NOT NULL 
);

CREATE TABLE TripPlanner.Stay(
	Email VARCHAR(30) NOT NULL,
	Rating INT NOT NULL,
	SName VARCHAR(15) NOT NULL,
	Contact VARCHAR(15) NOT NULL PRIMARY KEY,
	SAddress VARCHAR(30) NOT NULL,
	CHECK(Rating >= 0 and Rating <= 5)
);


CREATE TABLE TripPlanner.City(
	CName VARCHAR(15) NOT NULL PRIMARY KEY,
	Country VARCHAR(15) NOT NULL,
	Continent VARCHAR(15) NOT NULL,
	Stay_Contact VARCHAR(15) NOT NULL FOREIGN KEY REFERENCES TripPlanner.Stay(Contact),
	PoI_Contact VARCHAR(15) NOT NULL FOREIGN KEY REFERENCES TripPlanner.PoInterest(Contact),
	CHECK(Continent='Europa' or Continent='Asia' or Continent='Ocenia' or Continent='Africa' or Continent='America')
);

CREATE TABLE TripPlanner.Transport(
	ID INT IDENTITY(1,1) PRIMARY KEY,
	Price INT NOT NULL, 
	Departure DATE NOT NULL,
	Arrival DATE NOT NULL,
	Num_seats INT NOT NULL,
	CHECK(Num_seats > 0),
	CHECK(Departure <= Arrival)
);

CREATE TABLE TripPlanner.Car(
	Car_ID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.Transport(ID),
	Brand VARCHAR(15) NOT NULL,
	Registration VARCHAR(15) NOT NULL
);

CREATE TABLE TripPlanner.Plane(
	Plane_ID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.Transport(ID),
	Company VARCHAR(15) NOT NULL,
	Plane_Type VARCHAR(15) NOT NULL
);

CREATE TABLE TripPlanner.Train(
	Train_ID INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES TripPlanner.Transport(ID),
	Company VARCHAR(15) NOT NULL,
	Train_Type VARCHAR(15) NOT NULL
);

CREATE TABLE TripPlanner.Has(
	Person_CC VARCHAR(8) NOT NULL,
	Trip_ID INT NOT NULL,
	PRIMARY KEY (Person_CC, Trip_ID),
	FOREIGN KEY (Person_CC) REFERENCES TripPlanner.Person(CC),
	FOREIGN KEY (Trip_ID) REFERENCES TripPlanner.Trip(ID)
);

CREATE TABLE TripPlanner.Done_In(
	City_Name VARCHAR(15) NOT NULL,
	Trip_ID INT NOT NULL,
	PRIMARY KEY (City_Name, Trip_ID),
	FOREIGN KEY (Trip_ID) REFERENCES TripPlanner.Trip(ID),
	FOREIGN KEY (City_Name) REFERENCES TripPlanner.City(CName)
);

CREATE TABLE TripPlanner.Can_Have(
	Transport_ID INT NOT NULL,
	Trip_ID INT NOT NULL,
	PRIMARY KEY (Transport_ID, Trip_ID),
	FOREIGN KEY (Transport_ID) REFERENCES TripPlanner.Transport(ID),
	FOREIGN KEY (Trip_ID) REFERENCES TripPlanner.Trip(ID)
);

