drop database bankproject;
GO
USE bankproject;


create table Positions (
	positionID int primary key,
	position varchar(50),
	isAllowedFinancialTransations bit,
	isAllowedSystemUser bit,
	isAllowedCustomerProfile bit)

insert into Positions (positionID, position, isAllowedFinancialTransations, isAllowedSystemUser,isAllowedCustomerProfile)
values
(1, 'admin', 1, 1, 1),
(2, 'Teller', 1, 0,0),
(3, 'Customer Service', 0, 0, 1) 


create table Employees (
	employeeID int primary key,
	firstName varchar(50),
	lastName varchar(50),
	email varchar(50),
	phone varchar(50),
	positionId int FOREIGN KEY REFERENCES Positions(positionID),
	password varchar(8)
	)

insert into Employees (employeeID ,	firstName,	lastName ,	email ,	phone ,	positionId ,password)
values (1, 'admin', 'admin', '', '', 1, 'admin'),
(2, 'teller', 'teller','', '', 2, 'teller'),
(3, 'customer', 'service','', '', 3, 'service')

--SELECT TOP (10) [zipcode]
--      ,[city]
--      ,[province]
--  FROM [zipcode].[dbo].[zipcode]
--  WHERE zipcode = 'T2R 1C4';

--  create table customers (
--  PersonId int Primary Key,
--  firstName varchar(50),
--  lastName varchar(50),
--  email varchar(50),
--  phone varchar(50),
--  addressZip varchar(7),
--  addressSt varchar(15),
--  addressNum int,
--  addressUnit varchar(10),
--  addressCity varchar(10),
--  addressProvince varchar(10)
--  );
