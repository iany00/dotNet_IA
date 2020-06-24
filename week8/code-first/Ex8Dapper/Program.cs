using System;

namespace Ex8Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new SpeakerRepository();
            var speakers = repo.SpeakersExecuteDemo();

            var sessionsFromView = repo.useViewFromDapper();

            foreach (var item in sessionsFromView)
            {
                Console.WriteLine(item.Title + " " + item.FullName + " " + item.StartTime);
            }
        }
    }
}
