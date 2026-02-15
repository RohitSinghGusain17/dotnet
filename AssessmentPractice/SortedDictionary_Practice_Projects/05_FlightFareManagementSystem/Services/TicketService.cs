using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class TicketService
    {
        private SortedDictionary<int, List<Ticket>> _data = new SortedDictionary<int, List<Ticket>>();

        public void AddTicket(Ticket ticket)
        {
            if (ticket.Fare < 0)
            {
                throw new InvalidFareException("Fare cannot be negative");
            }

            // duplicate check
            foreach (var list in _data.Values)
            {
                foreach (var t in list)
                {
                    if (t.TicketId == ticket.TicketId)
                    {
                        throw new DuplicateTicketException("Duplicate ticket");
                    }
                }
            }

            if (!_data.ContainsKey(ticket.Fare))
            {
                _data[ticket.Fare] = new List<Ticket>();
            }

            _data[ticket.Fare].Add(ticket);
        }

        public void UpdateFare(int ticketId, int newFare)
        {
            if (newFare < 0)
            {
                throw new InvalidFareException("Invalid fare");
            }

            Ticket? target = null;
            int oldFare = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var t in pair.Value)
                {
                    if (t.TicketId == ticketId)
                    {
                        target = t;
                        oldFare = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new TicketNotFoundException("Ticket not found");
            }

            _data[oldFare].Remove(target!);

            target!.Fare = newFare;

            if (!_data.ContainsKey(newFare))
            {
                _data[newFare] = new List<Ticket>();
            }

            _data[newFare].Add(target);
        }

        public void DisplayTickets()
        {
            foreach (var pair in _data)
            {
                foreach (var t in pair.Value)
                {
                    Console.WriteLine($"{t.TicketId} {t.PassengerName} {t.Fare}");
                }
            }
        }
    }
}