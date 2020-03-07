using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Homework_1
{
    class Exercise2
    {
        
        public static void run()
        {
            Console.WriteLine("2.Given an unsorted array which has a number in " +
                "the majority (a number appears more than 50% in the array/list), find that number.");

            int[] nums = new int[] { 1, 7, 5, 7, 7, 7, 6, 8, 2, 4, 7, 9, 7 };
            Console.WriteLine(String.Join(" ", nums));

            var result = findMajority(nums);

            if (result > 0)
            {
                Console.WriteLine($"Major number found {result}");
            } else
            {
                Console.WriteLine("No major number found");
            }
            Console.WriteLine("\n");
        }

        /*
         * Find the number that is in majority (more than 50% in the array/list)
         */
        private static int findMajority(int[] arrayNums)
        {
            // Array length
            int arrayLength = arrayNums.Length;

            // Count each number in the array
            Dictionary<int, int> mapping = new Dictionary<int, int>();
            for (int i = 0; i < arrayLength; i++)
            {
                var currentNumber = arrayNums[i];
                if (!mapping.ContainsKey(currentNumber))
                {
                    // <number, count>
                    mapping.Add(arrayNums[i], 1);
                }
                else
                {
                    // <number, count>
                    mapping[currentNumber] = mapping[currentNumber] + 1;
                }
            }

            // Order list by value 
            var orderdMapping = mapping.OrderByDescending(i => i.Value);

            // Check if we have a major number
            var numberCount = orderdMapping.First();
            if(numberCount.Value >= arrayLength/2)
            {
                return numberCount.Key;
            }

            // no major number found
            return -1;
        }
    }
}
