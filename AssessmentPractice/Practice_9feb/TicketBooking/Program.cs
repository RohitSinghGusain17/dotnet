public class Ticket
{
    public static int LastTicketNo=1000;

    public void getTicket()
    {
        LastTicketNo++;
        Console.WriteLine($"Ticket generated :{LastTicketNo}");
    }
}

public class Program
{
    public static void Main()
    {
        Ticket ticket = new Ticket();
        ticket.getTicket();
        ticket.getTicket();
        ticket.getTicket();
        ticket.getTicket();
        ticket.getTicket();
    }
}