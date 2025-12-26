namespace Day7
{
    /// <summary>
    /// Interface IBirdA with Fly function
    /// </summary>
    interface IBirdA
    {
        void Fly();
    }
    /// <summary>
    /// Interface IBirdB with Sing function
    /// </summary>
    interface IBirdB
    {
        void Sing();
    }

    /// <summary>
    /// Class BirdUser which implements interface IBirdA and IBirdB 
    /// </summary>
    class BirdUser : IBirdA, IBirdB
    {
        void IBirdA.Fly()
        {
            Console.WriteLine("A is flying");
        }

        void IBirdB.Sing()
        {
            Console.WriteLine("B is Singing");
        }
    }
}