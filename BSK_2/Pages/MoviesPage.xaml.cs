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

namespace BSK_2.Pages
{
    /// <summary>
    /// Interaction logic for MoviesPage.xaml
    /// </summary>
    /// 
    public partial class MoviesPage : Page
    {
        public System.Windows.Visibility Visibility { get; set; }

        public MoviesPage()
        {
            InitializeComponent();
        }

        public MoviesPage(string infoLabelString = null)
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

            //
            //jesli wszystko ok to polaczenie z baza danych 

            DataBase dataBaseMovie = new DataBase();
            
            string connectionString = dataBaseMovie.GetConnectionString();

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

            MovieDetails movieDetails = new MovieDetails(movie);
            this.NavigationService.Navigate(movieDetails);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
           
        }
    }
}
