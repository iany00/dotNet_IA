namespace RaceCondition
{
    using System;
    using System.Diagnostics;
    using System.Threading;

    internal class Program
    {
        private static object counterLock = new object();

        public static void Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            long totalSum = 0;
            long nr = 100000000;

            var t1 = new Thread(() =>
            {
                for (int i = 0; i < nr; i++)
                {
                    Interlocked.Add(ref totalSum, nr);
                }
            });

            var t2 = new Thread(() =>
            {
                for (int i = 0; i < nr; i++)
                {
                    Interlocked.Add(ref totalSum, nr);
                }
            });

            t1.Start();
            t2.Start();

            t1.Join();
            t2.Join();

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
            Console.WriteLine($"Sum: {totalSum}");

            //Elapsed time: 7352.9615 ms
            //Sum: 20000000000000000
            /*
             * Elapsed time: 5284.5506 ms
            Sum: 20000000000000000
            */
        }
    }
}
