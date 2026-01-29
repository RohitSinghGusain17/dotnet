namespace MyLibrary;

public class Calculator
{
    public int Add(int a, int b) => a + b;
    public double Divide(double a, double b)
    {
        if (b == 0)
        {
            throw new DivideByZeroException();
        }
        
        if (b < 0)
        {
            throw new ArgumentException("Divisor cannot be negative");
        }

        return Math.Round((double)a / b, 2);
    }

    public string GetGreeting(string name)
        {
            if (name == null)
                throw new ArgumentNullException(nameof(name));

            return "Hello " + name;
        }
}
