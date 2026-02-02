public class MovieScreening
{
    public string? MovieTitle;
    public DateTime ShowTime;
    public string? ScreenNumber;
    public int TotalSeats;
    public int BookedSeats;
    public double TicketPrice;
}

public class ThreaterManager
{
    List<MovieScreening> movie = new List<MovieScreening>();
    public void AddScreening(string title, DateTime time, string screen, int seats, double price)
    {
        movie.Add(new MovieScreening{MovieTitle=title, ShowTime=time, ScreenNumber=screen, TotalSeats=seats, TicketPrice=price});
    }

    public bool BookTickets(string movieTitle, DateTime showTime, int tickets)
    {
        var show = movie.FirstOrDefault(x=>x.MovieTitle==movieTitle && x.ShowTime==showTime && x.TotalSeats-x.BookedSeats>=tickets);
        if (show == null)
        {
            return false;
        }
        else
        {
            show.BookedSeats+=tickets;
            return true;
        }
    }
    public Dictionary<string, List<MovieScreening>> GroupScreeningsByMovie()
    {
        Dictionary<string, List<MovieScreening>> groupMovie = new Dictionary<string, List<MovieScreening>>();
        var result = movie.GroupBy(x=>x.MovieTitle).ToList();
        foreach(var i in result)
        {
            groupMovie[i.Key!]=i.ToList();
        }

        return groupMovie;
    }

    public double CalculateTotalRevenue()
    {
        return movie.Sum(x => x.BookedSeats * x.TicketPrice);
    }

    public List<MovieScreening> GetAvailableScreenings(int minSeats)
    {
        return movie.Where(x => (x.TotalSeats - x.BookedSeats) >= minSeats).ToList();
    }
}