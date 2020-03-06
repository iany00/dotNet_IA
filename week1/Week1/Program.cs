using System;

namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {

            Exercise1();

            Exercise2();
             
        }

        //1. Write a C# Sharp program that takes three letters as input and display them in reverse order.
        private static void Exercise1()
        {
            Console.WriteLine("Write a C# Sharp program that takes three letters as input and display them in reverse order.");
            
            var length = 3;
            var letters = new char[length];

            for (int i = 0; i < length; i++)
            {
                letters[i] = Console.ReadKey().KeyChar;
            }

            Console.WriteLine();
            Array.Reverse(letters, 0, length);
            Console.WriteLine(letters);
        }


        //2
        private static void Exercise2()
        {
           /* Console.WriteLine("Write a C# Sharp program that takes two numbers as input and perform an " +
               "operation (+,-,*,x,/) on them and displays the result of that operation.");

            Console.WriteLine("Input first number:")
            var firstNumber = Console.ReadLine();
            var operatie    = Console.ReadLine();
            var secondNumber = Console.ReadLine();*/
        }
    }
}
