using System;                                   // TODO: needed for Console

public class Program                              // Boilerplate: Program class
{
    public static void Main()                      // Entry point
    {
        int a = 10;                                // Example value
        int b = 20;                                // Example value

        Swap<int>(ref a, ref b);                   // Calling generic swap

        Console.WriteLine($"a={a}, b={b}");         // Expected: a=20, b=10

        string x = "Gopi";                          // Example string
        string y = "Suresh";                        // Example string

        Swap(ref x, ref y);                         // Generic type inference works too
        Console.WriteLine($"x={x}, y={y}");         // Expected: x=Suresh, y=Gopi
    }

    // ✅ TODO: Students must implement only this function
    public static void Swap<T>(ref T left, ref T right)
    {
        T temp = left;
        left=right;
        right=temp;
    }
}