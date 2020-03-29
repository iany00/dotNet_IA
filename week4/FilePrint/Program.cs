using System;
using System.IO;

namespace FilePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Give path:");
            var path = Console.ReadLine();

            if (Directory.Exists(path))
            {

                // This will print all the fils Recursively 
                //DirSearch(path);

                System.IO.DriveInfo di = new System.IO.DriveInfo(@""+path);
                System.IO.DirectoryInfo dirInfo = di.RootDirectory;

                // Get the files in the directory and print               
                System.IO.FileInfo[] fileNames = dirInfo.GetFiles("*.*");

                foreach (System.IO.FileInfo fi in fileNames)
                {
                    Console.WriteLine(fi.Name);
                }

                // iterate through an entire tree.
                System.IO.DirectoryInfo[] dirInfos = dirInfo.GetDirectories("*.*");

                foreach (System.IO.DirectoryInfo d in dirInfos)
                {
                    Console.WriteLine(d.Name);
                }

                // Get file name
                Console.WriteLine("Write file to read");
                var file = Console.ReadLine();

                if (File.Exists(path + file) == false)
                {
                    throw new Exception("File dose not exists!");
                }

                // show file number of lines
                var filePath   = path + file;
                string[] lines = System.IO.File.ReadAllLines(@"" + filePath);
                Console.WriteLine($"File has {lines.Length} number of lines");

                Console.WriteLine("Start Read from: ");
                int startLine;
                int.TryParse(Console.ReadLine(), out startLine);

                Console.WriteLine("End Read at: ");
                int endLine;
                int.TryParse(Console.ReadLine(), out endLine);

                if(startLine > endLine)
                {
                    throw new Exception("Invalide given line numbers");
                }

                // Read lines
                for (int i = startLine; i < endLine; i++)
                {
                    Console.WriteLine(lines[i]);
                }

            }
        }

        //Recursively print all files and folders
        static void DirSearch(string sDir)
        {
            try
            {
                foreach (string d in Directory.GetDirectories(sDir))
                {
                    foreach (string f in Directory.GetFiles(d))
                    {
                        Console.WriteLine(f);
                    }
                    DirSearch(d);
                }
            }
            catch (System.Exception excpt)
            {
                Console.WriteLine(excpt.Message);
            }
        }
    }
}
