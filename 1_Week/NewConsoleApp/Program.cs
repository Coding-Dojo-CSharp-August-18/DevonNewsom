using System;
using System.Linq;

namespace NewConsoleApp
{
    class Program
    {
        // Entry Point!
        static void Main(string[] args)
        {

            // // string name = "devon";
            // // char d = 'd';

            // // int num = 10;
            // // long maxLongVal = Int64.MaxValue;


            // // long bigger = 10;
            // // short smaller = 10;

            // // bool IsCool = true;

            // // float floaty = 10.5f;
            // double doubly = 10.4;

            // // cast something
            // int intDoubly = (int)doubly;
            // int intCastFromMaxLong = (int)maxLongVal;

            // Collections
            int[] numbers = new int[]
            {
                124,45,345,213423,23423,34
            };

            Console.WriteLine(BiggestInt(numbers));

        }

        static int BiggestInt(int[] myArr)
        {
            // set var for current biggest
            int biggest = Int32.MinValue;

            // iterate array
            foreach(int num in myArr)
            {
            // set biggest to biggest if bigger is found
                if(num > biggest)
                    biggest = num;
            }

            // for(int i = 0; i < myArr.Length; i++)
            // {
            //     if(myArr[i] > biggest)
            //         biggest = myArr[i];
            // }

            return biggest;
        }
        
    }
}
