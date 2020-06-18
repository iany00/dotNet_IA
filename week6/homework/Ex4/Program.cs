using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ex4
{
    class Program
    {
        /*4. Having the 10 files at some location (containing words), read the data using tasks and display:
            count of all words
            count of distinct words
            search for a specific word
            group words per categories
            xs (0-5 chars)
            s (5-10 chars)
            m (10-15 chars)
            l (larger than 15)
            ase repo path: https://github.com/andreiscutariu002/wantsome-dotnet-public/tree/master/group2/asyncprog.home/data 
            you can generate own files also using wantsome-dotnet-public/group2/asyncprog.home/sln/wordgenerator (just run the console)*/

        static async Task Main(string[] args)
        {
          
            FileManager fileManager = new FileManager();
            fileManager.ReadAllFiles();
          
            Console.WriteLine("Number of words: "+ fileManager.wordCount);

            Console.WriteLine("Number of distinct words: " + fileManager.distinctWordData.Count());

            Console.WriteLine("======== Words per group ========");
            foreach(KeyValuePair<string, List<string>> kvp in fileManager.wordGroup)
            {
                Console.WriteLine("Size " + kvp.Key + " group of words");
                Console.WriteLine("We have " + kvp.Value.Count() + " words in this group"); 
            }

            Console.WriteLine("Search for a word: ");
            var searchWord = Console.ReadLine();
            var result = fileManager.distinctWordData.ContainsKey(searchWord);
            if(result)
            {
                Console.WriteLine("Word Found!");
            } else
            {
                Console.WriteLine("Word not found!");
            }
        }
    }
}
