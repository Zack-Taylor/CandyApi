create table Candy (
	CandyId int not null Identity(1,1) Primary Key,
	[Name] varchar(100) not null,
	Manufacturer varchar(100) not null,
	FlavorId int not null,
	DateCollected date not null,
	Ate bit not null,
)

Insert into Candy(StashId, [Name], Manufacturer, FlavorId, DateCollected, Ate)
Values(1,'Snickers', 'Mars', 1, '2020-05-19', 1),
      (1, 'Reese', 'Hershey', 5, '2020-05-16', 1),
      (2, 'Nerds', 'Nestle', 4, '2020-05-05', 0),
      (1, 'KitKat', 'Hershey', 1, '2020-05-01', 1),
      (2, 'Sweet Tarts', 'Nestle', 4, '2020-05-15', 0),
      (1, 'Werthers', 'Nestle', 3, '2020-05-17', 1)

create table Flavor (
	FlavorId int not null Identity(1,1) Primary Key,
	FlavorName varchar(100)
)

insert into Flavor (FlavorName)
values('Chocolate'),
	  ('Caramel'),
	  ('Coffee'),
	  ('Cotton Candy'),
	  ('Peanut Butter'),
	  ('Vanilla')

create table [User] (
	Uid int not null Identity(1,1) Primary Key,
	[Name] varchar(100)
)

insert into [User] ([Name])
values ('Macbeth'),
	   ('Romeo'),
       ('Prospero'),
       ('Caliban'),
       ('Mercutio'),
       ('Puck')

create table Stash (
	StashId int not null Identity(1,1) Primary Key,
	CandyId int not null,
	UserId int not null
)

insert into Stash (CandyId, UserId)
Values(1,1),
      (2,2),
      (3,1),
      (4,2),
      (5,1),
      (5,2)



ALTER TABLE Candy
ADD StashId int;

select * from Candy

select * from [User]

select * from Flavor