using MovieApp.Models;

namespace MovieApp;

public partial class App : Application
{
    public static Repository MovieList;
    
    public App()
    {
        InitializeComponent();
        MovieList = new Repository();
        
        MainPage = new AppShell();
    }
}