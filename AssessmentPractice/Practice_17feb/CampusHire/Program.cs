public class Applicant
{
    public string? ApplicantId{get; set;} //(Example: CH123456)
    public string? ApplicantName{get; set;}
    public string? Location{get; set;} //(Mumbai / Pune / Chennai – select any one)
    public string? JobLocation{get; set;} //(Mumbai / Pune / Chennai / Delhi / Kolkata / Bangalore – select any one)
    public string? CoreCompetency{get; set;} //(.NET / JAVA / ORACLE / Testing)
    public int year{get; set;} //(Degree completion year)
}

public class CampusHireService
{
    //Add Applicants with validation
    public void AddApplicant()
    {
        Applicant a = new Applicant();
        Console.Write("Enter ID: ");
        string id = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(id) || id.Length != 8 || !id.StartsWith("CH"))
        {
            Console.WriteLine("Invalid ID, must be 8 chars and start with CH");
            return;
        }

        Console.Write("Enter Name: ");
        string name = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(name) || name.Length < 4 || name.Length > 15)
        {
            Console.WriteLine("Invalid Name 4 to 15 chars allowed");
            return;
        }

        Console.Write("Enter Location: ");
        string loc = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(loc))
        {
            Console.WriteLine("Location required");
            return;
        }

        Console.Write("Enter Job Location: ");
        string jobLoc = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(jobLoc))
        {
            Console.WriteLine("Job Location required");
            return;
        }

        Console.Write("Enter Core Competency: ");
        string comp = Console.ReadLine()!;
        if (string.IsNullOrWhiteSpace(comp))
        {
            Console.WriteLine("Core Competency required");
            return;
        }

        Console.Write("Enter Degree Completion year: ");
        int year = int.Parse(Console.ReadLine()!);
        if (year > DateTime.Now.Year)
        {
            Console.WriteLine("Passing Year must not be greater than the current year");
            return;
        }

        a.ApplicantId = id;
        a.ApplicantName = name;
        a.Location = loc;
        a.JobLocation = jobLoc;
        a.CoreCompetency = comp;
        a.year = year;

        Program.applicants.Add(a);
        Console.WriteLine("Applicant added successfully");
    }

    //Update applicant details
    public void UpdateApplicantDetails(string id)
    {
        var applicant = Program.applicants.FirstOrDefault(x => x.ApplicantId == id);

        if (applicant != null)
        {
            Console.Write("Enter new Location: ");
            string loc = Console.ReadLine()!;
            applicant.Location = loc;
            Console.WriteLine("Updated successfully");
        }
        else
        {
            Console.WriteLine("Applicant not found");
        }
    }

    //Search for an applicant using Applicant ID
    public void SearchApplicantByID(string id)
    {
        var applicant = Program.applicants.FirstOrDefault(x => x.ApplicantId == id);

        if (applicant != null)
        {
            Console.WriteLine($"{applicant.ApplicantId} {applicant.ApplicantName} {applicant.Location}");
        }
        else
        {
            Console.WriteLine("Applicant not found");
        }
    }

    //Display all applicant details
    public void DisplayApplicants()
    {
        foreach (var a in Program.applicants)
        {
            Console.WriteLine($"{a.ApplicantId}, {a.ApplicantName}, {a.Location}, {a.JobLocation}, {a.CoreCompetency}, {a.year}");
        }
    }

    //Delete applicant records
    public void DeleteApplicant(string id)
    {
        var applicant = Program.applicants.FirstOrDefault(x => x.ApplicantId == id);

        if (applicant != null)
        {
            Program.applicants.Remove(applicant);
            Console.WriteLine("Deleted successfully");
        }
        else
        {
            Console.WriteLine("Applicant not found");
        }
    }
}

public class Program
{
    public static List<Applicant> applicants = new List<Applicant>();
    public static void Main()
    {
        CampusHireService service = new CampusHireService();

        while (true)
        {
            Console.WriteLine("1. Add\n2. Update\n3. Search\n4. Display\n5. Delete\n6. Exit");
            Console.Write("Enter your choice: ");

            int choice = int.Parse(Console.ReadLine()!);

            switch (choice)
            {
                case 1:
                    service.AddApplicant();
                    break;
                
                case 2:
                    Console.Write("Enter ID: ");
                    service.UpdateApplicantDetails(Console.ReadLine()!);
                    break;

                case 3:
                    Console.Write("Enter ID: ");
                    service.SearchApplicantByID(Console.ReadLine()!);
                    break;

                case 4:
                    service.DisplayApplicants();
                    break;

                case 5:
                    Console.Write("Enter ID: ");
                    service.DeleteApplicant(Console.ReadLine()!);
                    break;

                case 6:
                    Console.WriteLine("Thank You");
                    return;
            }
        }
    }
}