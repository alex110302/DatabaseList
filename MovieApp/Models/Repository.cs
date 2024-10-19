using SQLite;

namespace MovieApp.Models;

public class Repository
{

    private readonly SQLiteConnection _database;

    public Repository()
    {
        var dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Movies.db");

        _database = new SQLiteConnection(dbPath);
        _database.CreateTable<Movie>();
    }

    public List<Movie> GetMovies()
    {
        return _database.Query<Movie>("Select * From Movie Where ID > 2");
        //return _database.Table<Movie>().ToList();
    }

    public void SaveMovie(Movie movie)
    {
        _database.Insert(movie);
    }
}