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
            Console.WriteLine();
            Console.WriteLine("#2 Write a C# Sharp program that takes two numbers as input and perform an " +
               "operation (+,-,*,x,/) on them and displays the result of that operation.\n");

            Console.Write("Input first number:");
            var firstNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input operation:");
            char operatie = Console.ReadKey().KeyChar;
            Console.WriteLine();

            Console.Write("Input second number:");
            var secondNumber = Convert.ToInt32(Console.ReadLine());

            var result = 0;
            switch (operatie)
            {
                case '+':
                    result = firstNumber + secondNumber;
                    Console.WriteLine($"{firstNumber} {operatie} {secondNumber} = {result}");
                    break;

                case '-':
                    result = firstNumber - secondNumber;
                    Console.WriteLine($"{firstNumber} {operatie} {secondNumber} = {result}");
                    break;

                case '*':
                    result = firstNumber * secondNumber;
                    Console.WriteLine($"{firstNumber} {operatie} {secondNumber} = {result}");
                    break;

                case '/':
                    result = firstNumber / secondNumber;
                    Console.WriteLine($"{firstNumber} {operatie} {secondNumber} = {result}");
                    break;

                default:
                    break;
            }
        }
    }
}
