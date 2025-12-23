using System;

namespace dotnetday2
{
    public class LoopPractice
    {
        public static void Main(string[] args)
        {
            #region Answer 1
            // Console.WriteLine("Enter your Number:");
            // int Number = int.Parse(Console.ReadLine()!);
            // int firstNumber = 0, secondNumber = 1, nextNumber;
            // Console.WriteLine("Fibonacci Series:");

            // for (int i = 0; i < Number; i++)
            // {
            //     if (i <= 1)
            //     {
            //         nextNumber = i;
            //     }
            //     else
            //     {
            //         nextNumber = firstNumber + secondNumber;
            //         firstNumber = secondNumber;
            //         secondNumber = nextNumber;
            //     }
            //     Console.WriteLine(nextNumber);
                
            // }
            #endregion



            #region Answer 2
            // Console.WriteLine("Enter a number to check if it is prime:");
            // int number = int.Parse(Console.ReadLine()!);
            // bool isPrime = true;
            // if (number <= 1)
            // {
            //     isPrime = false;
            // }
            // else
            // {
            //     for (int i = 2; i <= Math.Sqrt(number); i++)
            //     {
            //         if (number % i == 0)
            //         {
            //             isPrime = false;
            //             break;
            //         }
            //     }
            // }
            // Console.WriteLine(isPrime ? "The number is prime." : "The number is not prime.");
            #endregion


            #region Answer 3
            // Console.WriteLine("Enter a number:");
            // int number = int.Parse(Console.ReadLine()!);
            // int originalNumber = number;
            // int sum = 0;
            // int numberOfDigits = number.ToString().Length;
            // while (number > 0)
            // {
            //     int digit = number % 10;
            //     sum += (int)Math.Pow(digit, numberOfDigits);
            //     number /= 10;
            // }
            // if (sum == originalNumber)
            // {
            //     Console.WriteLine($"{originalNumber} is equal to the sum of its digits raised to the power of number of digits.");
            // }
            // else
            // {
            //     Console.WriteLine($"{originalNumber} is not equal to the sum of its digits raised to the power of number of digits.");
            // }          
            #endregion



            #region Answer 4
            // Console.WriteLine("Enter an integer:");
            // int number = int.Parse(Console.ReadLine()!);
            // int reversedNumber = 0;
            // int tempNumber = number;
            // while (tempNumber != 0)
            // {
            //     int digit = tempNumber % 10;
            //     reversedNumber = reversedNumber * 10 + digit;
            //     tempNumber /= 10;
            // }
            
            // Console.WriteLine("Reversed Number: " + reversedNumber);
            // Console.WriteLine("Is Palindrome: " + (number == reversedNumber));
            #endregion



            #region Answer 5
            // Console.WriteLine("Enter first number:");
            // int num1 = int.Parse(Console.ReadLine()!);
            // Console.WriteLine("Enter second number:");
            // int num2 = int.Parse(Console.ReadLine()!);
            // int a = num1;
            // int b = num2;
            // while (b != 0)
            // {
            //     int temp = b;
            //     b = a % b;
            //     a = temp;
            // }
            // int gcd = a;
            // int lcm = (num1 * num2) / gcd;
            // Console.WriteLine("Greatest Common Divisor (GCD): " + gcd);
            // Console.WriteLine("Least Common Multiple (LCM): " + lcm);
            #endregion


            #region Answer 6
            // Console.Write("Enter n : ");
            // int n=int.Parse(Console.ReadLine()!);
            // for (int i = 0; i < n; i++)
            // {
            //     int number = 1;

            //     for (int space = 0; space < n - i; space++)
            //         Console.Write(" ");

            //     for (int j = 0; j <= i; j++)
            //     {
            //         Console.Write(number + " ");
            //         number = number * (i - j) / (j + 1);
            //     }
            //     Console.WriteLine();
            // }
            #endregion


            #region Answer 7
            // string binary = "1011";
            // int decimalValue = 0;
            // int power = 1;
            // for (int i = binary.Length - 1; i >= 0; i--)
            // {
            //     if (binary[i] == '1')
            //         decimalValue += power;

            //     power *= 2;
            // }
            // Console.WriteLine("Decimal value: " + decimalValue);
            #endregion


            #region  Answer 8
            #endregion


            #region  Answer 9
            // int n = 20;
            // int fact = 1;
            // for (int i = 1; i <= n; i++)
            //     fact *= i;
            // Console.WriteLine("Factorial: " + fact);
            #endregion


            #region Answer 10
            int secret = 7;
            int guess;
            do
            {
                Console.Write("Guess the number: ");
                guess = int.Parse(Console.ReadLine()!);
                if (guess != secret)
                    Console.WriteLine("Wrong guess, try again.");
            } while (guess != secret);
            Console.WriteLine("Correct! You guessed it.");
            #endregion
        }
    }
}