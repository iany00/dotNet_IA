using System;

namespace Ex3
{
    class Program
    {

        /*3. Implement using threads, tasks, async/await
            Implement a console app that process files from a specific location. The program "watches" in that location for new files.
            Files should be processed in the order in which they are added to the folder.
            After 10 files is processed, the content is displayed to console and the program exit.
            Publisher/consumer pattern could be used.
            Notes:
            An worker wait for files. each file is dispatched to a consumer.
            At the same time, cannot be processed more than 4 files.
            When a consumer process files, read the file and add the content to shared data structure.
            After 10 files are processed, each file name + content are displayed.
        */

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
