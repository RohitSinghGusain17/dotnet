using System;

namespace dotnetday2
{
    public class Student
    {
        #region Declaration
        private string name="";
        private double rollno;
        private double marks;
        public string section="";
        #endregion

        #region Constructor
        public Student(string sectionInput)
        {
            section = sectionInput;
        }
        #endregion
        
        #region Set Function
        public void setname(string input,double rollnoInput, double marksInput)
        {
            name = input;
            rollno = rollnoInput;
            marks = marksInput;
        }
        #endregion
        
        #region Get Function
        public void getname()
        {
            Console.WriteLine("Name of student is : "+ name);
            Console.WriteLine("rollno : "+ rollno);
            Console.WriteLine("marks : "+ marks);
        }
        #endregion
        public static void Main(string[] args)
        {
           Console.Write("Enter name : ");
           string input = Console.ReadLine()!;
           double rollnoInput, marksInput;
           Console.Write("Enter Roll No. : ");
           while(!double.TryParse(Console.ReadLine(),out rollnoInput))
           {
               Console.Write("Enter correct value : ");
           }
           Console.Write("Enter subject : ");
           string subjectInput = Console.ReadLine()!;
           Console.Write("Enter marks : ");
           while(!double.TryParse(Console.ReadLine(),out marksInput))
           {
               Console.Write("Enter correct value : ");
           }
           Student s1 = new Student(subjectInput);
           s1.setname(input,rollnoInput,marksInput);
           s1.getname();
        }
    }
}