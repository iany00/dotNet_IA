using System;
using System.Collections.Generic;
using System.Text;

namespace Homework_1
{
    //ok
    class Exercise5
    {
        internal static void Run()
        {
            Console.WriteLine("5.Write code to remove duplicates from an unsorted linked list.");

            // Create linked list
            string[] words = { "5", "2", "5", "4", "5", "2", "7", "ana", "ana", "mere", "ana" };
            LinkedList<string> linkedList = new LinkedList<string>(words);
            DisplayLinkedList.run(linkedList, "The linked list values: ");

            // Remove duplicates recursive
            var head = linkedList.First;
            RemoveDuplicates(linkedList, head);
            DisplayLinkedList.run(linkedList, "Linked list with no duplicates: ");

            Console.WriteLine("\n");
        }

        private static LinkedList<string> RemoveDuplicates(LinkedList<string> linkedList, LinkedListNode<string> head)
        {
            if (head == null)
            {
                return linkedList;
            }

            var currentItem = head;
            var comparator  = currentItem.Next;

            // Loop list starting from current item 
            while (comparator != null)
            {
                if (currentItem.Value == comparator.Value) // we have a match
                {
                    // Get next comparator and then delete the current comparator
                    var nextComparator = comparator.Next;
                    linkedList.Remove(comparator);
                    comparator = nextComparator; // replace var
                }
                else
                {
                    // Get next comparator
                    comparator = comparator.Next;
                }
            }

            return RemoveDuplicates(linkedList, head.Next);
        }
    }
}
