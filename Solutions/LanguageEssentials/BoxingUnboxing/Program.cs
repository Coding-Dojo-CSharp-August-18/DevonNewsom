using System;
using System.Collections.Generic;

namespace BoxingUnboxing
{
     public class Program
    {
        public static void Main(string[] args)
        {
            // Create an empty List of type object
            List<object> myList = new List<object>();

            // Add the following values to the list: 7, 28, -1, true, "chair"
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
            Boxerz b = new Boxerz();
            //b.DisplayValues();
            int theSum = b.AddIntsFromList(b.myList);
            System.Console.WriteLine(theSum);
        }
    }
    class Boxerz
    {
        public List<object> myList;
        public Boxerz()
        {
            myList = new List<object>();
            myList.Add(7);
            myList.Add(28);
            myList.Add(-1);
            myList.Add(true);
            myList.Add("chair");
        }
        public static void DisplayValues(List<object> items)
        {
            for(int i = 0; i < items.Count; i++)
            {
                System.Console.WriteLine(items[i]);
            }
        }
        public int AddIntsFromList(List<object> list)
        {
            int sum = 0;
            for(int i = 0; i < myList.Count; i++)
            {
                if(myList[i] is int)
                {
                    sum += (int)myList[i];
                }
            }
            return sum;
        }
    }
}
