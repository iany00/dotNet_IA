using System;

namespace Timer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine();

            var timer = new Timer(2, 5);
            
            timer.Invoke();
           
        }
    }
}
