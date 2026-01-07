public delegate int DelegateAddFunctionName(int a, int b);

public class Delegate
{
    public void DelegateFn()
    {
        DelegateAddFunctionName delegatefn = new DelegateAddFunctionName(AddMethod);

        int result = delegatefn(1, 2);

        Console.WriteLine("Result = " + result);
    }

    private int AddMethod(int a, int b)
    {
        return a + b;
    }
}