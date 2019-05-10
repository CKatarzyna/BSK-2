using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
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
using BSK_2;
using Microsoft.Win32;

namespace BSK_2.Pages
{
    /// <summary>
    /// Interaction logic for AddToBase.xaml
    /// </summary>
    public partial class AddToBase : Page
    {
        byte[] photo;
        private OpenFileDialog openFile;
        private User user;
        private string name;
        private string category;
        private string description;
        private bool protection;
        private void Click_Add(object sender, RoutedEventArgs e)
        {
            if (privateChecker.IsChecked == true)
            {
                protection = true;
            }

            name = nameBox.Text;
            category = categorieBox.Text;
            description = descriptionBox.Text;
            string connectionString = GetConnectionString();
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                sqlConnection.Open();
                SqlCommand sqlCommand = new SqlCommand("Insert into Movies (Name,Categorie,Description,Photo) values('" + name + "', '" + category + "', '" + description + "', '"+ protection + "')", sqlConnection);
                sqlCommand.CommandType = System.Data.CommandType.Text;
                sqlCommand.ExecuteNonQuery();
                ResetBoxes();
            }
        }
     
        static private string GetConnectionString()
        {
            return "Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=User_BKS_2;Data Source=(local)";
        }
        private void Click_Photo(object sender, RoutedEventArgs e)
        {
            photo = null;
            var photoPath = string.Empty;

            openFile = new OpenFileDialog();
            openFile.Filter =
                "Image files (*.png;*.jpeg)|*.png;*.jpeg";

            if (openFile.ShowDialog() == true)
            {
                photoPath = openFile.FileName;

                var fileStream = openFile.OpenFile();
                photo = File.ReadAllBytes(System.IO.Path.Combine(
                        Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments),
                        openFile.FileName));
            }
            image.Source = new BitmapImage(new Uri(photoPath));
            photoName.Content = openFile.SafeFileName;
        }
        public AddToBase()
        {
            protection = false;
            InitializeComponent();
            ResetBoxes();
        }
   
        private void ResetBoxes(){
            image.Source =null;
            privateChecker.IsChecked = false;
            nameBox.Text="";
            categorieBox.Text="";
            descriptionBox.Text="";
            photoName.Content = "";
        }
    }
}
