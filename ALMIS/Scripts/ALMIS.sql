create database ALMIS
go
use ALMIS
go
create table [User]
(
	Id UNIQUEIDENTIFIER primary Key default NEWID(),
	Username nvarchar (50) unique not null,
	[Password] nvarchar (100) not null,
	[Name]nvarchar (50) not null,
	LastName nvarchar (50) not null,
	Email  nvarchar (100) unique not null
)
go
insert into [User] values (NEWID(), 'admin', 'admin2468','Admin','User', 'admin@gmail.com')
insert into [User] values (NEWID(), 'cameron', 'admin2468','Cameron','Matheson-Dear', 'cameron@gmail.com')
insert into [User] values (NEWID(), 'emma', 'admin2468','Emma','Almis', 'emma@gmail.com')
go

select *from [User]