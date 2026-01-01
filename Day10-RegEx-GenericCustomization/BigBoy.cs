using System.Collections;
public class BigBoy : IDisposable
{
    public ArrayList? Names { get; set; }

    public void Dispose()
    {
        Names=null;
        Console.WriteLine("Dispose method called, resource released.");
    }

    BigBoy()
    {
        Names = null;
    }
}