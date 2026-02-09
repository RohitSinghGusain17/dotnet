using System.Text;

public class Program
{
    public static void Main()
    {
        string log = "";
        Console.WriteLine("Time before using '+': "+DateTime.Now.Millisecond);
        for(int i = 0; i < 10000; i++)
        {
            log+="added ";
        }
        Console.WriteLine("Time After using '+' : "+DateTime.Now.Millisecond);

        Console.WriteLine("Time before string builder : "+DateTime.Now.Millisecond);
        StringBuilder stringBuilder = new StringBuilder();
        for(int i = 0; i < 10000; i++)
        {
            stringBuilder.Append("added ");
        }
        Console.WriteLine("Time After using string builder : "+DateTime.Now.Millisecond);
    }
}