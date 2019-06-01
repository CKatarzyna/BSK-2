using BSK_2.Pages.Update;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for MovieDetails.xaml
    /// </summary>
    public partial class MovieDetails : Page
    {
        string selectedMovieTitle;
        object movieObject;
        public Visibility Visible { get; private set; }
        public System.Windows.Visibility Visibility { get; set; }

        public MovieDetails()
        {
            InitializeComponent();
        }

        public MovieDetails(object movie)
        {
            InitializeComponent();
            Thread.CurrentPrincipal = new GenericPrincipal(new GenericIdentity("Fred"), new string[] { Roles.Administrator });

            movieObject = movie;
            selectedMovieTitle = ((Movie)movie).Name;
            infoLabel2.Content = selectedMovieTitle;

            DataBase dataBaseMovie = new DataBase();

            dataBaseMovie.SelectMovieDirectors(selectedMovieTitle, dataBaseMovie.GetConnectionString(), listViewDirectors);
            dataBaseMovie.SelectMovieActors(selectedMovieTitle, dataBaseMovie.GetConnectionString(), listViewActors);

            SetButtonAccordingToRights(deleteButton);
            SetListViewAccordingToRights(listViewActors);
            SetListViewAccordingToRights(listViewDirectors);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Administrator)]
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Moderator)]
        private void listViewDirectors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (System.Windows.Controls.ListView)sender;
            var director = (Director)item.SelectedItem;

            UpdatePageDirector editPage = new UpdatePageDirector(director, movieObject);
            this.NavigationService.Navigate(editPage);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Administrator)]
        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Moderator)]
        private void listViewActors_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var item = (System.Windows.Controls.ListView)sender;
            var actor = (Actor)item.SelectedItem;

            UpdatePageActor updatePageActor = new UpdatePageActor(actor, movieObject);
            this.NavigationService.Navigate(updatePageActor);
        }

        [PrincipalPermission(SecurityAction.Demand, Role = Roles.Administrator)]
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataBase dataBaseMovie = new DataBase();

            deleteButton.IsEnabled = false;
            if (dataBaseMovie.deleteMovie(selectedMovieTitle, dataBaseMovie.GetConnectionString()) == 1)
            {
                infoLabel.Content = "Success! Movie deleted!";
            }
        }

        private void returnButton_Click(object sender, RoutedEventArgs e)
        {
            MoviesPage actionPage = new MoviesPage(null);
            this.NavigationService.Navigate(actionPage);
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

        public void SetListViewAccordingToRights(System.Windows.Controls.ListView list)
        {
            if (Roles.CheckPermissionRights())
            {
                list.IsEnabled = true;
            }
            else
            {
                list.IsEnabled = false;
            }
        }
    }
}
