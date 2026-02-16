public class Patient
{
    public int Id{get; set;}
    public string? Name{get; set;}
    public int Age{get; set;}
    public string? Condition{get; set;}
}

public class HospitalManager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        if (_patients.ContainsKey(id))
        {
            Console.WriteLine("ID Already Exist");
        }
        else
        {
            _patients[id]=new Patient{Id=id, Name=name, Age=age,Condition=condition};
        }
    }
    
    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        _appointmentQueue.Enqueue(_patients[patientId]);
    }
    
    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        var result = _appointmentQueue.Dequeue();
        return result;
    }
    
    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        var result = _patients.Where(x=>x.Value.Condition==condition).Select(x=>x.Value).ToList();
        return result;
    }

}

public class Program
{
    public static void Main()
    {
        HospitalManager manager = new HospitalManager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name); // Should output: John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count); // Should output: 1
    }
}