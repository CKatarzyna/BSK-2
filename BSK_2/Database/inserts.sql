USE BSK_2
GO

Select * from Film;
Select * from Rezyser;
Select * from Aktor;
Select * from AktorWystepuje;

Insert into Film (Nazwa, Typ, Rok_Wydania, Ocena, Czas_Trwania, Odnosnik) values ('The Professor', 'Drama', 2019, 7.0, 1.30, 'https://www.filmweb.pl/film/The+Professor-2018-806052');
Insert into Rezyser (Imie, Nazwisko, Odnosnik) values ('Wayne', 'Roberts', 'https://www.filmweb.pl/person/Wayne+Roberts-2319174');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Zoey', 'Deutch', 'USA', '10-11-1994', 'https://www.filmweb.pl/person/Zoey+Deutch-1121307');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Johnny', 'Depp', 'USA', '09-06-1965', 'https://www.filmweb.pl/person/Johnny.Depp');

Insert into Film (Nazwa, Typ, Rok_Wydania, Ocena, Czas_Trwania, Odnosnik) values ('Murder on the Orient Express', 'Crime', 2017, 6.5, 1.54, 'https://www.filmweb.pl/film/Morderstwo+w+Orient+Expressie-2017-746114');
Insert into Rezyser (Imie, Nazwisko, Odnosnik) values ('Kenneth', 'Branagh', 'https://www.filmweb.pl/person/Kenneth+Branagh-12');

Insert into Film (Nazwa, Typ, Rok_Wydania, Ocena, Czas_Trwania, Odnosnik) values ('The Hateful Eight', 'Western', 2015, 7.6, 3.07, 'https://www.filmweb.pl/film/Nienawistna+%C3%B3semka-2015-714192');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Kurt', 'Russell', 'USA', '03-17-1951', 'https://www.filmweb.pl/person/Kurt.Russell');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Samuel', 'L. Jackson', 'USA', '12-21-1948', 'https://www.filmweb.pl/person/Samuel.Jackson');

Insert into Film (Nazwa, Typ, Rok_Wydania, Ocena, Czas_Trwania, Odnosnik) values ('Django Unchained', 'Western', 2012, 8.3, 2.45, 'https://www.filmweb.pl/film/Django-2012-620541');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Leonardo', 'DiCaprio', 'USA', '11-11-1974', 'https://www.filmweb.pl/person/Leonardo.Dicaprio');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Christoph', 'Waltz', 'Austria', '04-10-1956', 'https://www.filmweb.pl/person/Christoph.Waltz');
Insert into Aktor (Imie, Nazwisko, Narodowosc, Data_Urodzenia, Odnosnik) values ('Jamie', 'Fox', 'USA', '12-13-1967', 'https://www.filmweb.pl/person/Jamie.Foxx');
Insert into Rezyser (Imie, Nazwisko, Odnosnik) values ('Quentin', 'Tarantino', 'https://www.filmweb.pl/person/Quentin.Tarantino');

Update Film Set Id_Rezyser = 1 Where Nazwa = 'The Professor';
Update Film Set Id_Rezyser = 2 Where Nazwa = 'Murder on the Orient Express';
Update Film Set Id_Rezyser = 3 Where Nazwa = 'The Hateful Eight' or  Nazwa = 'Django Unchained';


Select * from Film;
Select * from Aktor;

Insert into AktorWystepuje (Id_Film, Id_Aktor) values (1, 1);
Insert into AktorWystepuje (Id_Film, Id_Aktor) values (1, 2);

Insert into AktorWystepuje (Id_Film, Id_Aktor) values (2, 2);

Insert into AktorWystepuje (Id_Film, Id_Aktor) values (3, 3);
Insert into AktorWystepuje (Id_Film, Id_Aktor) values (3, 4);

Insert into AktorWystepuje (Id_Film, Id_Aktor) values (4, 4);
Insert into AktorWystepuje (Id_Film, Id_Aktor) values (4, 5);
Insert into AktorWystepuje (Id_Film, Id_Aktor) values (4, 6);
Insert into AktorWystepuje (Id_Film, Id_Aktor) values (4, 7);

Insert into Konto(Login_, Haslo, Uprawnienia) values ('user', '6ygU*yrt$>2', 'MODERATOR');
Update Film Set Id_Konto = 1 Where Nazwa = 'The Professor';