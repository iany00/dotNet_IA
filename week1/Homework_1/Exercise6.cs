using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    class Exercise6
    {
        internal static void Run()
        {
            Console.WriteLine("6.Given a string s consists of upper/lower-case alphabets and empty space characters ' ', " +
                "return the length of last word in the string.");

            Console.Write("Enter string: ");
            string s = Console.ReadLine();
            Console.WriteLine("The length of the last word is: " + LengthOfLastWord(s));
        }

        private static int LengthOfLastWord(string s)
        {
            int LengthWord = 0;

            string[] words = s.Split(' ');

            if(words.Length > 0)
            {
                LengthWord = words[words.Length - 1].Length;
            }

            return LengthWord;
        }
    }
}
