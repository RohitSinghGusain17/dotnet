using System.Formats.Asn1;

namespace dotnetday5
{
    /// <summary>
    /// Abstract class Employee
    /// </summary>
    public abstract class Employee
    {
        /// <summary>
        /// Abstract function
        /// </summary>
        /// <param name="income"></param>
        /// <returns></returns>
        
        public abstract double TaxCalc(int income);
    }

    public class IndianEmployee : Employee
    {
        public override double TaxCalc(int income)
        {
            if (income < 500000)
            {
                return income*0.00;
            }
            else if (income >= 500000 && income<1000000)
            {
                return income*0.10;
            }
            else if(income>=10000000 && income < 2000000)
            {
                return income*0.20;
            }
            else
            {
                return income*0.30;
            }
        }
    }

    public class USEmployee : Employee
    {
        public override double TaxCalc(int income)
        {
            if (income < 3000)
            {
                return income*0.00;
            }
            else if (income >= 3000 && income<6000)
            {
                return income*0.10;
            }
            else if(income>=6000 && income < 10000)
            {
                return income*0.20;
            }
            else
            {
                return income*0.30;
            }
        }
    }
}