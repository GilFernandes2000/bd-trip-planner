
create view TripPlanner.personInfo as
    select * 
	from TripPlanner.Person p
go 

create view TripPlanner.Locais as
	select *
	from TripPlanner.POInterest poi
go

create view TripPlanner.Locais as 
	select *
	from TripPlanner.POInterest

create view TripPalnner.Cidade as
	select poi.PoIName, s.SName
	from TripPlanner.POInterest poi, TripPlanner.Stay s, TripPlanner.City c
	where poi.Contact = c.PoI_Contact and s.Contact = c.Stay_Contact