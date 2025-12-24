using System;

namespace constructorAdd
{
    public class consAdd{
        #region Declaration
        public int num1{get; set;}
        public int num2{get; set;}
        public int result{get;}

        #endregion
        public consAdd(int input1, int input2)
        {
            num1=input1;
            num2=input2;
            result= num1+num2;
            //only in constructor get property can set the values.
            Console.WriteLine("Sum of num1 and num2 is : "+ (result));
        }
    }
}