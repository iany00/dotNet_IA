using System;
using System.Collections.Generic;

namespace Homework3
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> test = new MyList<int>(3);
            test.Add(4);
            test.Add(5);
            test.Add(6);
            test.Remove(6);
            
            foreach (var item in test)
            {
                Console.WriteLine(item);
            }            
        }
    }
}
