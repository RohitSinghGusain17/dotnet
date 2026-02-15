using System;
using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class LibraryService
    {
        private SortedDictionary<int, List<Member>> _data = new SortedDictionary<int, List<Member>>();

        public void AddMember(Member member)
        {
            if (member.FineAmount < 0)
            {
                throw new InvalidFineException("Fine cannot be negative");
            }

            if (!_data.ContainsKey(member.FineAmount))
            {
                _data[member.FineAmount] = new List<Member>();
            }

            _data[member.FineAmount].Add(member);
        }

        public void PayFine(int memberId, int amount)
        {
            Member? target = null;
            int oldFine = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var m in pair.Value)
                {
                    if (m.MemberId == memberId)
                    {
                        target = m;
                        oldFine = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new MemberNotFoundException("Member not found");
            }

            if (amount < 0 || amount > target!.FineAmount)
            {
                throw new InvalidFineException("Invalid payment amount");
            }

            _data[oldFine].Remove(target);

            target.FineAmount -= amount;
            int newFine = target.FineAmount;

            if (!_data.ContainsKey(newFine))
            {
                _data[newFine] = new List<Member>();
            }

            _data[newFine].Add(target);
        }

        public void DisplayMembers()
        {
            foreach (var pair in _data.Reverse())
            {
                foreach (var m in pair.Value)
                {
                    Console.WriteLine($"{m.MemberId} {m.Name} {m.FineAmount}");
                }
            }
        }
    }
}