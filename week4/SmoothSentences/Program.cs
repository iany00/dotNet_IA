using System;
using System.Collections.Generic;
using System.Linq;

namespace SmoothSentences
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Write a smooth santance");
            string smooth = Console.ReadLine();

            if(IsSmooth(smooth))
            {
                Console.WriteLine("Is Smooth");
            } else
            {
                Console.WriteLine("Is not Smooth");
            }

        }

        public static bool IsSmooth(string smooth)
        {
            List<string> words = new List<string>();

            words = smooth.Split(' ').ToList();

            for (int i = 0; i < words.Count -1; i++)
            {
                var currentWord = words[i];
                var nextWord = words[i + 1];

                if(currentWord.Last() != nextWord.First())
                {
                    return false;
                }
            }

            return true;
        }
    }
}
