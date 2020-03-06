using System;
using System.Collections.Generic;

namespace Week1
{
    class Program
    {
        static void Main(string[] args)
        {
            Exercise1();

            Exercise2();

            Exercise3();

            Exercise4();

            Exercise5();

            Exercise12();
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

            double result = 0;
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
                    result = (double) firstNumber / secondNumber;
                    Console.WriteLine($"{firstNumber} {operatie} {secondNumber} = {result}");
                    break;

                default:
                    break;
            }
        }

        //#3
        private static void Exercise3()
        {
            Console.WriteLine();
            Console.WriteLine("#3 Write a C# Sharp program that takes a character as " +
                "input and check the input (lowercase) is a vowel, a digit, or any other symbol");

            char ch;
            ch = Convert.ToChar(Console.ReadLine().ToLower());
            int i = ch;
            if (i >= 48 && i <= 57)
            {
                Console.Write("It is a digit.");
            }
            else
            {
                string vowels = "aioue";
                bool containsSearchResult = vowels.Contains(ch);
                if (containsSearchResult)
                {
                    Console.WriteLine("It is a vowel");
                } else
                {
                    Console.WriteLine("It is a symbol");
                }
            }
        }
            
        //4
        private static void Exercise4()
        {
            Console.WriteLine("4. Write a C# Sharp program to accept the " +
                "height of a person in centimeter and categorize the person according to their height.");

            Console.Write("Height:");
            var height = Convert.ToInt32(Console.ReadLine());

            if (height < 150)
                Console.Write("The person is Dwarf. \n\n");
            else if ((height >= 150.0) && (height <= 195.0))
                Console.Write("The person is Tall. \n\n");
            else
                Console.Write("Abnormal.\n\n");
        }

        //5
        private static void Exercise5()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Write a C# Sharp program to check whether a triangle is Equilateral, Isosceles or Scalene.");

            int a, b, c;

            Console.Write("Input side 1 of triangle: ");
            a = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input side 2 of triangle: ");
            b = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input side 3 of triangle: ");
            c = Convert.ToInt32(Console.ReadLine());

            if (a == b && b == c)
            {
                Console.Write("This is an equilateral triangle.\n");
            }
            else if (a == b || a == c || b == c)
            {
                Console.Write("This is an isosceles triangle.\n");
            }
            else
            {
                Console.Write("This is a scalene triangle.\n");
            }
        }

        //12
        private static void Exercise12()
        {
            Console.WriteLine("\n\n");
            Console.WriteLine("Write a program in C# Sharp to insert New value in the array.\n");

            //ARRAYs are boring I will use LISTs

            List<int> integers = new List<int>() { 1, 8, 7, 10 };

            integers.ForEach(item => Console.Write(item + " "));
            Console.WriteLine("\n");

            Console.Write("Input the value to be inserted : ");
            var value = Convert.ToInt32(Console.ReadLine());

            Console.Write("Input the Position, where the value to be inserted : ");
            var position = Convert.ToInt32(Console.ReadLine());

            integers.Insert(position, value);
            Console.WriteLine("After Insert the element the new list is :");
            integers.ForEach(item => Console.Write(item + " "));
        }
    }

}
