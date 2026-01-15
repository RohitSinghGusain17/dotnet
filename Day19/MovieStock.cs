public class Movie
{
    public string? Title{get; set;}
    public string? Artist{get; set;}
    public string? Genre{get; set;}
    public int Ratings{get; set;}
}

public class MovieStock
{
    public static List<Movie> MovieList = new List<Movie>();

    public void AddMovie(string MovieDetails)
    {
        var ans = MovieDetails.Split(',');
        MovieList.Add(new Movie{Title = ans[0],Artist = ans[1], Genre = ans[2], Ratings = int.Parse(ans[3])});
    }

    public List<Movie> ViewMoviesByGenre(string genre)
    {
        List<Movie> ans = new List<Movie>();

        foreach(var movie in MovieList)
        {
            if (movie.Genre == genre)
            {
                ans.Add(movie);
            }
        }

        return ans;
    }

    public List<Movie> ViewMoviesByRatings()
    {
        var Sorted = MovieList.OrderBy(x=> x.Ratings);
        return Sorted.ToList();
    }
}