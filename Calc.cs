using System;

namespace dotnetday2
{
    public class Calc
    {
        #region IsEven function
        /// <summary>
        /// Even or Odd
        /// </summary>
        /// <param name="number"></param>
        /// <returns>Even or odd</returns>
        public bool IsEven(int number)
        {
            return (number % 2 == 0) ? true : false;
        }
        #endregion

        #region Input output
        public static void Main(string[] args)
        {
            Calc calc = new Calc();
            Console.Write("Enter the number : ");
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int number))
            {
                Console.WriteLine(calc.IsEven(number));

            }
            else
            {
                Console.WriteLine("enter valid integer");
            }
        }
        #endregion
    }
}