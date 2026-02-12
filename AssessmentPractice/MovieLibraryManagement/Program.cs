public interface IFilm
{
    string? Title{get; set;}
}

public class Film : IFilm
{
    public string? Title{get; set;}
    public string? Director{get; set;}
    public int Year{get; set;}

    public Film(string title, string director, int year)
    {
        Title = title;
        Director = director;
        Year = year;
    }
}

public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class FilmLibrary : IFilmLibrary
{
    private List<IFilm> _films = new List<IFilm>();

    public void AddFilm(IFilm film)
    {
        _films.Add(film);
    }

    public void RemoveFilm(string title)
    {
        var ele = _films.First(x=>x.Title==title);
        _films.Remove(ele);
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();
        foreach(var i in _films)
        {
            if (i.Title!.Contains(query) || ((Film)i).Director!.Contains(query))
            {
                result.Add(i);
            }
        }

        return result;
    }

    public int GetTotalFilmCount()
    {
        return _films.Count;
    }
}

public class Program
{
    public static void Main()
    {
        IFilmLibrary library = new FilmLibrary();

        // ---------------- Add Films ----------------
        Console.WriteLine("TEST CASE 1: Adding films");

        Film f1 = new Film("Inception", "Christopher Nolan", 2010);
        Film f2 = new Film("Interstellar", "Christopher Nolan", 2014);
        Film f3 = new Film("Titanic", "James Cameron", 1997);

        library.AddFilm(f1);
        library.AddFilm(f2);
        library.AddFilm(f3);

        Console.WriteLine("Films added successfully\n");

        // ---------------- Display All Films ----------------
        Console.WriteLine("TEST CASE 2: Displaying all films");

        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine($"{film.Title} | {film.Director} | {film.Year}");
        }
        Console.WriteLine();

        // ---------------- Search by Director ----------------
        Console.WriteLine("TEST CASE 3: Search films by director 'Nolan'");

        List<IFilm> searchResult = library.SearchFilms("Nolan");
        foreach (Film film in searchResult)
        {
            Console.WriteLine($"{film.Title} | {film.Director}");
        }
        Console.WriteLine();

        // ---------------- Remove a Film ----------------
        Console.WriteLine("TEST CASE 4: Removing film 'Titanic'");
        library.RemoveFilm("Titanic");

        Console.WriteLine("Remaining films:");
        foreach (Film film in library.GetFilms())
        {
            Console.WriteLine(film.Title);
        }
        Console.WriteLine();

        // ---------------- Get Total Film Count ----------------
        Console.WriteLine("TEST CASE 5: Total film count");
        Console.WriteLine("Total Films: " + library.GetTotalFilmCount());
    }
}