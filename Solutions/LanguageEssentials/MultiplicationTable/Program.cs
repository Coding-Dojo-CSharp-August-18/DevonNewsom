using System;

namespace MultiplicationTable
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] table = new int[10, 10];
            for (int i = 0; i < 10; i++)
            {

                for (int j = 0; j < 10; j++)
                {
                    table[i,j] = (i + 1) * (j + 1);
                }

            }
            DisplayTable(table);
        }

        public static void DisplayTable(int[,] table)
        {
            for (int i = 0; i < 10; i++)
            {
                string output = "[";

                for (int j = 0; j < 10; j++)
                {
                    output += table[i, j] + ", ";
                }
                output += "]";
                Console.WriteLine(output);
            }
        }
    }
}
