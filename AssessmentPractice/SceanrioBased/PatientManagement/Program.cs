public class Patient
{
    public int PatientId{get; set;}
    public string? Name{get; set;}
    public int Age{get; set;}
    public string? BloodGroup{get; set;}
    public List<string> MedicalHistory = new List<string>();
}

public class Doctor
{
    public int DoctorId{get; set;}
    public string? Name{get; set;}
    public string? Specialization{get; set;}
    public List<DateTime> AvailableSlots = new List<DateTime>();
}

public class Appointment
{
    public int AppointmentId{get; set;}
    public int PatientId{get; set;}
    public int DoctorId{get; set;}
    public DateTime AppointmentTime{get; set;}
    public string? Status{get; set;}
}

public class HospitalManager
{
    private int patientId = 1;
    private int doctorId = 1;
    private int appointmentId = 1;

    public List<Patient> Patients = new List<Patient>();
    public List<Doctor> Doctors = new List<Doctor>();
    public List<Appointment> Appointments = new List<Appointment>();

    public void AddPatient(string name, int age, string bloodGroup)
    {
        Patients.Add(new Patient{PatientId = patientId++, Name = name, Age = age, BloodGroup = bloodGroup});
    }

    public void AddDoctor(string name, string specialization)
    {
        Doctors.Add(new Doctor{DoctorId = doctorId++, Name = name, Specialization = specialization});
    }

    public bool ScheduleAppointment(int patientId, int doctorId, DateTime time)
    {
        var patient = Patients.FirstOrDefault(x => x.PatientId == patientId);
        var doctor = Doctors.FirstOrDefault(x => x.DoctorId == doctorId);

        if (patient == null || doctor == null)
        {
            return false;
        }

        bool busy = Appointments.Any(x =>x.DoctorId == doctorId && x.AppointmentTime == time && x.Status == "Scheduled");

        if (busy)
        {
            return false;
        }

        Appointments.Add(new Appointment{AppointmentId = appointmentId++, PatientId = patientId, DoctorId = doctorId, AppointmentTime = time, Status = "Scheduled"});

        return true;
    }

    public Dictionary<string, List<Doctor>> GroupDoctorsBySpecialization()
    {
        Dictionary<string, List<Doctor>> result = new Dictionary<string, List<Doctor>>();
        var groups = Doctors.GroupBy(x => x.Specialization);

        foreach (var g in groups)
        {
            result[g.Key!] = g.ToList();
        }

        return result;
    }

    public List<Appointment> GetTodayAppointments()
    {
        DateTime today = DateTime.Today;

        return Appointments.Where(x => x.AppointmentTime.Date == today).ToList();
    }
}


public class Program
{
    public static void Main()
    {
        HospitalManager hospital = new HospitalManager();

        hospital.AddPatient("Rohit", 21, "B+");
        hospital.AddPatient("Aman", 25, "O+");

        hospital.AddDoctor("Dr. Sharma", "Cardiology");
        hospital.AddDoctor("Dr. Mehta", "Dermatology");

        // Schedule appointment
        Console.WriteLine(hospital.ScheduleAppointment(1, 1, DateTime.Now.AddHours(1)));

        // Today's appointments
        Console.WriteLine("\nToday's Appointments:");
        foreach (var a in hospital.GetTodayAppointments())
        {
            Console.WriteLine($"Patient {a.PatientId} -> Doctor {a.DoctorId}");
        }

        // Group doctors
        var groups = hospital.GroupDoctorsBySpecialization();
        Console.WriteLine("\nDoctors by Specialization:");

        foreach (var g in groups)
        {
            Console.WriteLine(g.Key + ":");
            foreach (var d in g.Value)
            {
                Console.WriteLine($"  {d.DoctorId} - {d.Name}");
            }
        }
    }
}