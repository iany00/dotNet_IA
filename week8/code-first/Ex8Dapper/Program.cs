using System;

namespace Ex8Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            var repo = new SpeakerRepository();
            var speakers = repo.SpeakersExecute();
        }
    }
}
