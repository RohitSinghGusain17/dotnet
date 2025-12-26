public class Program
{
    public static void Main(string[] args)
    {
        #region BirdUser
        // BirdUser B = new BirdUser();
        // IBirdA birdA = B;
        // IBirdB birdB = B;
        // birdA.Fly();
        // birdB.Sing();
        #endregion

        #region Reference
        // int salary=20000;
        // int bonus=2000;
        // Learning learn = new Learning();
        // learn.update(ref salary, ref bonus);
        // Console.WriteLine(salary+" "+bonus);
        #endregion

        #region Out
        // int sum;
        // int mul;
        // Out o = new Out();
        // o.Calculate(5,2,out sum, out mul);
        // Console.WriteLine(sum+ " "+mul);
        #endregion

        #region Flip key
        // Console.Write("Enter string : ");
        // string? StrInput = Console.ReadLine()!;
        // FlipKey flip = new FlipKey();
        // string result = flip.CleanseAndInvert(StrInput);
        // Console.WriteLine(result);
        #endregion


        #region Jagged array
        // int[][] data = new int[5][];
        // data[0] = new int[] { 1, 2, 3 };
        // data[1] = new int[] { 10, 20 };
        // data[2] = new int[] { 7, 8, 9, 10 };
        // data[3] = new int[] { 1, 7, 8, 9, 10 };
        // data[4] = new int[] { 7, 8, 9, 10 ,11, 12};

        // for (int i = 0; i < data.Length; i++)
        // {
        //     Console.Write("Row " + i + ": ");
        //     foreach (var v in data[i]) Console.Write(v + " ");
        //     Console.WriteLine();
        // }
        #endregion


        #region Collection
        List<string> abc = new List<string>();
        abc.Add("Rohit");
        abc.Add("Hello");
        abc.Add("123");
        abc.Sort();

        foreach(var v in abc)
        {
            Console.WriteLine(v);
        }
        #endregion
    }
}