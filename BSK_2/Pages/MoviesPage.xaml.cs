using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
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
    /// Interaction logic for MoviesPage.xaml
    /// </summary>
    /// 
    public partial class MoviesPage : Page
    {
        public MoviesPage()
        {
            InitializeComponent();
        }

        public MoviesPage(string infoLabelString)
        {
            InitializeComponent();
            infoLabel.Content = infoLabelString;

            //
            //jesli wszystko ok to polaczenie z baza danych 
            string connectionString = GetConnectionString();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select * from Film", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;

                SqlDataAdapter sqlDataAdapter = new SqlDataAdapter();
                sqlDataAdapter.SelectCommand = sqlCommand;

                DataTable dataTable = new DataTable();
                sqlDataAdapter.Fill(dataTable);
                foreach (DataRow row in dataTable.Rows)
                {
                    {
                        Console.WriteLine("{0}", row["Nazwa"]);
                    }
                }
               // image_3.Source = new BitmapImage(new Uri("https://images.immediate.co.uk/production/volatile/sites/3/2019/03/09B_AEG_DomPayoff_1Sht_REV-7c16828.jpg?quality=90&resize=620,413"));

            }
        }

        static private string GetConnectionString()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=BSK_2;Data Source=(local)";
        }
    }
}
