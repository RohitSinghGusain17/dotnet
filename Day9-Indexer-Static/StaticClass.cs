public static class StaticClass
{
    public static int Rno;
    static StaticClass(){
        Rno=1;
    }

    public static int GetRno()
    {
        Console.WriteLine(Rno);
        return 0;
    }
}