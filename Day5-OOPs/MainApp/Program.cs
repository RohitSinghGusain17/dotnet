using LoginAbs;
using MathLib;
using ScienceLib;
using dotnetday5;
using payment;

namespace MainApp
{
    public class Program
    {
        static void Main(string[] args)
        {

            #region Mainapp code
            //MathLibrary math = new MathLibrary();
            //Console.WriteLine(math.add(2, 3));
            //ScienceLibrary science = new ScienceLibrary();
            //Console.WriteLine(science.AeroDensity(2, 4));

            // Authentication auth = new Authentication();
            // auth.LoginFunc("user", "abc");
            #endregion


            #region IND user
        // Console.Write("Enter your income(in INR): ");
        // int income = int.Parse(Console.ReadLine()!);
        // IndianEmployee ind = new IndianEmployee();
        // Console.WriteLine("Your income tax is : "+ind.TaxCalc(income));
        #endregion

        #region US user
        // Console.Write("Enter your income(in USD): ");
        // int income = int.Parse(Console.ReadLine()!);
        // USEmployee us = new USEmployee();
        // Console.WriteLine("Your income tax is : "+us.TaxCalc(income));
        #endregion


        #region payment
        Payment upi = new UPIpayment(300.0,"rohit@upi");
        upi.Pay();
        upi.PrintRecipt();
        #endregion
        }
    }
}
