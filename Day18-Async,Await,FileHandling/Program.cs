using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Day18
{
    public class Program
    {
        // private static Action<string> GoodDay()
        // {
        //     throw new NotImplementedException();
        // }

        private static Action<string> NewMethod()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message} at {DateTime.Now}");
            };
        }

        private static Action<string> GoodDay()
        {
            return message =>
            {
                Console.WriteLine($"Good Day to you");
            };
        }

        private static Action<string> GoodMoring()
        {
            return message =>
            {
                Console.WriteLine($"Good Morning");
            };
        }

        private static Action<string> Method1()
        {
            return message =>
            {
                Console.WriteLine($"[LOG]: {message.ToUpper()} at {DateTime.Now}");
            };
        }

        private static Action<string> Method2()
        {
            return message =>
            {
                Console.WriteLine($"Welcome to Programming");
            };
        }

        public static void Even()
        {
            for(int i = 0; i < 100; i += 2)
            {
                Thread.Sleep(100);
                Console.Write(i+" ");
            }
        }

        public static void odd()
        {
            for(int i = 1; i < 100; i += 2)
            {
                Thread.Sleep(100);
                Console.Write(i+" ");
            }
        }

        public static async Task Main(string[] args)
        {
            #region Work
            // Work<int,string> work = new Work<int, string>();
            // work.Add(1,"Rohit");
            // work.Add(2,"Sumit");
            // work.show();
            #endregion
            

            #region Predicate
            // For method that test condition
            // Predicate<int> isEven = number => number %2 == 0;
            // bool ans = isEven(10);
            // Console.WriteLine(ans);
            #endregion


            #region Action
            //For method that return "void"
            // Action<string> logger = message =>
            // {
            //     Console.WriteLine($"Log {message} at {DateTime.Now}");
            // };
            // logger("hello");
            #endregion


            #region Action example
            // Action<string> logger = NewMethod();

            // if (DateTime.Now.Hour < 12)
            // {
            //     logger = GoodMoring();
            // }
            // else
            // {
            //     logger = GoodDay();
            // }

            // logger("dd");
            // logger = Method2();
            // logger("Application Started"); // Invoking the Action
            #endregion


            #region Thread
            // Thread o= new Thread(odd);
            // Thread e = new Thread(Even);
            // o.Start();
            // e.Start();
            #endregion

            // await ThreadExample.AsyncMethod();
            // await ThreadExample.CallMethod();

            using(StreamWriter w = new StreamWriter("new.txt"))
            {
                w.WriteLine("Hello");
                w.WriteLine("Hello World");
            }

            using(StreamReader r = new StreamReader("new.txt"))
            {
                string temp="";
                while ((temp = r.ReadLine()!) != null)
                {
                    System.Console.WriteLine(temp);

                }
            }

            File.Delete("new.txt");

        }
    }
}
