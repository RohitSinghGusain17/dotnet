using System.Text.Json;
public class Student
{
     public int RollNo { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
}

// public class JsonSerializer1
//     {
//         static void Main(string[] args)
//         {
//             Student s = new Student
//             {
//                 RollNo = 101,
//                 Name = "Rohit",
//                 Age = 20,
//             };

//             string jsonString = JsonSerializer.Serialize(s); // Use System.Text.Json namespace
//             Console.WriteLine(jsonString);
//         }
//     }