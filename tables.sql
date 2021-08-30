use [diploma]
 
drop table Users;
drop table Doctors;
drop table Patients;
drop table Tickets;
drop table Journals;

use [diploma]
drop table Tickets;


use [diploma]
create table Users
(
	userId int PRIMARY KEY,
	fullName nvarchar(60),
	login nvarchar(20),
	password nvarchar(50),
	role nvarchar(20)
);

create table Doctors
(
	doctorId int primary key, 
	userId int FOREIGN KEY REFERENCES Users(userId),
	building nvarchar(20),
	department nvarchar(20)
);

create table Patients
(
	patientId int primary key, 
	userId int FOREIGN KEY REFERENCES Users(userId),
	birthDate nvarchar(20),
	address nvarchar(30),
	phone nvarchar(20),
	email nvarchar(30)
);

use diploma
create table Tickets
(
	id int PRIMARY KEY,
	doctorId int,
	patientId int,
	doctorName nvarchar(60),
	date nvarchar(20),
	time nvarchar(10)
);

create table Journals
(
	id int PRIMARY KEY,
	doctorId int FOREIGN KEY REFERENCES Doctors(doctorId), 
	patientId int foreign key references Patients(patientId),
	date nvarchar(20),
	issue nvarchar(200),
	decision nvarchar(200)
);

create table Receipts
(
	id int PRIMARY KEY, 
	patientId int foreign key references Patients(patientId),
	drugName nvarchar(30),
	date nvarchar(20)
);

use [diploma]
delete from Patients;
delete from Doctors;

drop table Users;