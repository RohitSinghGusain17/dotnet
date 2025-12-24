using System;
using System.Collections.Generic;
using System.Text;

namespace Day6
{
     interface Iprint
    {
        public void Print();
    }

    class Child : Iprint
    {
        public void Print()
        {
            Console.WriteLine("Hello World");
        }
    }

}
