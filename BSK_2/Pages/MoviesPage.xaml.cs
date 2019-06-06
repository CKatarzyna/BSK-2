using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Forms;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Security.Permissions;
using System.Security.Principal;

namespace BSK_2.Pages
{
    /// <summary>
    /// Interaction logic for MoviesPage.xaml
    /// </summary>
    /// 
    public partial class MoviesPage : Page
    {
        public System.Windows.Visibility Visibility { get; set; }
        public string CurrentUserRights { get; set; }
        public string CurrentUserLogin { get; set; }
        public MoviesPage()
        {
            InitializeComponent();
        }

        public MoviesPage(string userLogin, string infoLabelString = null)
        {
            InitializeComponent();

            if (infoLabelString != null)
            {
                infoLabel.Content = infoLabelString;
            }
            else
            {
                infoLabel.Visibility = Visibility.Hidden;
            }

            //jesli wszystko ok to polaczenie z baza danych 

            // TODO: move to database class
            DataBase dataBaseMovie = new DataBase();

            string connectionString = dataBaseMovie.GetConnectionString();
            CurrentUserRights = dataBaseMovie.GetUserPermissionRights(userLogin, connectionString);
            CurrentUserLogin = userLogin;

            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity(userLogin), new string[] { CurrentUserRights });

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * from Film", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;
                DataTable dataTable = new DataTable();
                List<Movie> items = new List<Movie>();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                   items.Add(new Movie() { Name = row["Nazwa"].ToString(), Type = row["Typ"].ToString(), Year = row["Rok_Wydania"].ToString(),
                            Rating = row["Ocena"].ToString(), Source = row["Odnosnik"].ToString() });
                }
                lvUsers.ItemsSource = items;
            }
        }

        private void lvUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (System.Windows.Controls.ListView)sender;
            var movie = (Movie)item.SelectedItem;

            MovieDetails movieDetails = new MovieDetails(movie, CurrentUserRights, CurrentUserLogin);
            this.NavigationService.Navigate(movieDetails);
        }

        public void SetButtonAccordingToRights(System.Windows.Controls.Button btn)
        {
            if (Thread.CurrentPrincipal.IsInRole(Roles.Administrator))
            {
                btn.IsEnabled = true;
            }
            else
            {
                btn.IsEnabled = false;
            }
        }

        private void logOffButton_Click(object sender, RoutedEventArgs e)
        {
            LoginPage loginPage = new LoginPage();
            this.NavigationService.Navigate(loginPage);
        }
    }
}
