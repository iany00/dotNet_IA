using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex3
{
    public sealed class Processor
    {
        Processor() { }
        private static readonly object padlock = new object();
        private static Processor instance = null;
        public static Processor Instance
        {
            get
            {
                lock (padlock)
                {
                    if (instance == null)
                    {
                        instance = new Processor();
                    }
                    return instance;
                }
            }
        }
        public string FilePath { get; set; }

        public Queue<string> FilePathQueue = new Queue<string>();

        List<string> processedFiles = new List<string>();

        private static readonly SemaphoreSlim Sem = new SemaphoreSlim(4); // Capacity of 4

        public void ProccessFile()
        {
            FilePathQueue.Enqueue(FilePath);
            new Thread(ConsumeFiles).Start();
        }

        private void ConsumeFiles()
        {
            var filePath = FilePathQueue.Dequeue();

            Console.WriteLine(filePath + " wants to enter");

            Sem.Wait();

            Console.WriteLine(filePath + " is in!");

            // Do your work
            Process(filePath);

            Console.WriteLine(filePath + " is leaving");

            Sem.Release();

            lock (padlock) // thread safe on read
            {
                // Display 10 procced files
                if (processedFiles.Count >= 10)
                {
                    DisplayProccesdFiles();
                }
            }
        }

        private void Process(string filePath)
        {
            Thread.Sleep(3000); // some time
            string text = System.IO.File.ReadAllText(filePath);
            lock (padlock)  // thread safe on write
            {
                processedFiles.Add(text);             
            }
        }

        private void DisplayProccesdFiles()
        {
            Console.WriteLine("-------------------------- 10 file proccessed - show content--------------------"); 
            foreach (var item in processedFiles)
            {
                Console.WriteLine(item);
            }
            processedFiles.Clear();
        }

    }
}
