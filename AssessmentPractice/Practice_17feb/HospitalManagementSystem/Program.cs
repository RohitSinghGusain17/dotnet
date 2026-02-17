public class Person
{
    public int ID{get; set;}
    public string? Name{get; set;}
}

public class Doctor : Person
{
    public double Earning{get; set;}
}

public class Patient : Person
{
    
}

public class Appointment
{
    public DateTime dateTime;
    public int DoctorID{get; set;}
    public int PatientID{get; set;}
    public string? Disease{get; set;}
    public double Fees{get; set;}
}

public class MedicalRecord
{
    
}

public class Program
{
    public static List<Doctor> doctors = new List<Doctor>();
    public static List<Patient> patients = new List<Patient>();
    public static List<Appointment> appointments = new List<Appointment>();
    public static Dictionary<int, MedicalRecord> dict = new Dictionary<int, MedicalRecord>();
    public static void Main()
    {
        doctors.Add(new Doctor{ID=101,Name="Rohit",Earning=300000});
        doctors.Add(new Doctor{ID=102,Name="Rohit1",Earning=300000});
        doctors.Add(new Doctor{ID=103,Name="Rohit2",Earning=500000});
        doctors.Add(new Doctor{ID=104,Name="Rohit3",Earning=300000});

        patients.Add(new Patient{ID=201, Name="amit1"});
        patients.Add(new Patient{ID=202, Name="amit2"});
        patients.Add(new Patient{ID=203, Name="amit4"});
        patients.Add(new Patient{ID=204, Name="amit4"});

        appointments.Add(new Appointment{dateTime=DateTime.Now, DoctorID=101, PatientID=202, Disease="Fever",Fees=200});
        appointments.Add(new Appointment{dateTime=DateTime.Now, DoctorID=102, PatientID=203, Disease="Headache",Fees=300});
        appointments.Add(new Appointment{dateTime=DateTime.Now, DoctorID=104, PatientID=201, Disease="Infection",Fees=400});
        appointments.Add(new Appointment{dateTime=DateTime.Now, DoctorID=103, PatientID=204,Disease="Fever",Fees=340});
        appointments.Add(new Appointment{dateTime=DateTime.Now, DoctorID=101, PatientID=202, Disease="Headache",Fees=430});

        //Get doctors with more than 2 appointments
        var doctorAppointments = appointments.GroupBy(x=>x.DoctorID).ToDictionary(g=>g.Key, g=>g.Count()).ToList().Where(x=>x.Value>2);
        foreach(var i in doctorAppointments)
        {
            Console.WriteLine($"Doctor id : {i}");
        }

        //Get patients treated in last 30 days
        var patientTreated = appointments.Where(x=>x.dateTime>=DateTime.Now.AddDays(-30)).ToList();
        foreach(var i in patientTreated)
        {
            Console.WriteLine($"Patient id : {i.PatientID}");
        }

        //Group appointments by doctor
        var groupDoctor = appointments.GroupBy(x=>x.DoctorID).ToList();
        foreach(var i in groupDoctor)
        {
            Console.WriteLine(i.Key);
            foreach(var j in i.ToList())
            {
                Console.WriteLine($"doctor id : {j.DoctorID}, patientid : {j.PatientID}");
            }
        }

        //Find top 3 highest earning doctors
        var topEarning = doctors.OrderByDescending(x=>x.Earning).Take(3).ToList();
        foreach(var i in topEarning)
        {
            Console.WriteLine($"doctot id : {i.ID}, name : {i.Name}");
        }

        //Get patients by disease
        Console.WriteLine("Enter disease : ");
        string input = Console.ReadLine()!;
        var patientDisease = appointments.Where(x=>x.Disease==input).ToList();
        foreach(var i in patientDisease)
        {
            Console.WriteLine($"patient id : {i.PatientID}");
        }

        //Calculate total revenue generated
        var totalRevenue = appointments.Sum(x=>x.Fees);
        Console.WriteLine("total revenue : "+totalRevenue);
    }
}