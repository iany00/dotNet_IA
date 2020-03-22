using System;

namespace BitArray64
{
    class Program
    {
        static void Main(string[] args)
        {
            BitArray64 simpleBitArray = new BitArray64(10);

            foreach (var bit in simpleBitArray)
            {
                Console.Write(bit);
            }

            Console.WriteLine("\n");
            Console.WriteLine(simpleBitArray[2] == simpleBitArray[62]);
            Console.WriteLine("\n");


            simpleBitArray[2] = 1;
            simpleBitArray[10] = 1;

            foreach (var bit in simpleBitArray)
            {
                Console.Write(bit);
            }

            Console.WriteLine("\n");
            Console.WriteLine(simpleBitArray[2] == simpleBitArray[10]);

            Console.Read();
        }
    }
}
