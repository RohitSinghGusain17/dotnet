using System;
using System.IO;
using System.Xml.Serialization;

namespace Day12
{
    public class Student
    {
        public int RollNo { get; set; }
        public string? Name { get; set; }
        public int Age { get; set; }
        public int[]? Score{ get; set;}
        public List<int> Marks = new List<int>();
    }

    public class XmlSerializer
    {
    //     static void Main(string[] args)
    //     {
    //         Student s = new Student
    //         {
    //             RollNo = 101,
    //             Name = "Rohit",
    //             Age = 20,
    //             Score = [30,40,50,34,23],
    //             Marks=[34,54,65,67],
    //         };


    //         XmlSerializer serializer = new XmlSerializer(typeof(Student));

    //         using (StringWriter writer = new StringWriter())
    //         {
    //             serializer.Serialize(writer, s);
    //             string xml = writer.ToString();
    //             Console.WriteLine(xml);
    //         }
    //     }
    // }
}
}