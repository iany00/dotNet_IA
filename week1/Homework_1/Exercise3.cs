using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    // ok
    class Exercise3
    {
        internal static void Run()
        {
            Console.WriteLine("3.Count the frequency of chars in a string.");

            string str;
            int[] char_frec = new int[255];
            int ascii;

            Console.Write("Enter string: ");
            str = Console.ReadLine();
            int length = str.Length;

            // count chars by ascii code
            var ch = 0;
            while (ch < length)
            {
                ascii = (int)str[ch];
                char_frec[ascii] += 1;

                ch++;
            }

            // Show all char counts
            for (int i = 0; i < char_frec.Length; i++)
            {
                if (char_frec[i] > 0)
                {
                    Console.WriteLine($"char :" + (char)i +" counts: " + char_frec[i]);
                }
            }

            Console.WriteLine("\n");
        }
    }
}
