USE BSK_2
GO
Select * from Film;
Select * from Rezyser;
Select * from Aktor;
Select * from AktorWystepuje;

--wyswietlenie filmu oraz jego rezysera
Select Film.Nazwa,Rezyser.Imie, Rezyser.Nazwisko 
from Film
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser;
--Where Rezyser.Imie = 'Quentin';

--! REZYSER
Select Rezyser.Imie, Rezyser.Nazwisko, Rezyser.Narodowosc, Rezyser.Data_Urodzenia, Rezyser.Odnosnik
from Film
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser
Where Film.Nazwa = 'The Professor';

UPDATE Rezyser
SET Imie = 'Wayne', Nazwisko = '', Narodowosc = '', Data_Urodzenia = '', Odnosnik = ''
WHERE Rezyser.Nazwisko = 'Roberts';

UPDATE Rezyser 
SET Imie = 'Quentin', Nazwisko = 'Tarantino', Narodowosc = 'Usa', Data_Urodzenia = '', Odnosnik = 'https://www.filmweb.pl/person/Quentin.Tarantino' 
WHERE Rezyser.Nazwisko = 'Tarantino';

--wyswietlenie filmu oraz aktorow w nim wystepujacych
Select Film.Nazwa, Aktor.Imie, Aktor.Nazwisko
from Film
Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor;
--Where Aktor.Imie = 'Samuel';
--Where Film.Nazwa = 'Django Unchained';

--!
Select Film.Nazwa, Rezyser.Imie, Rezyser.Nazwisko, Film.Rok_Wydania, Film.Typ,  Film.Ocena, Film.Czas_Trwania, Film.Odnosnik
from Film
Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser
Where Aktor.Imie = 'Samuel';
--Where Film.Nazwa = 'Django Unchained';

 --wyswietlenie full info odnosnie filmu
 Select Film.Nazwa, Rezyser.Imie, Rezyser.Nazwisko, Aktor.Imie, Aktor.Nazwisko, Film.Typ, Film.Ocena, Film.Czas_Trwania, Film.Rok_Wydania
from Film
Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser;

 --! FILM
Select Film.Nazwa, Film.Rok_Wydania, Film.Typ, Film.Ocena, Film.Czas_Trwania, Film.Odnosnik
from Film
Where Film.Nazwa = 'The Professor';


Select Rezyser.Imie, Rezyser.Nazwisko, Aktor.Imie, Aktor.Nazwisko, Film.Typ, Film.Ocena, Film.Czas_Trwania, Film.Rok_Wydania
from Film
Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser
Where Film.Nazwa = 'The Professor';

--! AKTOR
Select  Aktor.Imie, Aktor.Nazwisko, Aktor.Narodowosc, Aktor.Biografia, Aktor.Data_Urodzenia, Aktor.Odnosnik
from Film
Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor
Where Film.Nazwa = 'The Professor';

--! ktore sa dluzsze niz 1.5h
Select Film.Nazwa, Rezyser.Imie, Rezyser.Nazwisko, Film.Rok_Wydania, Film.Typ,  Film.Ocena, Film.Czas_Trwania, Film.Odnosnik
from Film
Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser
Where Film.Czas_Trwania > 1.5;

USE BSK_2
GO
SELECT Konto.Uprawnienia
FROM Konto
WHERE Konto.Login_ = 'dsd';