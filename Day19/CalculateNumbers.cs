public class CalculateNumbers
{
    public static List<int> NumberList=new List<int>();
    public double GPA;
    public void AddNumbers(int Numbers)
    {
        NumberList.Add(Numbers);
    }

    public double GetGPAScored()
    {
        if (NumberList.Count == 0)
        {
            Console.WriteLine("No Numbers Available");
            return -1;
        }

        foreach(var i in NumberList)
        {
            GPA+=i*3;
        }
        double count =NumberList.Count*3;
        return GPA/count;
    }

    public char GetGradeScored(double gpa)
    {
        if (gpa == 10)
        {
            return 'S';
        }
        else if(gpa>=9 && gpa < 10)
        {
            return 'A';
        }
        else if(gpa>=8 && gpa < 9)
        {
            return 'B';
        }
        else if(gpa>=7 && gpa < 8)
        {
            return 'C';
        }
        else if(gpa>=6 && gpa < 7)
        {
            return 'D';
        }
        else if(gpa>=5 && gpa < 6)
        {
            return 'E';
        }
        else
        {
            Console.WriteLine("Invalid GPA");
        }
        return ' ';
    }
}