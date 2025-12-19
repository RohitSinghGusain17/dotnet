using System;

namespace dotnetday2
{
    public class Practice {
        public static void Main(string[] args)
        {
            #region Answer 1
            // Console.Write("Enter height in cm : ");
            // string? input = Console.ReadLine();
            // if(int.TryParse(input, out int height)){
            //     if (height < 150)
            //     {
            //         Console.WriteLine("Dwarf");
            //     }
            //     else if(height>=150 && height<165){
            //         Console.WriteLine("Average");
            //     }
            //     else if(height>=165 && height < 190)
            //     {
            //         Console.WriteLine("Tall");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Abnormal");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Enter valid height(in cm).");
            // }
            #endregion



            #region Answer 2
            // int value1, value2, value3;
            // Console.Write("Enter integer 1 : ");
            // while(!int.TryParse(Console.ReadLine(),out value1))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }
            // Console.Write("Enter integer 2 : ");
            // while(!int.TryParse(Console.ReadLine(),out value2))
            // {
            //     Console.Write("Enter correct integer value : ");

            // }
            // Console.Write("Enter integer 3 : ");   
            // while(!int.TryParse(Console.ReadLine(),out value3))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }
            // if (value1 > value2)
            // {
            //     if (value1 > value3)
            //     {
            //         Console.WriteLine("Largest value is value1");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Largest value is value3");
            //     }
            // }
            // else if (value2 > value3)
            // {
            //     Console.WriteLine("Largest value in value2");
            // }
            // else
            // {
            //     Console.WriteLine("Largest value is value3");
            // }
            #endregion



            #region Answer 3
            // int year;
            // Console.Write("Enter year : ");
            // while(!int.TryParse(Console.ReadLine(),out year))
            // {
            //     Console.Write("Enter correct year : ");
            // }
            // if(year%400==0  || (year%4==0 && year%100!=0))
            // {
            //     Console.WriteLine("Leap Year.");
            // }
            // else
            // {
            //     Console.WriteLine("Not a leap year.");
            // }
            #endregion



            #region Answer 4
            // int a, b, c;
            // Console.Write("Enter a : ");
            // while(!int.TryParse(Console.ReadLine(),out a))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }
            // Console.Write("Enter b : ");
            // while(!int.TryParse(Console.ReadLine(),out b))
            // {
            //     Console.Write("Enter correct integer value : ");

            // }
            // Console.Write("Enter c : ");   
            // while(!int.TryParse(Console.ReadLine(),out c))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }

            // double d = b*b - 4*a*c;
            // double e = Math.Sqrt(d);
            // double root1 = (-b + e) / 2*a;
            // double root2 = (-b - e) / 2*a;
            // Console.WriteLine("Roots are "+ root1 + " and " + root2);
            #endregion



            #region Answer 5
            // int math, physics, chem;
            // Console.Write("Enter physics marks : ");
            // while(!int.TryParse(Console.ReadLine(),out physics))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }
            // Console.Write("Enter chem marks : ");
            // while(!int.TryParse(Console.ReadLine(),out chem))
            // {
            //     Console.Write("Enter correct integer value : ");

            // }
            // Console.Write("Enter math marks : ");
            // while(!int.TryParse(Console.ReadLine(),out math))
            // {
            //     Console.Write("Enter correct integer value : ");
            // }
            // int total = math+physics+chem;

            // if(math >= 65 && physics>=55 && chem>=50 && (total>=180 || math + physics >= 140))
            // {
            //     Console.WriteLine("you are eligible for admission.");
            // }
            // else
            // {
            //     Console.WriteLine("you are not eligible for admission");
            // }
            #endregion
            
        }
    }
}
