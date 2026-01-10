namespace Day16
{
    public delegate bool IsEligibleforScholarship(Student std);

    public class Student
    {
        public int RollNo{get; set;}
        public string? Name{get; set;}
        public int Marks{get; set;}
        public char SportsGrade{get; set;}

        public static string GetEligibleStudents(List<Student>studentsList, IsEligibleforScholarship isEligible)
        {
            string ans="";
            foreach(Student i in studentsList)
            {
                if (isEligible(i))
                {
                    ans+=i.Name+", ";
                }
            }
            return ans;
        }
    }
}