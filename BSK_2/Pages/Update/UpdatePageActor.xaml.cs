using System;
using System.Collections.Generic;
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

namespace BSK_2.Pages.Update
{
    /// <summary>
    /// Interaction logic for UpdatePageActor.xaml
    /// </summary>
    public partial class UpdatePageActor : Page
    {
        string selectedMiveTitleToEdit;
        string selectedMovieActorSurname = "";

        public UpdatePageActor()
        {
            InitializeComponent();
        }

        public UpdatePageActor(object actor, object movie = null)
        {
            movieObject = movie;
            selectedMiveTitleToEdit = ((Actor)actor).Name;
            selectedMovieActorSurname = ((Actor)actor).Surname;

            this.ActorName = selectedMiveTitleToEdit;
            this.Surname = ((Actor)actor).Surname;
            this.Nationality = ((Actor)actor).Nationality;
            this.DateOfBirth = ((Actor)actor).DateOfBirth;
            this.Source = ((Actor)actor).Source;

            InitializeComponent();

            DataBase dataBaseMovie = new DataBase();
        }

        public string ActorName { get; set; }
        public string Surname { get; set; }
        public string Nationality { get; set; }
        public string DateOfBirth { get; set; }
        public string Source { get; set; }
        public Visibility Visible { get; private set; }
        object movieObject;


        private void buttonUpdate_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBaseMovie = new DataBase();
            Actor updateActor = new Actor();

            updateActor.Name = nameBox.Text;
            updateActor.Surname = surnameBox.Text;
            updateActor.Nationality = nationalityBox.Text;
            updateActor.DateOfBirth = dateOfBirthBox.Text;
            updateActor.Source = sourceBox.Text;

            if (dataBaseMovie.UpdateMovieActor(selectedMovieActorSurname, updateActor, dataBaseMovie.GetConnectionString()) == 1)
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
