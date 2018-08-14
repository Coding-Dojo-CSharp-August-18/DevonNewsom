using System;

namespace CollectionsPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            // Arrays
            int arraySize = 10;

            // Create an array to hold integer values 0 through 9
            int[] numbers = new int[arraySize];
            for (int num = 0; num < arraySize; num++)
                numbers[num] = num;

            // Create an array of the names "Tim", "Martin", "Nikki", & "Sara"
            string[] strArray = {"Tim", "Martin", "Nikki", "Sara"};

            // Create an array of length 10 that alternates between true and false values, starting with true
            bool[] booleans = new bool[arraySize];
            for (int index = 0; index < arraySize; index++)
            {
                if(index % 2 == 0)
                    booleans[index] = true;
                else
                    booleans[index] = false;
            }


        }
    }
}