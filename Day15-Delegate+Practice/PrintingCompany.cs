public delegate string PrintMessage(string message);

public class PrintingCompany
{
    public PrintMessage? CustomerChoicePrintMessage{get; set;}

    public void Print(string message)
    {
        string messageToPrint = CustomerChoicePrintMessage!(message);
        Console.WriteLine(messageToPrint);
    }
}