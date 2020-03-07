using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    class DisplayLinkedList
    {
        // Display
        internal static void run(LinkedList<string> words, string prefix)
        {
            Console.Write(prefix);
            foreach (string word in words)
            {
                Console.Write(word + " ");
            }
            Console.WriteLine("\n");
        }
    }
}
