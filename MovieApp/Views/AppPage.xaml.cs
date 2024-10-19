using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MovieApp.Models;

namespace MovieApp.Views;

public partial class AppPage : ContentPage
{
    public AppPage()
    {
        InitializeComponent();
    }

    private void btnAddMovie_OnClicked(object sender, EventArgs e)
    {
        bool showAdded;
        
        if (txtTitle.Text == string.Empty || txtTitle.Text == null && 
            txtRating.Text == string.Empty || txtRating.Text == null) DisplayAlert("No Valid Entries", "Pleas enter valid data", "Ok");
        else if (txtTitle.Text == string.Empty) DisplayAlert("Not A Valid Movie Title", "Pleas add a movie title", "Ok");
        else if (txtRating.Text == string.Empty)  DisplayAlert("Not A Valid Movie Rating", "Pleas add a movie Rating", "Ok");
        else if (txtTitle.Text != string.Empty && txtRating.Text != string.Empty)
        {
            int showAddedTime = 0;
            
            showAdded = true;
            
            Movie movie = new Movie();
            movie.Title = txtTitle.Text;
            movie.Rating = txtRating.Text;
            App.MovieList.SaveMovie(movie);
            
            Application.Current.Dispatcher.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                switch (showAddedTime)
                {
                    case < 4: 
                        showAddedTime++;
                        txtDisplayAdded.Text = "!!!Added Movie!!!"; 
                        txtTitle.Text = string.Empty;
                        txtRating.Text = string.Empty;
                    return showAdded;
                    case 4:
                        showAddedTime = 0;
                        showAdded = false;
                        txtDisplayAdded.Text = string.Empty;
                    break;
                }

                return showAdded;
            });
        }
    }
}