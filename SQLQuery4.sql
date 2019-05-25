CREATE TABLE Movies(
	ID INTEGER IDENTITY(1,1) PRIMARY KEY,
	Name varchar(20) NOT NULL,
	Categorie varchar(20) NOT NULL,
	Description varchar(200),
	Photo BIT  
)
GO

Select * from Movies;

