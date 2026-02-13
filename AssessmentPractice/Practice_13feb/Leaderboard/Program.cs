public class Program
{
    public static void Main()
    {
        //Leaderboard – Top K Scores
        //Sort by score (descending).
        //If tie, sort by name (ascending).
        //Return only top k entries.
        List<(string name, int score)> players = new List<(string name, int score)> {("Raj",80),("Anu",95),("Vikram",95),("Meena",70)};
        List<(string name, int score)> topK = new List<(string name,int score)>();

        int k = 3;

        topK = players.OrderByDescending(x=>x.score).ThenBy(x=>x.name).Take(k).ToList();

        foreach(var i in topK)
        {
            Console.WriteLine(i.name+" "+i.score);
        }
    }
}