public interface IFilm
{
    string? Title{get; set;}
    string? Director{get; set;}
    int Year{get; set;}
}
public interface IFilmLibrary
{
    void AddFilm(IFilm film);
    void RemoveFilm(string title);
    List<IFilm> GetFilms();
    List<IFilm> SearchFilms(string query);
    int GetTotalFilmCount();
}

public class Film : IFilm
{
    public string? Title{get; set;}
    public string? Director{get; set;}
    public int Year{get; set;}
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
        foreach(IFilm i in _films)
        {
            if (i.Title == title)
            {
                _films.Remove(i);
                Console.WriteLine(title+" Removed Successfully");
                break;
            }
        }
    }

    public List<IFilm> GetFilms()
    {
        return _films;
    }

    public List<IFilm> SearchFilms(string query)
    {
        List<IFilm> result = new List<IFilm>();
        foreach(IFilm i in _films)
        {
            if(i.Title!.Contains(query) || i.Director!.Contains(query))
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