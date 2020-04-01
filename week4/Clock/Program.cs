using System;

namespace Clock
{
    class Program
    {
        static void Main(string[] args)
        {
            BusinessDate today = BusinessDate.Today;
            BusinessDate testDay = BusinessDate.Parse("2020-07-04");

            var stringDate = testDay.ToString();     // "2020-07-04"
            int july       = testDay.Month;  // 7

            Console.WriteLine(stringDate);
            Console.WriteLine(july);
            Console.WriteLine(today);
        }
    }
}
