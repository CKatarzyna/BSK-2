using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Security.Principal;
using System.Text;
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
    /// Interaction logic for EditPageDirector.xaml
    /// </summary>
    public partial class UpdatePageDirector : Page
    {
        object movieObject;
        string selectedMiveTitleToEdit = "";

        public UpdatePageDirector()
        {
            InitializeComponent();
        }

        public UpdatePageDirector(object director, object movie = null)
        {

            //static class Roles
            //{
            //    public const string Administrator = "ADMIN";
            //}
            //static class Program
            //{
            //    static void Main()
            //    {
            //        Thread.CurrentPrincipal = new GenericPrincipal(
            //            new GenericIdentity("Fred"), new string[] { Roles.Administrator });
            //        DeleteDatabase(); // fine
            //        Thread.CurrentPrincipal = new GenericPrincipal(
            //            new GenericIdentity("Barney"), new string[] { });
            //        DeleteDatabase(); // boom
            //    }

            //    [PrincipalPermission(SecurityAction.Demand, Role = Roles.Administrator)]
            //    public static void DeleteDatabase()
            //    {
            //        Console.WriteLine(
            //            Thread.CurrentPrincipal.Identity.Name + " has deleted the database...");
            //    }
            //}

           
            
            movieObject = movie;
            selectedMiveTitleToEdit = ((Director)director).Name;

            this.DirectorName = selectedMiveTitleToEdit;
            this.Surname = ((Director)director).Surname;
            this.Nationality = ((Director)director).Nationality;
            this.DateOfBirth = ((Director)director).DateOfBirth;
            this.Source = ((Director)director).Source;

            InitializeComponent();
        }

        public string DirectorName { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string Source { get; set; }
        public Visibility Visible { get; private set; }

        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBaseMovie = new DataBase();
            Director updateDirector = new Director();

            updateDirector.Name = nameBox.Text;
            updateDirector.Surname = surnameBox.Text;
            updateDirector.Nationality = nationalityBox.Text;
            updateDirector.DateOfBirth = dateOfBirthBox.Text;
            updateDirector.Source = sourceBox.Text;

            if (dataBaseMovie.UpdateMovieDirector(selectedMiveTitleToEdit, updateDirector, dataBaseMovie.GetConnectionString()) == 1)
            {
                labelInfo.Visibility = Visible;
                labelInfo.Content = "Success! (1 row(s) affected)";
            }
        }

        private void buttonReturn_Click(object sender, RoutedEventArgs e)
        {
            var movie = (Movie)movieObject;
            MovieDetails movieDetails = new MovieDetails(movie);
            this.NavigationService.Navigate(movieDetails);
        }
    }
}
