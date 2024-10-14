using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieApp.Views;

public partial class ListPage : ContentPage
{
    public ListPage()
    {
        InitializeComponent();
        Title = "List of Movies";
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();

        //sets the properties of A datatemplate. We can use that to display on a page
        var movieTemplate = new DataTemplate(typeof(TextCell));
        movieTemplate.SetBinding(TextCell.TextProperty, "Title");
        movieTemplate.SetBinding(TextCell.DetailProperty, "Rating");
    
        //display data template
        lstMovies.ItemTemplate = movieTemplate;
        lstMovies.ItemsSource = App.MovieList;
    }
}