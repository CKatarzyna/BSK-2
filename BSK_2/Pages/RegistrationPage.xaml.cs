using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        private string userLogin;
        private string userPassword;
        private string userPasswordConfirm;
        private string userPasswordHash;

        public RegistrationPage()
        {
            InitializeComponent();
            ResetBoxes();
        }

        private void Password_Info_Click(object sender, RoutedEventArgs e)
        {
            //InfoWindow infoWindow = new InfoWindow("Password must have:\n *min. 8 characters\n *min. 1 capital letter [A-Z]\n *min. 1 digital [0-9]\n *min. 1 character e.g. %,&.* \n");
            //infoWindow.Show();
        }

        private void Login_Info_Click(object sender, RoutedEventArgs e)
        {
            //InfoWindow infoWindow = new InfoWindow("Login must have only: \n *Letters [a-z,A-Z] \n *Digital [0-9]\n");
            //infoWindow.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            userLogin = loginBox.Text;
            userPassword = passwordBox.Password;
            userPasswordConfirm = passwordConfirmBox.Password;

            //ify sprawdzajace czy wprowadzone dane do formularza logowania sa sensowne
            if (CheckLogin(userLogin) && CheckPassword(userPassword))
            {
                if (userPasswordConfirm.Equals(userPassword))
                {
                    // TODO: opcjonalnie - sprawdzenie czy taki uzytkownik juz istnieje jesli tak to wymusic zmiane loginu
                    //jesli wszystko ok to polaczenie z baza danych 
                    string connectionString = GetConnectionString();
                    using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                    {
                        sqlConnection.Open();

                        // TODO: generowanie skrotu hasla dostepu uzytkownika
                        //PasswordHash passwordHash = new PasswordHash(userPassword);
                        //userPasswordHash = passwordHash.CreateHash();

                        SqlCommand sqlCommand = new SqlCommand("Insert into Konto (Login,Haslo) values('" + userLogin + "', '" + userPassword + "')", sqlConnection);
                        sqlCommand.CommandType = System.Data.CommandType.Text;
                        sqlCommand.ExecuteNonQuery();

                        // TODO: opcjonalnie - sprawdzic dodatkowo czy w bazie danych powstal nowy wpis

                        //jesli wszystko wyglada ok to przekierowanie do logowania
                        LoginPage loginPage = new LoginPage("Registation succesful! :)");
                        this.NavigationService.Navigate(loginPage);
                        ResetBoxes();
                    }
                }
                else
                {
                    FailureMessage.Content = "Passwords are not the same";
                }
            }
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
                IncorrectPassword();
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
                return false;
            }
            return true;
        }

        static private string GetConnectionString()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BSK_2;Data Source=(local)";
        }

        private void IncorrectLogin()
        {
            loginBox.Text = "";
            FailureMessage.Content = "Login incorrect";
        }

        private void IncorrectPassword()
        {
            passwordBox.Password = "";
            passwordConfirmBox.Password = "";
            FailureMessage.Content = "Password incorrect";
        }

        private void ResetBoxes()
        {
            loginBox.Text = "";
            passwordBox.Password = "";
            passwordConfirmBox.Password = "";
            FailureMessage.Content = "";
        }
    }
}
