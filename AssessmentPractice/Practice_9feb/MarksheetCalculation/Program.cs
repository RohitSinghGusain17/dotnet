public class Marksheet
{
    public void CalculateResult(int[] marks, out int total, out double avg, out string result)
    {
        int totalMarks=0;
        double avgMarks;
        string resultOut="Pass";

        foreach(var i in marks)
        {
            totalMarks+=i;
            if (i < 35)
            {
                resultOut="Fail";
            }
        }
        avgMarks = (double)totalMarks/marks.Length;
        total=totalMarks;
        avg=avgMarks;
        result=resultOut;
    }
}

public class Program
{
    public static void Main()
    {
        Marksheet marksheet = new Marksheet();
        marksheet.CalculateResult([45,65,65,87,54,78],out int total, out double avg, out string result);
        Console.WriteLine($"Total {total}, Average {avg:F2}, Result {result}");
    }
}