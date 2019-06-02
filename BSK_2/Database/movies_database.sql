CREATE DATABASE BSK_2
GO

USE BSK_2
GO

CREATE TABLE Rezyser (
	Id_Rezyser INTEGER IDENTITY(1,1) PRIMARY KEY,
	Imie varchar(20),
	Nazwisko varchar(20),
	Narodowosc varchar(20),
	Data_Urodzenia datetime,
	Odnosnik varchar(70),
)
GO

CREATE TABLE Konto (
	Id_Konto INTEGER IDENTITY(1,1) PRIMARY KEY,
	Login_ varchar(20),
	Haslo varchar(20),
	Uprawnienia varchar(30),
)
GO

CREATE TABLE Film (
	Id_Film INTEGER IDENTITY(1,1) PRIMARY KEY,
	Id_Rezyser INTEGER,
	Id_Konto INTEGER,
	Nazwa varchar(30),
	Typ varchar(20),
	Rok_Wydania varchar(4),
	Ocena INTEGER,
	Czas_Trwania INTEGER,
	Opis varchar(300),
	Zdjecie varchar(70),
	Odnosnik varchar(70),
	FOREIGN KEY (Id_Rezyser) REFERENCES Rezyser (Id_Rezyser)
       ON DELETE CASCADE,
	FOREIGN KEY (Id_Konto) REFERENCES Konto (Id_Konto)
       ON DELETE CASCADE
)
GO

CREATE TABLE Aktor (
	Id_Aktor INTEGER IDENTITY(1,1) PRIMARY KEY,
	Imie varchar(20),
	Nazwisko varchar(20),
	Narodowosc varchar(20),
	Data_Urodzenia datetime,
	Biografia varchar(300),
	Odnosnik varchar(70),
)
GO

CREATE TABLE AktorWystepuje (
	Id_Film INTEGER,
	Id_Aktor INTEGER,
	FOREIGN KEY (Id_Film) REFERENCES Film (Id_Film)
       ON DELETE CASCADE,
	FOREIGN KEY (Id_Aktor) REFERENCES Aktor (Id_Aktor)
       ON DELETE CASCADE
)
GO

USE BSK_2;
DROP TABLE AktorWystepuje;
DROP TABLE Aktor;
DROP TABLE Film;
DROP TABLE Rezyser;
DROP TABLE Konto;

USE BSK_2;
Select * from Rezyser;
Select * from Aktor;
Select * from Konto;
Select * from Uzytkownik;
Select * from Film;
Select * from Rezyser;