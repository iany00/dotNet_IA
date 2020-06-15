namespace DemoSum
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    internal class Program
    {
        private static void Main(string[] args)
        {
            var arraySize = 50000000; // 50 000 000
            
            var array = BuildAnArray(arraySize);

            var stopwatch = Stopwatch.StartNew();

            var arrayProcessorT1 = new ArrayProcessor(array, 0, arraySize / 2);
            Thread T1 = new Thread(() => {             
                arrayProcessorT1.CalculateSum();
            });
            T1.Start();

            var arrayProcessorT2 = new ArrayProcessor(array, arraySize / 2, arraySize/2);
            Thread T2 = new Thread(() => {              
                arrayProcessorT2.CalculateSum();
            });

            T2.Start();
            T1.Join();
            T2.Join();

            var totalSum = arrayProcessorT1.Sum + arrayProcessorT2.Sum;

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Sum: {totalSum}");
        }

        public static int[] BuildAnArray(int size)
        {
            var array = new int[size];

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = i;
            }

            return array;
        }
    }
}
