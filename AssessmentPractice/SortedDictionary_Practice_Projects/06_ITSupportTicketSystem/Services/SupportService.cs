using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class SupportService
    {
        SortedDictionary<int, Queue<SupportTicket>> _data = new SortedDictionary<int, Queue<SupportTicket>>();

        public void AddTicket(SupportTicket t)
        {
            if (t.SeverityLevel < 1)
            {
                throw new InvalidSeverityException("Invalid severity");
            }

            if (!_data.ContainsKey(t.SeverityLevel))
            {
                _data[t.SeverityLevel] = new Queue<SupportTicket>();
            }

            _data[t.SeverityLevel].Enqueue(t);
        }

        public void EscalateTicket(int ticketId)
        {
            SupportTicket? target = null;
            int oldSeverity = 0;

            foreach (var key in _data.Keys.ToList())
            {
                var queue = _data[key];
                var temp = new Queue<SupportTicket>();

                while (queue.Count > 0)
                {
                    var t = queue.Dequeue();

                    if (t.TicketId == ticketId)
                    {
                        target = t;
                        oldSeverity = key;
                    }
                    else
                    {
                        temp.Enqueue(t);
                    }
                }

                _data[key] = temp;

                if (target != null)
                {
                    break;
                }
            }

            if (target == null)
            {
                throw new TicketNotFoundException("Ticket not found");
            }

            int newSeverity = Math.Max(1, oldSeverity - 1);
            target!.SeverityLevel = newSeverity;

            if (!_data.ContainsKey(newSeverity))
            {
                _data[newSeverity] = new Queue<SupportTicket>();
            }

            _data[newSeverity].Enqueue(target);
        }

        public void DisplayTickets()
        {
            foreach (var p in _data)
            {
                foreach (var t in p.Value)
                {
                    Console.WriteLine($"{t.TicketId} {t.IssueDescription} {t.SeverityLevel}");
                }
            }
        }
    }
}
