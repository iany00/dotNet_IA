using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex4
{
    class FileManager
    {
        public FileManager()
        {
            // get all document files
            GetDirectorFiles();

            // Create empty word groups
            CreateEmptyWordGroup();
        }

        private void CreateEmptyWordGroup()
        {
            wordGroup.Add("xs", new List<string>()); // xs(0 - 5 chars)
            wordGroup.Add("s", new List<string>());  // s(5 - 10 chars)
            wordGroup.Add("m", new List<string>());  // m(10 - 15 chars)
            wordGroup.Add("l", new List<string>());  // l(larger than 15)
        }

        private static readonly object padlock = new object();
        private string directoryPath = Path.Combine(Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, "Ex4\\dataFiles");
        private List<string> fileNames = new List<string>();

        public List<string> sharedData = new List<string>();
        public Dictionary<string, string> distinctWordData = new Dictionary<string, string>();
        public Dictionary<string, List<string>> wordGroup = new Dictionary<string, List<string>>();
        public int wordCount;

        /*
         */
        public void GetDirectorFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(directoryPath);
            FileInfo[] dirFiles = dir.GetFiles("*.dat"); //Getting Text files

            foreach (FileInfo file in dirFiles)
            {
                fileNames.Add(file.Name);
            }
        }

        /*
         */
        public void ReadAllFiles()
        {
            var tasks = new List<Task>();
           
            //TPL
             Parallel.ForEach(fileNames, (currentFile) =>
             {
                 ReadFile(currentFile);
             });
        }

        /*
         */
        public void ReadFile(string fileName)
        {
            int tickCount = Environment.TickCount;
            Console.WriteLine("Task={0}, id={1}, TickCount={2}, Thread={3}", Task.CurrentId, fileName, tickCount, Thread.CurrentThread.ManagedThreadId);

            string[] lines = System.IO.File.ReadAllLines(directoryPath + "\\" + fileName);

            lock (padlock) // thread safe on read
            {
                foreach (string line in lines)
                {
                    // shared data with all words
                    sharedData.Add(line);

                    // Shared Distinct word list 
                    distinctWordData[line] = line;
                }
                GroupWords(lines);
            }

            wordCount += lines.Length;
        }

        /*
         */
        internal void GroupWords(string[] words)
        {
            var xsList = new List<string>();
            var sList = new List<string>();
            var mList = new List<string>();
            var lList = new List<string>();

            foreach (var item in words)
            {
                var itemLength = item.Length;
                if (itemLength <= 5)
                {
                    wordGroup["xs"].Add(item);
                }
                else if (itemLength <= 10)
                {
                    wordGroup["s"].Add(item);
                }
                else if (itemLength <= 15)
                {
                    wordGroup["m"].Add(item);
                }
                else
                {
                    wordGroup["l"].Add(item);
                }
            }
        }
    }
}
