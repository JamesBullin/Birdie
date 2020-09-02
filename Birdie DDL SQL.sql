DROP DATABASE Birdie;
CREATE DATABASE Birdie;
USE Birdie;
-- Create Tables

CREATE TABLE Ball
(
	ID INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(50),
	ManufacturerID INT,
	OfficialColourID INT,
	BounceInMillimetres INT,
	WeightInTenthsOfGram INT,
	ShoreInTenthsOfDurometre INT,
	SizeInMillimetres INT,
);

CREATE TABLE Manufacturer
(
	ID INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(50)  NOT NULL
);

CREATE TABLE OfficialColour
(
	ID INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(50)  NOT NULL,
	BasicColourID INT  NOT NULL
);

CREATE TABLE BasicColour
(
	ID INT NOT NULL IDENTITY PRIMARY KEY,
	Name VARCHAR(50)  NOT NULL
);

-- Foreign Keys

ALTER TABLE Ball
ADD FOREIGN KEY (ManufacturerID) REFERENCES Manufacturer(ID),
FOREIGN KEY (OfficialColourID) REFERENCES OfficialColour(ID);

ALTER TABLE OfficialColour
ADD FOREIGN KEY (BasicColourID) REFERENCES BasicColour(ID);
