using System.Diagnostics.Metrics;

namespace Day16
{
    public class Program
    {
        //Function for region enum basic
        public static string GetWeekDays(WeekDays weekDays,ref int numValue)
        {
            numValue=(int)weekDays;
            return weekDays.ToString();
        }
        //Function for region enum basic
        public static String MenuByDay(WeekDays day)
        {
            switch(day)
            {
                case WeekDays.Monday:
                    return "Pasta";
                case WeekDays.Tuesday:
                    return "Tacos";
                case WeekDays.Wednesday:
                    return "Chicken Curry";
                case WeekDays.Thursday:
                    return "Pizza";
                case WeekDays.Friday:
                    return "Fish and Chips";
                case WeekDays.Saturday:
                    return "Burgers";
                case WeekDays.Sunday:
                    return "Roast Dinner";
                default:
                    return "Unknown Day";
            }
        }

        //Function for region callback
        static void SendEmail(string msg) => Console.WriteLine("EMAIL: " + msg);
        static void SendSms(string msg) => Console.WriteLine("SMS:   " + msg); //Function for region callback

        //Function for Question 5 (Student Scholarship)
        public static bool ScholarshipEligibility(Student std)
        {
            if(std.Marks>80 && std.SportsGrade == 'A')
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //Function for CustomException
        public static int? Divide(int a, int b)
        {
            try
            {
                if (b == 0)
                {
                    throw new AppCustomException();
                }
            }
            catch(AppCustomException ex)
            {
                Console.WriteLine("Message:"+ex.Message);
            }
            return null;
        }

        //Main
        public static void Main(string[] args)
        {
            #region Question 4 (Broadband Plans)
            // var plans = new List<IBroadbandPlan>
            // {new Black(true, 50), new Black(false, 10),
            // new Gold(true, 30), new Black(true, 20), new Gold(false, 20)
            // };

            // var subscriptionPlans = new SubscribePlan(plans);
            // var result = subscriptionPlans.GetSubscriptionPlan();
            // foreach (var item in result)
            // {
            //     Console.WriteLine($"{item.Item1},{item.Item2}");
            // }
            #endregion


            #region Question 5 (Student Scholarship)
            // List<Student> lstStudents = new List<Student>();
            // Student obj1 = new Student() { RollNo = 1,Name = "Raj", Marks = 75, SportsGrade = 'A' };
            // Student obj2 = new Student() { RollNo = 2,Name = "Rahul", Marks = 82, SportsGrade = 'A'};
            // Student obj3 = new Student() { RollNo = 3,Name = "Kiran", Marks = 89, SportsGrade = 'B' };
            // Student obj4 = new Student() { RollNo = 4,Name = "Sunil", Marks = 86, SportsGrade = 'A' };
            // lstStudents.Add(obj1);
            // lstStudents.Add(obj2);
            // lstStudents.Add(obj3);
            // lstStudents.Add(obj4);
            // string? ans = Student.GetEligibleStudents(lstStudents,ScholarshipEligibility);
            // // Console.WriteLine(ans);
            // for(int i=0;i<ans.Length - 2;i++)
            // {
            //     Console.Write(ans[i]);
            // }
            // Console.WriteLine();
            #endregion


            #region enum basic
            // WeekDays today = WeekDays.Wednesday;
            // Console.WriteLine("today is : "+today);
            // Products category = Products.Electronics;
            // Console.WriteLine("Selected Category: "+category+" with Value: "+(int)category);
            // int numValuePara = 0;
            // string variableForDay = GetWeekDays(WeekDays.Thursday, ref numValuePara);
            // Console.WriteLine(variableForDay);
            // Console.WriteLine(numValuePara);
            #endregion


            #region callback
            // var service = new OrderService();
            // // Pass a method as callback
            // service.PlaceOrder("ORD-101", SendEmail);
            // // Pass another method as callback
            // service.PlaceOrder("ORD-102", SendSms);
            #endregion


            #region Custom Exception
            int? divide = Divide(10,0);
            Console.WriteLine(divide);
            #endregion
        }
    }
}