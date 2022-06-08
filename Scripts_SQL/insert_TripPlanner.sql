-- Usar estes templates para fazer inserts

-- insert into TripPlanner.City(CName, Country, Continent, Stay_Contact, PoI_Contact) values();
-- insert into TripPlanner.Done_In(City_Name, Trip_ID) values();
-- insert into TripPlanner.Has(Person_CC, Trip_ID) values();
-- insert into TripPlanner.Museum(MContact, Synopsis, Theme) values();
-- insert into TripPlanner.Person(Sex, PfName, PmName, PIName, Email, CC, PAddress) values();
-- insert into TripPlanner.PoIEvent(RContact, EType) values();
-- insert into TripPlanner.POInterest(Email, Rating, PoIName, Contact, TrType, Price, PoIAddress, PoIType) values();
-- insert into TripPlanner.Restaurant(RContact, Stars, Speciality) values();
-- insert into TripPlanner.Stay(Email, Rating, SName, Contact, TrType, SAddress, StayType) values();
-- insert into TripPlanner.Store(RContact, SType) values();
-- insert into TripPlanner.Trip(TrType, TrName, Price, Duration, Departure, TrState, Elaborator_CC) values();
-- insert into TripPlanner.TripType(TypeName) values();

insert into TripPlanner.POInterest(Email, Rating, PoIName, Contact, Price, PoIAddress, PoIType) values('restauranteEsquina@gmail.com', '4', 'restauranteEsquina', '960594359', '€€', 'Rua Esquina', 'Casual');
insert into TripPlanner.POInterest(Email, Rating, PoIName, Contact, Price, PoIAddress, PoIType) values('restaurantLounge@gmail.com', '5', 'Restaurante Lounge', '960123459', '€€€', 'Rua Alberto', 'Lux');
insert into TripPlanner.POInterest(Email, Rating, PoIName, Contact, Price, PoIAddress, PoIType) values('grelhados@gmail.com', '4', 'grelhados', '960535994', '€', 'Rua grills', 'Low Cost');
insert into TripPlanner.Restaurant(RContact, Stars, Specialty) values('960594359', '0', 'Bacalhau à Brás');
insert into TripPlanner.Restaurant(RContact, Stars, Specialty) values('960123459', '2', 'Risoto à chefe');
insert into TripPlanner.Restaurant(RContact, Stars, Specialty) values('960535994', '0', 'Bacalhau à Brás');

insert into TripPlanner.Person(Sex, PfName, PmName, PIName, Email, CC, PAddress) values('M', 'João', 'G.', 'Fernandes', 'joaogilfernandes@gmail.com', '02030402', 'Miami');
insert into TripPlanner.Person(Sex, PfName, PmName, PIName, Email, CC, PAddress) values('M', 'David', 'E.', 'Raposo', 'daividRap@gmail.com', '02318473', 'Lisboa');
insert into TripPlanner.Person(Sex, PfName, PmName, PIName, Email, CC, PAddress) values('F', 'Catarina', 'H.', 'Almeida', 'catAlm@gmail.com', '03494372', 'Paris');

insert into TripPlanner.Stay(Email, Rating, SName, Contact, SAddress, StayType) values('aveiroPal@gmail.com', '5', 'Palace', '943584712', 'rua Palace', 'Lux');
insert into TripPlanner.Stay(Email, Rating, SName, Contact, SAddress, StayType) values('hotelRural@gmail.com', '3', 'Hotel Rural', '942753967', 'rua Cabrita', 'Low Cost');
insert into TripPlanner.Stay(Email, Rating, SName, Contact, SAddress, StayType) values('casaAveiro@gmail.com', '4', 'Casa Aveiro', '924789712', 'rua Afonso', 'Cultural');



insert into TripPlanner.City(CName, Country, Continent, Stay_Contact, PoI_Contact) values('Aveiro', 'Portugal', 'Europa', '943584712', '960123459');

insert into TripPlanner.Trip(TrType, TrName, Price, Duration, Departure, TrState, Elaborator_CC) values(1, 'Trip Aveiro', '500', '4', '2022-06-09', 'Scheduled', '02030402');

insert into TripPlanner.Has(Person_CC, Trip_ID) values('02030402', 1);
insert into TripPlanner.Has(Person_CC, Trip_ID) values('02318473', 1);
insert into TripPlanner.Has(Person_CC, Trip_ID) values('03494372', 1);

insert into TripPlanner.Done_In(City_Name, Trip_ID) values('Aveiro', 1);

insert into TrType(ID,TypeName) values (1,'Cultural');
insert into TrType(ID,TypeName) values (2,'Luxo');
insert into TrType(ID,TypeName) values (3,'Casual');
insert into TrType(ID,TypeName) values (3,'Low Cost');