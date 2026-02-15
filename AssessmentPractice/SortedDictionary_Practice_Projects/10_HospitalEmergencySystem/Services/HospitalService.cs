using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class HospitalService
    {
        private SortedDictionary<int, Queue<Patient>> _data = new SortedDictionary<int, Queue<Patient>>();

        public void AddPatient(Patient p)
        {
            if (p.SeverityLevel < 1 || p.SeverityLevel>5)
            {
                throw new InvalidSeverityLevelException("Severity must be >= 1 and <=5");
            }

            if (!_data.ContainsKey(p.SeverityLevel))
            {
                _data[p.SeverityLevel] = new Queue<Patient>();
            }

            _data[p.SeverityLevel].Enqueue(p);
        }

        public void UpdateSeverity(int patientId, int newSeverity)
        {
            if (newSeverity < 1 || newSeverity>5)
            {
                throw new InvalidSeverityLevelException("Invalid severity");
            }

            Patient? target = null;
            int oldSeverity = 0;

            foreach (var key in _data.Keys.ToList())
            {
                var queue = _data[key];
                var temp = new Queue<Patient>();

                while (queue.Count > 0)
                {
                    var p = queue.Dequeue();

                    if (p.PatientId == patientId)
                    {
                        target = p;
                        oldSeverity = key;
                    }
                    else
                    {
                        temp.Enqueue(p);
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
                throw new PatientNotFoundException("Patient not found");
            }

            target!.SeverityLevel = newSeverity;

            if (!_data.ContainsKey(newSeverity))
            {
                _data[newSeverity] = new Queue<Patient>();
            }

            _data[newSeverity].Enqueue(target);
        }

        public void DisplayPatients()
        {
            foreach (var pair in _data)
            {
                foreach (var p in pair.Value)
                {
                    Console.WriteLine($"PatientID:{p.PatientId}, Name:{p.Name}, Severity:{p.SeverityLevel}");
                }
            }
        }
    }
}
