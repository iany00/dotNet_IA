using System;
using System.Collections.Generic;

namespace IEnumerable_extensions
{
    class Program
    {
        static void Main(string[] args)
        {
            var list = new List<int> { 1, 2, 3, 4, 5 };
            Console.WriteLine(IEnumerableExtensionMethods.Average(list));
            Console.WriteLine(IEnumerableExtensionMethods.Sum(list));
            Console.WriteLine(IEnumerableExtensionMethods.Product(list));
            Console.WriteLine(IEnumerableExtensionMethods.Min(list));
        }
    }
}
