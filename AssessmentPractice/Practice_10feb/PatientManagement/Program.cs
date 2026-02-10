using System;
using System.Collections.Generic;
using System.Linq;

public interface IPatient
{
    int PatientId { get; }
    string Name { get; }
    DateTime DateOfBirth { get; }
    BloodType BloodType { get; }
}

public enum BloodType { A, B, AB, O }
public enum Condition { Stable, Critical, Recovering }

// 1. Generic patient queue with priority
public class PriorityQueue<T> where T : IPatient
{
    private SortedDictionary<int, Queue<T>> _queues = new();
    
    // TODO: Enqueue patient with priority (1=highest, 5=lowest)
    public void Enqueue(T patient, int priority)
    {
        // Validate priority range
        if (priority < 1 || priority > 5)
        {
            Console.WriteLine("Priority not in range 1-5");
        }

        // Create queue if doesn't exist for priority
        if (!_queues.ContainsKey(priority))
        {
            _queues[priority] = new Queue<T>();
        }

        _queues[priority].Enqueue(patient);
    }
    
    // TODO: Dequeue highest priority patient
    public T Dequeue()
    {
        // Return patient from highest non-empty priority
        foreach (var pair in _queues.OrderBy(x => x.Key))
        {
            if (pair.Value.Count > 0)
            {
                return pair.Value.Dequeue();
            }
        }

        throw new InvalidOperationException("Queue empty");
    }
    
    // TODO: Peek without removing
    public T Peek()
    {
        // Look at next patient
        foreach (var pair in _queues.OrderBy(x => x.Key))
        {
            if (pair.Value.Count > 0)
            {
                return pair.Value.Peek();
            }
        }

        throw new InvalidOperationException("Queue empty");
    }
    
    // TODO: Get count by priority
    public int GetCountByPriority(int priority)
    {
        // Return count for specific priority
        if (!_queues.ContainsKey(priority))
        {
            return 0;
        }

        return _queues[priority].Count;
    }
}

// 2. Generic medical record
public class MedicalRecord<T> where T : IPatient
{
    private T _patient;
    private List<string> _diagnoses = new();
    private Dictionary<DateTime, string> _treatments = new();

    public MedicalRecord(T patient)
    {
        _patient = patient;
    }
    
    // TODO: Add diagnosis with date
    public void AddDiagnosis(string diagnosis, DateTime date)
    {
        // Add to diagnoses list
        _diagnoses.Add($"{date.ToShortDateString()}: {diagnosis}");
    }
    
    // TODO: Add treatment
    public void AddTreatment(string treatment, DateTime date)
    {
        // Add to treatments dictionary
        _treatments[date] = treatment;
    }
    
    // TODO: Get treatment history
    public IEnumerable<KeyValuePair<DateTime, string>> GetTreatmentHistory()
    {
        // Return sorted by date
        return _treatments.OrderBy(x => x.Key);
    }
}

// 3. Specialized patient types
public class PediatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public string? GuardianName { get; set; }
    public double Weight { get; set; }
}

public class GeriatricPatient : IPatient
{
    public int PatientId { get; set; }
    public string Name { get; set; }
    public DateTime DateOfBirth { get; set; }
    public BloodType BloodType { get; set; }
    public List<string> ChronicConditions { get; } = new();
    public int MobilityScore { get; set; }
}

// 4. Generic medication system
public class MedicationSystem<T> where T : IPatient
{
    private Dictionary<T, List<(string medication, DateTime time)>> _medications = new();
    
    // TODO: Prescribe medication with dosage validation
    public void PrescribeMedication(T patient, string medication, Func<T, bool> dosageValidator)
    {
        // Check if dosage is valid for patient type
        if (!dosageValidator(patient))
        {
            throw new InvalidOperationException("Invalid dosage");
        }

        if (!_medications.ContainsKey(patient))
        {
            _medications[patient] = new List<(string, DateTime)>();
        }

        _medications[patient].Add((medication, DateTime.Now));
    }
    
    // TODO: Check for drug interactions
    public bool CheckInteractions(T patient, string newMedication)
    {
        // Return true if interaction with existing medications
        if (!_medications.ContainsKey(patient))
        {
            return false;
        }

        return _medications[patient].Any(m => m.medication == newMedication);
    }
}

// 5. TEST SCENARIO: Simulate hospital workflow
public class Program
{
    public static void Main()
    {
        // a) Create 2 PediatricPatient and 2 GeriatricPatient
        var p1 = new PediatricPatient { PatientId = 1, Name = "Child A", DateOfBirth = new DateTime(2018,1,1), BloodType = BloodType.A, GuardianName="Parent A", Weight=18 };
        var p2 = new PediatricPatient { PatientId = 2, Name = "Child B", DateOfBirth = new DateTime(2017,5,1), BloodType = BloodType.O, GuardianName="Parent B", Weight=22 };

        var g1 = new GeriatricPatient { PatientId = 3, Name = "Senior A", DateOfBirth = new DateTime(1945,3,1), BloodType = BloodType.B, MobilityScore=6 };
        var g2 = new GeriatricPatient { PatientId = 4, Name = "Senior B", DateOfBirth = new DateTime(1940,7,1), BloodType = BloodType.AB, MobilityScore=4 };

        // b) Add them to priority queue
        var queue = new PriorityQueue<IPatient>();
        queue.Enqueue(p1, 2);
        queue.Enqueue(g1, 1);
        queue.Enqueue(p2, 3);
        queue.Enqueue(g2, 2);

        // c) Create medical records
        var record1 = new MedicalRecord<PediatricPatient>(p1);
        record1.AddDiagnosis("Flu", DateTime.Today);
        record1.AddTreatment("Rest", DateTime.Today);

        // d) Prescribe medications
        var medSystem = new MedicationSystem<IPatient>();
        medSystem.PrescribeMedication(p1, "Syrup", pat =>
        {
            if (pat is PediatricPatient child)
            {
                return child.Weight > 10;
            }
            return true;
        });

        // e) Demonstrate
        Console.WriteLine("Next patient: " + queue.Dequeue().Name);

        Console.WriteLine("Treatment history:");
        foreach (var t in record1.GetTreatmentHistory())
        {
            Console.WriteLine($"{t.Key.ToShortDateString()} - {t.Value}");
        }

        Console.WriteLine("Interaction check: " + medSystem.CheckInteractions(p1, "Syrup"));
    }
}