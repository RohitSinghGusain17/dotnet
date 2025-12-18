using System;
using System.Formats.Asn1;
class Program{
    static void Main(string[] args){
        //Console.WriteLine("Enter your name: ");
        //string? name = Console.ReadLine();
        //Console.WriteLine("Hello "+ name);



        // Console.WriteLine("Enter number: ");
        // int num = int.Parse(Console.ReadLine());
        // if (num % 2 == 0){
        //     Console.WriteLine("Not Prime.");
        // }
        // else
        // {
        //     bool flag = false;
        //     for(int i = 3; i*i <= num; i+=2){
        //         if (num % i == 0){
        //             flag = true;
        //             break;
        //         }
        //     }
        //     if (flag){
        //         Console.WriteLine("Not Prime.");
        //     }
        //     else {
        //         Console.WriteLine("It is Prime.");
        //     }
        // }



        // Console.Write("Enter age : ");
        // string? input = Console.ReadLine();

        // if(int.TryParse(input, out int age))
        // {
        //     bool isAdult= age>=18;
        //     Console.WriteLine("Adult: " + isAdult);
        // }
        // else
        // {
        //     Console.WriteLine("Invalid age. Please enter a whole number.");
        // }



        Console.Write("Enter feet to convert : ");
        string? input = Console.ReadLine();
        if(double.TryParse(input, out double feet)){
            if (feet < 0){
                Console.WriteLine("Feet can't be negative");
            }
            else{
                Console.WriteLine("Answer is : "+ feet*30.48+ "cm");
            }
        }
    }
}