create index idx_TripType on TripPlanner.TripType(ID);

create index idx_CityName on TripPlanner.City(CName);

create index idx_POIContact on TripPlanner.POInterest(Contact);

create index idx_StayContact on TripPlanner.Stay(Contact);

create index idx_TripID on TripPlanner.Trip(ID);

create index idx_PersonCC on TripPlanner.Person(CC);