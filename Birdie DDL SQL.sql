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

-- Add BasicColours

INSERT INTO BasicColour VALUES ('Black');
INSERT INTO BasicColour VALUES ('White');
INSERT INTO BasicColour VALUES ('Red');
INSERT INTO BasicColour VALUES ('Blue');
INSERT INTO BasicColour VALUES ('Yellow');
INSERT INTO BasicColour VALUES ('Orange');
INSERT INTO BasicColour VALUES ('Purple');
INSERT INTO BasicColour VALUES ('Green');
INSERT INTO BasicColour VALUES ('Brown');
INSERT INTO BasicColour VALUES ('Pink');

INSERT INTO OfficialColour VALUES ('Crimson', 3);
INSERT INTO OfficialColour VALUES ('Black', 1);
INSERT INTO OfficialColour VALUES ('Fuchsia', 10);
INSERT INTO OfficialColour VALUES ('Dark Green', 8);


INSERT INTO Ball VAlUES ('FunSports 4', 7, 6, 400, 450, 600, 400);
INSERT INTO Ball VAlUES ('FunSports 3', 7, 8, 300, 300, 990, 375);
INSERT INTO Ball VAlUES ('FunSports 2', 7, 9, 600, 550, 400, 425);
INSERT INTO Ball VAlUES ('FunSports 1', 7, 10, 100, 300, 600, 400);

INSERT INTO Manufacturer VALUES ('Deutchman');
INSERT INTO Manufacturer VALUES ('Noppel');
