using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace BSK_2
{
    // TODO: -optional Change date format
    class DataBase
    {
        public DataBase()
        {

        }

        public string GetConnectionString()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BSK_2;Data Source=(local)";
        }

        public string GetUserPermissionRights(string userLogin, string connectionString)
        {
            //SELECT Konto.Uprawnienia
            //FROM Konto
            //WHERE Konto.Login_ = 'fdds';

            string returnPerrmision = "";
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("SELECT Konto.Uprawnienia " +
                                                         "FROM Konto " +
                                                         "Where Konto.Login_ = @UserLogin; ", sqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@UserLogin", userLogin);
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();

                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    returnPerrmision = row["Uprawnienia"].ToString();
                }
            }
            return returnPerrmision;
        }

        public void SelectMovieDirectors(string movieTitle, string connectionString, ListView listView)
        {
            //Select Rezyser.Imie, Rezyser.Nazwisko, Rezyser.Narodowosc, Rezyser.Data_Urodzenia, Rezyser.Odnosnik
            //from Film
            //Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser
            //Where Film.Nazwa = 'The Professor';

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select Rezyser.Imie, Rezyser.Nazwisko, Rezyser.Narodowosc, " +
                                                         "Rezyser.Data_Urodzenia, Rezyser.Odnosnik from Film " +
                                                         "Inner Join Rezyser On Film.Id_Rezyser = Rezyser.Id_Rezyser " +
                                                         "Where Film.Nazwa = @MovieTitle; ", sqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@MovieTitle", movieTitle);
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                List<Director> items = new List<Director>();

                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    items.Add(new Director()
                    {
                        Name = row["Imie"].ToString(),
                        Surname = row["Nazwisko"].ToString(),
                        Nationality = row["Narodowosc"].ToString(),
                        DateOfBirth = row["Data_Urodzenia"].ToString(),
                        Source = row["Odnosnik"].ToString()
                    });
                }
                listView.ItemsSource = items;
            }
        }

        public void SelectMovieActors(string movieTitle, string connectionString, ListView listView)
        {
            //Select Aktor.Imie, Aktor.Nazwisko, Aktor.Narodowosc, Aktor.Biografia, Aktor.Data_Urodzenia, Aktor.Odnosnik
            //from Film
            //Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film
            //Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor
            //Where Film.Nazwa = 'The Professor';

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("Select Aktor.Imie, Aktor.Nazwisko, Aktor.Narodowosc, Aktor.Biografia, " +
                                                        "Aktor.Data_Urodzenia, Aktor.Odnosnik from Film " +
                                                        "Inner Join AktorWystepuje On Film.Id_Film = AktorWystepuje.Id_Film " +
                                                        "Inner Join Aktor On AktorWystepuje.Id_Aktor = Aktor.Id_Aktor " +
                                                        "Where Film.Nazwa = @MovieTitle; ", sqlConnection);
                SqlParameter sqlParameter = new SqlParameter("@MovieTitle", movieTitle);
                sqlCommand.Parameters.Add(sqlParameter);

                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                List<Actor> items = new List<Actor>();

                sqlDataAdapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    items.Add(new Actor()
                    {
                        Name = row["Imie"].ToString(),
                        Surname = row["Nazwisko"].ToString(),
                        Nationality = row["Narodowosc"].ToString(),
                        DateOfBirth = row["Data_Urodzenia"].ToString(),
                        Bibliography = row["Biografia"].ToString(),
                        Source = row["Odnosnik"].ToString()
                    });
                }
                listView.ItemsSource = items;
            }
        }

        // TODO: Add exception try-catch
        public int UpdateMovieDirector(string movieDirector, Director director, string connectionString)
        {
            //UPDATE Rezyser
            //SET Imie = 'Wayne', Nazwisko = '', Narodowosc = '', Data_Urodzenia = '', Odnosnik = ''
            //WHERE Rezyser.Nazwisko = 'Roberts';

            int returnValue = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("UPDATE Rezyser " +
                                                        "SET Imie = @NewName, Nazwisko = @NewSurname, Narodowosc = @NewNationality, " +
                                                        "Data_Urodzenia = @NewDateOfBirth, Odnosnik = @NewSource " +
                                                        "WHERE Rezyser.Imie = @MovieDirectorName; ", sqlConnection);
                SqlParameter sqlParameterName = new SqlParameter("@MovieDirectorName", movieDirector);

                // TODO: optimalization, use for example array or smth
                SqlParameter sqlParameterNewName = new SqlParameter("@NewName", director.Name);
                SqlParameter sqlParameterSurname = new SqlParameter("@NewSurname", director.Surname);
                SqlParameter sqlParameterNationality = new SqlParameter("@NewNationality", director.Nationality);
                SqlParameter sqlParameterSource = new SqlParameter("@NewSource", director.Source);
                SqlParameter sqlParameterDateOfBirth = new SqlParameter("@NewDateOfBirth", director.DateOfBirth);

                sqlCommand.Parameters.Add(sqlParameterName);
                sqlCommand.Parameters.Add(sqlParameterNewName);
                sqlCommand.Parameters.Add(sqlParameterSurname);
                sqlCommand.Parameters.Add(sqlParameterNationality);
                sqlCommand.Parameters.Add(sqlParameterDateOfBirth);
                sqlCommand.Parameters.Add(sqlParameterSource);

                sqlCommand.CommandType = System.Data.CommandType.Text;
                returnValue = sqlCommand.ExecuteNonQuery();
            }
            return returnValue;
        }

        public int UpdateMovieActor(string movieActorSurname, Actor actor, string connectionString)
        {
            //UPDATE Rezyser
            //SET Imie = 'Wayne', Nazwisko = '', Narodowosc = '', Data_Urodzenia = '', Odnosnik = ''
            //WHERE Rezyser.Nazwisko = 'Roberts';

            int returnValue = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("UPDATE Aktor " +
                                                        "SET Imie = @NewName, Nazwisko = @NewSurname, Narodowosc = @NewNationality, " +
                                                        "Data_Urodzenia = @NewDateOfBirth, Odnosnik = @NewSource " +
                                                        "WHERE Aktor.Nazwisko = @MovieSurnameName; ", sqlConnection);
                SqlParameter sqlParameterName = new SqlParameter("@MovieSurnameName", movieActorSurname);

                // TODO: optimalization, use for example array or smth
                SqlParameter sqlParameterNewName = new SqlParameter("@NewName", actor.Name);
                SqlParameter sqlParameterSurname = new SqlParameter("@NewSurname", actor.Surname);
                SqlParameter sqlParameterNationality = new SqlParameter("@NewNationality", actor.Nationality);
                SqlParameter sqlParameterSource = new SqlParameter("@NewSource", actor.Source);
                SqlParameter sqlParameterDateOfBirth = new SqlParameter("@NewDateOfBirth", actor.DateOfBirth);

                sqlCommand.Parameters.Add(sqlParameterName);
                sqlCommand.Parameters.Add(sqlParameterNewName);
                sqlCommand.Parameters.Add(sqlParameterSurname);
                sqlCommand.Parameters.Add(sqlParameterNationality);
                sqlCommand.Parameters.Add(sqlParameterDateOfBirth);
                sqlCommand.Parameters.Add(sqlParameterSource);

                sqlCommand.CommandType = System.Data.CommandType.Text;
                returnValue = sqlCommand.ExecuteNonQuery();
            }
            return returnValue;
        }

        public int deleteMovie(string movieName, string connectionString)
        {
            //delete from Film
            //where Film.Nazwa = 'The Professor';

            int returnValue = 0;

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();

                SqlCommand sqlCommand = new SqlCommand("DELETE from Film " +
                                                        "WHERE Film.Nazwa = @MovieName; ", sqlConnection);
                SqlParameter sqlParameterName = new SqlParameter("@MovieName", movieName);

                sqlCommand.Parameters.Add(sqlParameterName);

                sqlCommand.CommandType = System.Data.CommandType.Text;
                returnValue = sqlCommand.ExecuteNonQuery();
            }

            return returnValue;
        }
    }
}
