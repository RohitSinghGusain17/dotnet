public class Member
{
    public int MemberId{get; set;}
    public string? Name{get; set;}
    public string? MembershipType{get; set;}
    public DateTime JoinDate{get; set;}
    public DateTime ExpiryDate{get; set;}
}

public class FitnessClass
{
    public string? ClassName{get; set;}
    public string? Instructor{get; set;}
    public DateTime Schedule{get; set;}
    public int MaxParticipants{get; set;}
    public List<int> RegisteredMembers = new List<int>();
}

public class GymManager
{
    private int unique = 1;
    public List<Member> Members = new List<Member>();
    public List<FitnessClass> Classes = new List<FitnessClass>();
    public void AddMember(string name, string membershipType, int months)
    {
        DateTime join = DateTime.Now;
        Members.Add(new Member{MemberId = unique++, Name = name, MembershipType = membershipType, JoinDate = join, ExpiryDate = join.AddMonths(months)
        });
    }

    public void AddClass(string className, string instructor, DateTime schedule, int maxParticipants)
    {
        Classes.Add(new FitnessClass{ClassName = className, Instructor = instructor, Schedule = schedule, MaxParticipants = maxParticipants});
    }

    public bool RegisterForClass(int memberId, string className)
    {
        var member = Members.FirstOrDefault(x => x.MemberId == memberId);
        var fitnessClass = Classes.FirstOrDefault(x => x.ClassName == className);

        if (member == null || fitnessClass == null)
        {
            return false;
        }

        if (fitnessClass.RegisteredMembers.Count >= fitnessClass.MaxParticipants)
        {
            return false;
        }

        if (fitnessClass.RegisteredMembers.Contains(memberId))
        {
            return false;
        }

        fitnessClass.RegisteredMembers.Add(memberId);
        return true;
    }

    public Dictionary<string, List<Member>> GroupMembersByMembershipType()
    {
        Dictionary<string, List<Member>> result = new Dictionary<string, List<Member>>();
        var groups = Members.GroupBy(x => x.MembershipType);
        foreach (var g in groups)
        {
            result[g.Key!] = g.ToList();
        }

        return result;
    }

    public List<FitnessClass> GetUpcomingClasses()
    {
        DateTime now = DateTime.Now;
        DateTime nextWeek = now.AddDays(7);

        return Classes.Where(x => x.Schedule >= now && x.Schedule <= nextWeek).ToList();
    }
}


public class Program
{
    public static void Main()
    {
        GymManager gym = new GymManager();

        gym.AddMember("Rohit", "Premium", 6);
        gym.AddMember("Aman", "Basic", 3);

        gym.AddClass("Yoga", "Priya", DateTime.Now.AddDays(2), 5);
        gym.AddClass("Zumba", "Neha", DateTime.Now.AddDays(10), 10);

        // Register member
        Console.WriteLine(gym.RegisterForClass(1, "Yoga"));

        // Upcoming classes
        Console.WriteLine("\nUpcoming Classes:");
        foreach (var c in gym.GetUpcomingClasses())
        {
            Console.WriteLine($"{c.ClassName} - {c.Schedule}");
        }

        // Group members
        var groups = gym.GroupMembersByMembershipType();
        Console.WriteLine("\nMembers by Membership:");

        foreach (var g in groups)
        {
            Console.WriteLine(g.Key + ":");
            foreach (var m in g.Value)
            {
                Console.WriteLine($"  {m.MemberId} - {m.Name}");
            }
        }
    }
}