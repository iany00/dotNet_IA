using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    // ok
    class Exercise4
    {
        // Run
        internal static void Run()
        {
            Console.WriteLine("4.Write code to reverse a linked list, if you able to do it using loops, try to solve with recursion.\n");

            // Create a linked list
            string[] words = { "1", "2", "3", "4", "5", "6", "7" };
            LinkedList<string> linkedList = new LinkedList<string>(words);
            DisplayList(linkedList, "The linked list values: ");


            // Simple reverse list
            LinkedList<string> reverseList = SimpleReverseList(linkedList);
            DisplayList(reverseList, "Linked list reverse order: ");


            // Create new list
            string[] rcwords = { "In", "Paduread", "Cu", "Alune"};
            LinkedList<string> recLinkedList = new LinkedList<string>(rcwords);
            DisplayList(recLinkedList, "The linked list values: ");


            // Recursive reverse
            LinkedListNode<string> head         = recLinkedList.First;
            LinkedList<string> recReverseList   = RecursiveReverseList(recLinkedList, head);
            DisplayList(recReverseList, "Linked list recursive reverse order: ");

            Console.WriteLine("\n");

        }

        // recursive reverse
        private static LinkedList<string> RecursiveReverseList(LinkedList<string> recLinkedList, LinkedListNode<string> head)
        {
            if (head.Next == null)
            {
                return recLinkedList;
            }

            var next = head.Next;
            recLinkedList.Remove(next);
            recLinkedList.AddFirst(next.Value);

            return RecursiveReverseList(recLinkedList, head);
        }

        // Simple reverse
        private static LinkedList<string> SimpleReverseList(LinkedList<string> lkedList)
        {
            var head = lkedList.First;
            while (head.Next != null)
            {
                var next = head.Next;
                lkedList.Remove(next);
                lkedList.AddFirst(next.Value);
            }

            return lkedList;
        }

        // Display
        private static void DisplayList(LinkedList<string> words, string prefix)
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
