public class Team : IComparable<Team>
{
    public string? Name { get; set; }
    public int Points { get; set; }
    
    public int CompareTo(Team? other)
    {
        var result = other!.Points.CompareTo(this.Points);
        if (result == 0)
        {
            return this.Name!.CompareTo(other!.Name);
        }

        return result;
    }
}

public class Match
{
    public Team Team1;
    public Team Team2;

    public Match(Team a, Team b)
    {
        Team1=a;
        Team2=b;
    }

    public Match Clone()
    {
        return new Match(Team1, Team2);
    }
}

public class Tournament
{
    private SortedList<int, Team> _rankings = new SortedList<int, Team>();
    private LinkedList<Match> _schedule = new LinkedList<Match>();
    private Stack<Match> _undoStack = new Stack<Match>();
    
    // Add match to schedule
    public void ScheduleMatch(Match match)
    {
        _schedule.AddLast(match);
    }

    //Update team ranking
    public void UpdateRanking()
    {
        _rankings.Clear();
        var teams = _schedule.SelectMany(x=> new[] {x.Team1,x.Team2}).Distinct().OrderBy(x=>x).ToList();
        int key=0;
        foreach(var i in teams)
        {
            _rankings.Add(key++, i);
        }
    }
    
    // Record match result and update rankings
    public void RecordMatchResult(Match match, int team1Score, int team2Score)
    {

        _undoStack.Push(match.Clone());

        if (team1Score > team2Score)
        {
            match.Team1.Points+=2;
        }
        else if (team2Score > team1Score)
        {
            match.Team2.Points+=2;
        }
        else
        {
            match.Team1.Points+=1;
        }

        UpdateRanking();
    }
    
    // Undo last match
    public void UndoLastMatch()
    {
        Match last = _undoStack.Pop();
        last.Team1.Points = 0;
        last.Team2.Points = 0;

        UpdateRanking();
    }
    
    // Get ranking position using binary search
    public int GetTeamRanking(Team team)
    {
        var list = _rankings.Values.ToList();

        int left = 0, right = list.Count - 1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (list[mid].Name == team.Name)
                return mid;

            if (list[mid].CompareTo(team) < 0)
                right = mid - 1;
            else
                left = mid + 1;
        }

        return -1;
    }

    public List<Team> GetRankings()
    {
        return _rankings.Values.ToList();
    }
}

public class Program
{
    public static void Main()
    {
        Tournament tournament = new Tournament();
        Team teamA = new Team { Name = "Team Alpha", Points = 0 };
        Team teamB = new Team { Name = "Team Beta", Points = 0 };

        tournament.ScheduleMatch(new Match(teamA, teamB));
        tournament.RecordMatchResult(new Match(teamA, teamB), 3, 1); // Team A wins

        var rankings = tournament.GetRankings();
        Console.WriteLine(rankings[0].Name); // Should output: Team Alpha

        tournament.UndoLastMatch();
        Console.WriteLine(teamA.Points); // Should output: 0 (back to original)
    }
}