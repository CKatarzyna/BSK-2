using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BSK_2.Pages
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        private string userLogin;
        // TODO: wykorzystac przy generacji hashu przez funkcje skrotu
        private string userPassword;

        public LoginPage()
        {
            InitializeComponent();
        }

        public LoginPage(string infoLabelString)
        {
            InitializeComponent();
            infoLabel.Content = infoLabelString;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userLogin = loginBox.Text;
            userPassword = passwordBox.Password;

            //ify sprawdzajace czy wprowadzone dane do formularza logowania sa sensowne
            if (CheckLogin(userLogin) && CheckPassword(userPassword))
            {
                //jesli wszystko ok to polaczenie z baza danych 
                string connectionString = GetConnectionString();
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCommand = new SqlCommand("Select * from Konto where Login='" + userLogin + "' and Haslo='" + userPassword + "'", sqlConnection);
                    sqlCommand.CommandType = System.Data.CommandType.Text;

                    SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                    sqlDataAdapter.SelectCommand = sqlCommand;

                    DataSet dataSet = new DataSet();
                    sqlDataAdapter.Fill(dataSet);
                    if (dataSet.Tables[0].Rows.Count > 0)
                    {
                        //odnaleziono w bazie i pomyslnie zalogowano
                        MoviesPage actionPage = new MoviesPage("Zalogowano poprawnie");
                        this.NavigationService.Navigate(actionPage);
                        ResetBoxes();
                    }
                    else
                    {
                        //nie ma takich danych w bazie
                        ErrorPage errorPage = new ErrorPage("Wprowadzono bledne dane do logowania");
                        this.NavigationService.Navigate(errorPage);
                        ResetBoxes();
                    }
                }
            }
        }

        static private string GetConnectionString()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BSK_2;Data Source=(local)";
        }

        private bool CheckPassword(string password)
        {
            //haslo: 
            //      minimum 8 znakow
            //      minimum 1 duza litera
            //      minimum 1 cyfra
            //      minimum 1 znak specjalny
            //      bez spacji
            //      dozwolone wszystko
            Regex numberCheck = new Regex(@"[0-9]+");
            Regex upperLetterCheck = new Regex(@"[A-Z]+");
            Regex lowerLetterCheck = new Regex(@"[a-z]+");
            Regex lenghtCheck = new Regex(@".{8,}");
            if (!(numberCheck.IsMatch(password) && upperLetterCheck.IsMatch(password) && lowerLetterCheck.IsMatch(password)
                && lenghtCheck.IsMatch(password) && !password.All(char.IsWhiteSpace)))
            {
                FailureMessage.Content = "Password incorrect";
                return false;
            }
            return true;
        }

        private bool CheckLogin(string login)
        {
            //login: 
            //      znaki a-A 
            //      cyfry 0-9
            //      bez spacji
            if (!login.All(char.IsLetterOrDigit))
            {
                FailureMessage.Content = "Login incorrect";
                return false;
            }
            return true;
        }

        private void ResetBoxes()
        {
            loginBox.Text = "";
            passwordBox.Password = "";
            FailureMessage.Content = "";
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            RegistrationPage registrationPage = new RegistrationPage();
            this.NavigationService.Navigate(registrationPage);
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            MoviesPage actionPage = new MoviesPage("Pominieto logowanie");
            //Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Fred"), new string[] { });
            this.NavigationService.Navigate(actionPage);
        }
    }
}
