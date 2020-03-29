using System;
using System.Collections.Generic;
using System.Linq;

namespace String
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = "karunya123.edu  , www.karunya.edu, www.karunya.edu,  http://karunya.edu, https://karunya.edu, www.karunyauniversity.in  ," +
                "  https://mykarunya.edu, https://www.karunya.edu  ,  google.com,  google.co.in, www.google.com,  https://www.gmail.com, gmail.com";

            Console.WriteLine("1.Extract all the URLs");

            string[] urlArr      = text.Split(',');
            List<string> UrlList = new List<string>();
            string[] domenii     = {".edu", ".in", ".com", ".co" };

            foreach (var item in urlArr)
            {
                if(item.StartsWith("http://") || item.StartsWith("https://") || item.StartsWith("www"))
                {
                    UrlList.Add(item.Trim());
                } else if(domenii.Any(x => item.Contains(x)))
                {
                    UrlList.Add(item.Trim());
                }
            }

            Console.WriteLine("2.Display all the URLs which start with https://");
            foreach (var url in UrlList)
            {
                if (url.Trim().StartsWith("https"))
                {
                    Console.WriteLine(url);
                }
            }

            Console.WriteLine("\n 3.URLs ending with .edu");
            var endingWithEdu =  UrlList.Where(x => x.EndsWith(".edu"));
            foreach (var item in endingWithEdu)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n 4.Replace all the vowels in url with given character");
            char caracter = Console.ReadKey().KeyChar;
            char[] vowels = { 'a','e','i','o','u' };

            List<string> modifiedStrings = new List<string>();
            foreach (var item in UrlList)
            {
                string newString = new string( item.Select(x => (vowels.Contains(x) ? 'x' : x)).ToArray());
                modifiedStrings.Add(newString);
            }

            Console.WriteLine("\n 5.Replace all the numbers in the URL with 1 and display");
            foreach (var item in UrlList)
            {
                if (item.Any(char.IsDigit))
                {
                    string newString = new string(item.Select(x => (Char.IsDigit(x) ? '1' : x)).ToArray());

                    Console.WriteLine(newString);
                }
            }

            Console.WriteLine("\n 6.Display all duplicate URLs");
            var duplicateUrls = UrlList.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);

            foreach (var item in duplicateUrls)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n 7.Concatenate any two URLs");            
            Console.WriteLine(UrlList[0] + UrlList[1]);


            Console.WriteLine("\n 8.Given any URL, display last occurence of any repeating character");
            var anyUrl = UrlList[0];
            var repeatingChars = anyUrl.GroupBy(x => x)
                        .Where(group => group.Count() > 1)
                        .Select(group => group.Key);

            Console.WriteLine(anyUrl);
            foreach (var item in repeatingChars)
            {
                var index1 = anyUrl.LastIndexOf(item);
                Console.WriteLine($"index: {index1} Caracter: {anyUrl[index1]}");
            }

            Console.WriteLine("\n 9.Insert [URL] at the beginning of URLs");
            UrlList.Insert(0, "www.insertUrlinsert.com");
            foreach (var item in UrlList)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("\n 10.Find out first occurence of character in given url");
            Console.WriteLine($"Giver caracter to find in {UrlList[0]}");
            var caracter2 = Console.ReadKey().KeyChar;
            Console.WriteLine(UrlList[0].IndexOf(caracter2));

            Console.WriteLine("11.List out all the URLs with substring 'oo' in it.");
            var ooUrls = UrlList.Where(x => x.Contains("oo")).Select(x => x);
            foreach (var item in ooUrls)
            {
                Console.WriteLine(item);
            }
        }
    }
}
