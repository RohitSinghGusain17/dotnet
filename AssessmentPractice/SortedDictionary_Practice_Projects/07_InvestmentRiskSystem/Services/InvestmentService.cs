using System.Collections.Generic;
using Domain;
using Exceptions;
using System.Linq;

namespace Services
{
    public class InvestmentService
    {
        private SortedDictionary<int, List<Investment>> _data = new SortedDictionary<int, List<Investment>>();

        public void AddInvestment(Investment inv)
        {
            if (inv.RiskRating < 1 || inv.RiskRating > 5)
            {
                throw new InvalidRiskRatingException("Risk must be between 1 and 5");
            }

            // duplicate check
            foreach (var list in _data.Values)
            {
                foreach (var i in list)
                {
                    if (i.InvestmentId == inv.InvestmentId)
                    {
                        throw new DuplicateInvestmentException("Duplicate investment");
                    }
                }
            }

            if (!_data.ContainsKey(inv.RiskRating))
            {
                _data[inv.RiskRating] = new List<Investment>();
            }

            _data[inv.RiskRating].Add(inv);
        }

        public void UpdateRisk(int id, int newRisk)
        {
            if (newRisk < 1 || newRisk > 5)
            {
                throw new InvalidRiskRatingException("Invalid risk");
            }

            Investment? target = null;
            int oldRisk = 0;
            bool found = false;

            foreach (var pair in _data)
            {
                foreach (var inv in pair.Value)
                {
                    if (inv.InvestmentId == id)
                    {
                        target = inv;
                        oldRisk = pair.Key;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new Exception("Investment not found");
            }

            _data[oldRisk].Remove(target!);

            if (_data[oldRisk].Count == 0)
            {
                _data.Remove(oldRisk);
            }

            target!.RiskRating = newRisk;

            if (!_data.ContainsKey(newRisk))
            {
                _data[newRisk] = new List<Investment>();
            }

            _data[newRisk].Add(target);
        }

        public void DisplayInvestments()
        {
            foreach (var pair in _data)
            {
                foreach (var inv in pair.Value)
                {
                    Console.WriteLine($"{inv.InvestmentId} {inv.AssetName} {inv.RiskRating}");
                }
            }
        }
    }
}
