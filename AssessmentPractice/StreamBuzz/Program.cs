using System.Linq;
public class Program
{
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();
    public void RegisterCreator(CreatorStats record)
    {
        EngagementBoard.Add(record);
    }

    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> dict = new Dictionary<string, int>();
        foreach(var i in EngagementBoard)
        {
            var count = i.WeeklyLikes!.Where(x=>x>=likeThreshold);
            if (count.Count() > 0)
            {
                dict[i.CreatorName!]=count.Count();
            }     
        }

        return dict;
    }

    public double CalculateAverageLikes()
    {
        double wages = 0;
        double count = 0;
        foreach(var i in EngagementBoard)
        {
            double likes = i.WeeklyLikes!.Sum(x=>x);
            wages+=likes;
            count+=4;
        }

        return wages/count;
    }

    public static void Main(string[] args)
    {
        bool flag=true;
        while (flag)
        {
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");
            int ch = int.Parse(Console.ReadLine()!);
            Program p = new Program();
            switch (ch)
            {
                case 1:
                    Console.WriteLine("Enter Creator Name:");
                    string name = Console.ReadLine()!;
                    Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                    double[] likes = new double[4];
                    for(int i=0; i <4; i++)
                    {
                        double input = double.Parse(Console.ReadLine()!);
                        likes[i]=input;
                    }
                    p.RegisterCreator(new CreatorStats{CreatorName=name, WeeklyLikes=likes});
                    Console.WriteLine("Creator registered successfully");
                    break;
                
                case 2:
                    Console.WriteLine("Enter like threshold:");
                    int like = int.Parse(Console.ReadLine()!);
                    var ans = p.GetTopPostCounts(EngagementBoard, like);
                    if (ans.Count == 0)
                    {
                        Console.WriteLine("No top-performing posts this week");
                    }
                    else
                    {
                        foreach(var i in ans)
                        {
                            Console.WriteLine(i.Key+"-"+i.Value);
                        }
                    }
                    break;
                
                case 3:
                    Console.WriteLine("Overall average weekly likes: "+p.CalculateAverageLikes());
                    break;

                case 4:
                    Console.WriteLine("Logging off - Keep Creating with StreamBuzz!");
                    flag=false;
                    break;
            }
        }
    }
}