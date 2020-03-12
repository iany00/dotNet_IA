using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    // ok
    class Exercise1
    {
        internal static void Run()
        {
            Console.WriteLine("1. Write a function to remove duplicate characters from String.");
            Console.Write("Enter a String : ");

            string inputStrings = Console.ReadLine();
            string resultString = string.Empty;

            for (int i = 0; i < inputStrings.Length; i++)
            {
                if (!resultString.Contains(inputStrings[i]))
                {
                    resultString += inputStrings[i];
                }
            }
            Console.WriteLine(resultString);

            Console.WriteLine("\n");
        }
    }
}
