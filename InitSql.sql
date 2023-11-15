----------------------------------------------------------------------------------------------------------
------------------------------------ CREATE DATABASE -----------------------------------------------------
----------------------------------------------------------------------------------------------------------
DROP DATABASE IF EXISTS bankproject;
GO

CREATE DATABASE bankproject;
GO

----------------------------------------------------------------------------------------------------------
------------------------------------- CREATE TABLES ------------------------------------------------------
----------------------------------------------------------------------------------------------------------
USE bankproject;
GO

---------------------------------------------------------------------------------
-------------------- CREATE TABLE POSITIONS -------------------------------------
---------------------------------------------------------------------------------
DROP TABLE IF EXISTS dbo.Positions;
GO

CREATE TABLE dbo.Positions (
	positionID						INT				PRIMARY KEY		IDENTITY,
	position						VARCHAR(50),
	isAllowedFinancialTransations	BIT,
	isAllowedSystemUser				BIT,
	isAllowedCustomerProfile		BIT
);
GO

---------------------------------------------------------------------------------
-------------------- CREATE TABLE EMPLOYEES -------------------------------------
---------------------------------------------------------------------------------
DROP TABLE IF EXISTS dbo.Employees;
GO

CREATE TABLE dbo.Employees (
	employeeID		INT				PRIMARY KEY		IDENTITY,
	firstName		VARCHAR(50),
	lastName		VARCHAR(50),
	email			VARCHAR(50),
	phone			VARCHAR(50),
	positionId		INT				FOREIGN KEY REFERENCES Positions(positionID),
	password		VARCHAR(8)
);
GO


----------------------------------------------------------------------------------------------------------
-------------------------------------- INSERT DATA -------------------------------------------------------
----------------------------------------------------------------------------------------------------------
USE bankproject;
GO


---------------------------------------------------------------------------------
--------------- INSERT DATA INTO TABLE POSITIONS --------------------------------
---------------------------------------------------------------------------------
INSERT INTO dbo.Positions (position, isAllowedFinancialTransations, isAllowedSystemUser,isAllowedCustomerProfile)
VALUES
	('admin', 1, 1, 1),
	('Teller', 1, 0,0),
	('Customer Service', 0, 0, 1)
GO


---------------------------------------------------------------------------------
--------------- INSERT DATA INTO TABLE POSITIONS --------------------------------
---------------------------------------------------------------------------------
INSERT INTO dbo.Employees (firstName, lastName , email , phone , positionId , password)
VALUES
	('admin', 'admin', '', '', 1, 'admin'),
	('teller', 'teller','', '', 2, 'teller'),
	('customer', 'service','', '', 3, 'service')
GO









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
