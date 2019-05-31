using BSK_2.Pages.Update;
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

namespace BSK_2.Pages
{
    /// <summary>
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Page
    {
        string selectedMovieTitle;

        public Visibility Visible { get; private set; }
        public System.Windows.Visibility Visibility { get; set; }

        public MovieDetails()
        {
            InitializeComponent();
        }

        public MovieDetails(object movie)
        {
            InitializeComponent();

            selectedMovieTitle = ((Movie)movie).Name;
            infoLabel2.Content = selectedMovieTitle;

            DataBase dataBaseMovie = new DataBase();

            dataBaseMovie.SelectMovieDirectors(selectedMovieTitle, dataBaseMovie.GetConnectionString(), listViewDirectors);
            dataBaseMovie.SelectMovieActors(selectedMovieTitle, dataBaseMovie.GetConnectionString(), listViewActors);
        
        }

        private void listViewDirectors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (System.Windows.Controls.ListView)sender;
            var movie = (Director)item.SelectedItem;

            UpdatePageDirector editPage = new UpdatePageDirector(movie);
            this.NavigationService.Navigate(editPage);
        }

        private void listViewActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (System.Windows.Controls.ListView)sender;
            var actor = (Actor)item.SelectedItem;

            UpdatePageActor updatePageActor = new UpdatePageActor(actor);
            this.NavigationService.Navigate(updatePageActor);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBaseMovie = new DataBase();

            deleteButton.IsEnabled = false;
            if (dataBaseMovie.deleteMovie(selectedMovieTitle, dataBaseMovie.GetConnectionString()) == 1)
            {
                infoLabel.Content = "Success! Movie deleted!";
            }
        }
    }
}
