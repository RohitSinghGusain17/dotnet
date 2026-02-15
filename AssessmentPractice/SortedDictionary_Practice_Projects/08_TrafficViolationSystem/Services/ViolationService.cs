using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ViolationService
    {
        private SortedDictionary<int, List<Violation>> _data = new SortedDictionary<int, List<Violation>>();

        public void AddViolation(Violation v)
        {
            if (v.FineAmount < 0)
            {
                throw new InvalidFineAmountException("Fine cannot be negative");
            }

            // duplicate check
            foreach (var list in _data.Values)
            {
                foreach (var x in list)
                {
                    if (x.VehicleNumber == v.VehicleNumber)
                    {
                        throw new DuplicateViolationException("Duplicate violation");
                    }
                }
            }

            if (!_data.ContainsKey(v.FineAmount))
            {
                _data[v.FineAmount] = new List<Violation>();
            }

            _data[v.FineAmount].Add(v);
        }

        public void PayFine(string vehicleNumber, int amount)
        {
            if (amount <= 0)
            {
                throw new InvalidFineAmountException("Invalid payment");
            }

            Violation? target = null;
            int oldFine = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var v in pair.Value)
                {
                    if (v.VehicleNumber == vehicleNumber)
                    {
                        target = v;
                        oldFine = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new Exception("Violation not found");
            }

            if (amount > target!.FineAmount)
            {
                throw new InvalidFineAmountException("Payment exceeds fine");
            }

            _data[oldFine].Remove(target!);

            if (_data[oldFine].Count == 0)
            {
                _data.Remove(oldFine);
            }

            target!.FineAmount -= amount;
            int newFine = target.FineAmount;

            if (!_data.ContainsKey(newFine))
            {
                _data[newFine] = new List<Violation>();
            }

            _data[newFine].Add(target);
        }

        public void DisplayViolations()
        {
            foreach (var pair in _data.Reverse())
            {
                foreach (var v in pair.Value)
                {
                    Console.WriteLine($"$Vehicle no. : {v.VehicleNumber}, owner :  {v.OwnerName}, Fine :  {v.FineAmount}");
                }
            }
        }
    }
}