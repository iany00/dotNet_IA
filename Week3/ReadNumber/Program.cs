using System;
using System.Collections.Generic;

namespace ReadNumber
{
    class Program
    {
        static void ReadNumber(int start, int end)
        {
            int count = 1, number;
            List<int> ascNumbers = new List<int>();

            int current = start;
            do
            {
                Console.Write($"Number{count}: ");
                number = Int32.Parse(Console.ReadLine());

                if (number >= end || number <= current)
                {
                    throw new Exception("Inequality is not true' numbers must be  1 < a1 < ... < a10 < 100");              
                }
                else {
                    current = number;
                }
                ascNumbers.Add(number);
                count++;
            } while (count < 11);

            Console.WriteLine("\n");
            Console.Write($"{start}");

            foreach (int num in ascNumbers)
            {
                Console.Write($"<{num}");
            }
            Console.Write($"<{end}");
        }

        static void Main(string[] args)
        {
            Console.Write("Start: ");
            int start = Int32.Parse(Console.ReadLine());

            Console.Write("End: ");
            int end = Int32.Parse(Console.ReadLine());

            if (end <= start + 10)
            {
                Console.WriteLine("Must have a range of 10 numbers");
            }
            else
            {
                ReadNumber(start, end);
            }
            Console.ReadLine();
        }
    }
    
}
