using System;
using System.Text.RegularExpressions;
using System.Collections.Generic;
namespace Day10
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Console.Write("Enter string: ");
            // string str = Console.ReadLine()!;
            // str.CheckPalindrome();


            #region RegEx
            // string input ="Error: TIMEOUT while calling API";
            // string pattern = @"timeout";
            // // Thread.Sleep(20); //delay

            // var rx = new Regex(
            //     pattern,
            //     RegexOptions.IgnoreCase,
            //     TimeSpan.FromMilliseconds(1500) // match timeout (Regex execution timeout)
            // );
            // Console.WriteLine(rx.IsMatch(input) ? "Found" : "Not Found");
            #endregion


            #region Garbage collection
            // var list = new List<int[]>();
            // for(int i = 0; i < 2000; i++)
            // {
            //     list.Add(new int[1024]);
            // }
            // Console.WriteLine("allocated");
            // Console.WriteLine("Total memory: "+GC.GetTotalMemory(forceFullCollection: false));
            #endregion

            #region Idisposible
            // BigBoy bigboy = new BigBoy();
            // try
            // {
            //     bigboy.Names = new System.Collections.ArrayList();
            //     for(int i = 0; i < 10; i++)
            //     {
            //         bigboy.Names.Add(i.ToString());
            //     }
            // }
            // catch(Exception)
            // {
            //     throw;
            // }
            // finally
            // {
            //     bigboy.Dispose();
            // }
            #endregion

            
            #region 
            MyCollection m = new MyCollection();
            Console.WriteLine(m.Add(12));
            Console.WriteLine(m.Add(102));
            Console.WriteLine(m.Add(121));

            #endregion
        }
    }
}
