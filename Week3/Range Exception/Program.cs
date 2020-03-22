using System;

namespace Range_Exception
{
    class Program
    {
        static void Main(string[] args)
        {
            InvalidRangeException<int> integerException = new InvalidRangeException<int>("Invalid Number; Must be betweem 1-100 ", 1, 100);

            Console.WriteLine("Please enter a number between 1 - 100");
            int number;
            Int32.TryParse(Console.ReadLine(), out number);
            if(number < integerException.Min || number > integerException.Max)
            {
                throw integerException;
            } else
            {
                Console.WriteLine("Number is correct!");
            }
            

            InvalidRangeException<DateTime> dateException = new InvalidRangeException<DateTime>("Invalid Date; Date must be between 1.1.1980 - 31.12.2013", new DateTime(1980, 1, 1), new DateTime(2013, 12, 31));

            Console.WriteLine("Please enter a date between 01.01.1980 and 31.12.2013");
            DateTime date;
            DateTime.TryParse(Console.ReadLine(), out date);

            if(date < dateException.Min || date > dateException.Max)
            {
                throw dateException;
            } else
            {
                Console.WriteLine("Date is correct");
            }
        }
    }
}
