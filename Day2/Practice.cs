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


            #region Answer 6
            // Console.WriteLine("Enter the number of units consumed:");
            // double units = Convert.ToDouble(Console.ReadLine());
            // double billAmount = 0;

            // if (units <= 199)
            // {
            //     billAmount = units * 1.20;
            // }
            // else if (units >= 200 && units < 400)
            // {
            //     billAmount = (199 * 1.20) + ((units - 199) * 1.50);
            // }
            // else if (units >= 400 && units < 600)
            // {
            //     billAmount = (199 * 1.20) + (200 * 1.50) + ((units - 399) * 1.80);
            // }
            // else if (units >= 600)
            // {
            //     billAmount = (199 * 1.20) + (200 * 1.50) + (200 * 1.80) + ((units - 599) * 2.00);
            // }
            // if (billAmount > 400)
            // {
            //     billAmount += billAmount * 0.15;
            // }
            // Console.WriteLine($"Total bill amount: {billAmount}");
            #endregion


            #region Answer 7
            // Console.WriteLine("Enter a character:");
            // char inputChar = Convert.ToChar(Console.ReadLine().ToLower());

            // switch (inputChar)
            // {
            //     case 'a':
            //     case 'e':
            //     case 'i':
            //     case 'o':
            //     case 'u':
            //         Console.WriteLine($"{inputChar} is a vowel.");
            //         break;
            //     default:
            //         if (char.IsLetter(inputChar))
            //         {
            //             Console.WriteLine($"{inputChar} is a consonant.");
            //         }
            //         else
            //         {
            //             Console.WriteLine("Please enter a valid alphabet character.");
            //         }
            //         break;
            // }
            #endregion



            #region Answer 8
            // Console.WriteLine("Enter length of side A:");
            // double sideA = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter length of side B:");
            // double sideB = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter length of side C:");
            // double sideC = Convert.ToDouble(Console.ReadLine());
            // if (sideA <= 0 || sideB <= 0 || sideC <= 0)
            // {
            //     Console.WriteLine("Side lengths must be positive numbers.");
            // }
            // else if (sideA == sideB && sideB == sideC)
            // {
            //     Console.WriteLine("The triangle is Equilateral.");
            // }
            // else if (sideA == sideB || sideB == sideC || sideA == sideC)
            // {
            //     Console.WriteLine("The triangle is Isosceles.");
            // }
            // else
            // {
            //     Console.WriteLine("The triangle is Scalene.");
            // }
            #endregion



            #region  Answer 9
            // Console.WriteLine("Enter the X coordinate:");
            // double x = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter the Y coordinate:");
            // double y = Convert.ToDouble(Console.ReadLine());
            // if (x > 0 && y > 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies in Quadrant 1.", x, y);
            // }
            // else if (x < 0 && y > 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies in Quadrant 2.", x, y);
            // }
            // else if (x < 0 && y < 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies in Quadrant 3.", x, y);
            // }
            // else if (x > 0 && y < 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies in Quadrant 4.", x, y);
            // }
            // else if (x == 0 && y != 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies on the Y axis.", x, y);
            // }
            // else if (y == 0 && x != 0)
            // {
            //     Console.WriteLine("The point ({0}, {1}) lies on the X axis.", x, y);
            // }
            // else
            // {
            //     Console.WriteLine("The point ({0}, {1}) is at the Origin.", x, y);
            // }
            #endregion



            #region Answer 10
            // Console.WriteLine("Enter your grade (E, V, G, A, F): ");
            // char grade = Convert.ToChar(Console.ReadLine().ToUpper());
            // switch (grade)
            // {
            //     case 'E':
            //         Console.WriteLine("Excellent");
            //         break;
            //     case 'V':
            //         Console.WriteLine("Very Good");
            //         break;
            //     case 'G':
            //         Console.WriteLine("Good");
            //         break;
            //     case 'A':
            //         Console.WriteLine("Average");
            //         break;
            //     case 'F':
            //         Console.WriteLine("Fail");
            //         break;
            //     default:
            //         Console.WriteLine("Invalid grade entered.");
            //         break;
            // }
            #endregion


            #region Ansewr 11
            // Console.WriteLine("Enter day:");
            // int day = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Enter month:");
            // int month = Convert.ToInt32(Console.ReadLine());
            // Console.WriteLine("Enter year:");
            // int year = Convert.ToInt32(Console.ReadLine());

            // bool isValidDate = false;
            // if (year >= 1 && month >= 1 && month <= 12 && day >= 1)
            // {
            //     int[] daysInMonth = { 31, (IsLeapYear(year) ? 29 : 28), 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            //     if (day <= daysInMonth[month - 1])
            //     {
            //         isValidDate = true;
            //     }
            // }
            // if (isValidDate)
            // {
            //     Console.WriteLine("The date {0}/{1}/{2} is valid.", day, month, year);
            // }
            // else
            // {
            //     Console.WriteLine("The date {0}/{1}/{2} is invalid.", day, month, year);
            // }
            // bool IsLeapYear(int yr)
            // {
            //     return (yr % 4 == 0 && yr % 100 != 0) || (yr % 400 == 0);
            // }
            #endregion

            

            #region  Answer 12
            // Console.WriteLine("Enter Card Inserted (true/false): ");
            // bool isCardInserted = Convert.ToBoolean(Console.ReadLine());
            // Console.WriteLine("Enter Pin Valid (true/false): ");
            // bool isPinValid = Convert.ToBoolean(Console.ReadLine());
            // Console.WriteLine("Enter Account Balance: ");
            // double accountBalance = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter Withdrawal Amount: ");
            // double withdrawalAmount = Convert.ToDouble(Console.ReadLine());
            // if (isCardInserted)
            // {
            //     if (isPinValid)
            //     {
            //         if (accountBalance >= withdrawalAmount)
            //         {
            //             accountBalance -= withdrawalAmount;
            //             Console.WriteLine($"Withdrawal successful! New balance: {accountBalance}");
            //         }
            //         else
            //         {
            //             Console.WriteLine("Insufficient balance.");
            //         }
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid PIN.");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Please insert your card.");
            // }
            #endregion



            #region Answer 13
            // Console.WriteLine("Enter Cost Price:");
            // double costPrice = Convert.ToDouble(Console.ReadLine());
            // Console.WriteLine("Enter Selling Price:");
            // double sellingPrice = Convert.ToDouble(Console.ReadLine());

            // if (sellingPrice > costPrice)
            // {
            //     double profit = sellingPrice - costPrice;
            //     double profitPercentage = (profit / costPrice) * 100;
            //     Console.WriteLine($"Profit: {profit}, Profit Percentage: {profitPercentage}%");
            // }
            // else if (costPrice > sellingPrice)
            // {
            //     double loss = costPrice - sellingPrice;
            //     double lossPercentage = (loss / costPrice) * 100;
            //     Console.WriteLine($"Loss: {loss}, Loss Percentage: {lossPercentage}%");
            // }
            // else
            // {
            //     Console.WriteLine("No profit, no loss.");
            // }
            #endregion



            #region Answer 14
            // Console.WriteLine("Player 1: Enter your choice (rock, paper, scissors):");
            // string player1Choice = Console.ReadLine().ToLower();
            // Console.WriteLine("Player 2: Enter your choice (rock, paper, scissors):");
            // string player2Choice = Console.ReadLine().ToLower();
            // if (player1Choice == player2Choice)
            // {
            //     Console.WriteLine("It's a tie!");
            // }
            // else if (player1Choice == "rock")
            // {
            //     if (player2Choice == "scissors")
            //     {
            //         Console.WriteLine("Player 1 wins! Rock crushes scissors.");
            //     }
            //     else if (player2Choice == "paper")
            //     {
            //         Console.WriteLine("Player 2 wins! Paper covers rock.");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid choice by Player 2.");
            //     }
            // }
            // else if (player1Choice == "paper")
            // {
            //     if (player2Choice == "rock")
            //     {
            //         Console.WriteLine("Player 1 wins! Paper covers rock.");
            //     }
            //     else if (player2Choice == "scissors")
            //     {
            //         Console.WriteLine("Player 2 wins! Scissors cut paper.");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid choice by Player 2.");
            //     }
            // }
            // else if (player1Choice == "scissors")
            // {
            //     if (player2Choice == "paper")
            //     {
            //         Console.WriteLine("Player 1 wins! Scissors cut paper.");
            //     }
            //     else if (player2Choice == "rock")
            //     {
            //         Console.WriteLine("Player 2 wins! Rock crushes scissors.");
            //     }
            //     else
            //     {
            //         Console.WriteLine("Invalid choice by Player 2.");
            //     }
            // }
            // else
            // {
            //     Console.WriteLine("Invalid choice by Player 1.");
            // }
            #endregion


            #region Answer 15
            Console.WriteLine("Enter first number:");
            double num1 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter second number:");
            double num2 = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter operator (+, -, *, /):");
            char op = Console.ReadLine()[0];
            double result = 0;
            switch (op)
            {
                case '+':
                    result = num1 + num2;
                    break;
                case '-':
                    result = num1 - num2;
                    break;
                case '*':
                    result = num1 * num2;
                    break;
                case '/':
                    if (num2 != 0)
                    {
                        result = num1 / num2;
                    }
                    else
                    {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                        return;
                    }
                    break;
                default:
                    Console.WriteLine("Invalid operator. Please use +, -, *, or /.");
                    return;
            }
            Console.WriteLine("Result: " + result);
            #endregion
        }
    }
}
