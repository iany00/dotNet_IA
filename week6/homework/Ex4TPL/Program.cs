using System;

namespace Ex4TPL
{
    class Program
    {
        static async Task Main(string[] args)
        {

            FileManager fileManager = new FileManager();
            fileManager.ReadAllFiles();

            Console.WriteLine("Number of words: " + fileManager.wordCount);

            Console.WriteLine("Number of distinct words: " + fileManager.distinctWordData.Count());

            Console.WriteLine("======== Words per group ========");
            foreach (KeyValuePair<string, List<string>> kvp in fileManager.wordGroup)
            {
                Console.WriteLine("Size " + kvp.Key + " group of words");
                Console.WriteLine("We have " + kvp.Value.Count() + " words in this group");
            }

            Console.WriteLine("Search for a word: ");
            var searchWord = Console.ReadLine();
            var result = fileManager.distinctWordData.ContainsKey(searchWord);
            if (result)
            {
                Console.WriteLine("Word Found!");
            }
            else
            {
                Console.WriteLine("Word not found!");
            }
        }
    }
}
