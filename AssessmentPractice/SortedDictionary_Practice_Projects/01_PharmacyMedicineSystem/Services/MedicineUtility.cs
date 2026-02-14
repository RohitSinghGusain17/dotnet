using System.Collections.Generic;
using Domain;
using Exceptions;
using System.Linq;

namespace Services
{
    public class MedicineUtility
    {
        private SortedDictionary<int, List<Medicine>> _data = new SortedDictionary<int, List<Medicine>>();

        public void AddMedicine(Medicine medicine)
        {
            // TODO: Validate entity
            // TODO: Handle duplicate entries
            // TODO: Add entity to SortedDictionary
            if (medicine == null || string.IsNullOrWhiteSpace(medicine.Id))
            {
                throw new MedicineNotFoundException("Invalid medicine");
            }

            foreach (var list in _data.Values)
            {
                foreach (var m in list)
                {
                    if (m.Id == medicine.Id)
                        throw new DuplicateMedicineException("Duplicate medicine Id");
                }
            }

            if (_data.ContainsKey(medicine.ExpiryYear))
            {
                _data[medicine.ExpiryYear].Add(medicine);
            }
            else
            {
                _data[medicine.ExpiryYear]=new List<Medicine>{medicine};
            }
        }

        public void UpdateMedicinePrice(string id, int newPrice)
        {
            // TODO: Update entity logic
            bool found = false;

            foreach (var list in _data.Values)
            {
                foreach (var med in list)
                {
                    if (med.Id == id)
                    {
                        med.Price = newPrice;
                        found = true;
                        break;
                    }
                }
                if (found) break;
            }

            if (!found)
            {
                throw new MedicineNotFoundException("Medicine not found");
            }
            
        }

        public void GetAllMedicines()
        {
            // TODO: Remove entity logic
            foreach(var i in _data)
            {
                foreach(var j in i.Value)
                {
                    Console.WriteLine($"Details : {i.Key} {j.Id} {j.Name} {j.Price}");
                }
            }
        }
    }
}