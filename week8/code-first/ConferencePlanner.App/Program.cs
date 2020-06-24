namespace ConferencePlanner.App
{
    using ConferencePlanner.Data.Entities;
    using Data;
    using Microsoft.EntityFrameworkCore;
    using System;
    using System.Linq;

    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var context = new ApplicationDbContext();

            Ex06.Run(context);

        }
    }

    internal class Ex01
    {
        public static void Run(ApplicationDbContext context)
        {
            // write a simple query to validate ApplicationDbContext
            var attendee = context.Attendees.Add(new Attendee
            {
                EmailAddress = "test2@gmail.com",
                FirstName = "test first name",
                LastName = "test last name",
                UserName = "test_username3",
                DateOfBirth = DateTime.Now

            });

            context.Tracks.Add(new Track { Name = "New Track" });

            context.SaveChanges();
        }
    }

    internal class Ex02
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Tracks table, add PHP, C# tracks with a seed
            // update ApplicationDbContext to run a seed

            // Tracks added on OnModelCreating in ApplicatioDbContext
        }
    }

    internal class Ex03
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // on Attendee model, add a new property, date of birth
            // add a migration, run the migration
            // insert then read a Attendee
            var attendee = context.Attendees.Add(new Attendee
            {
                EmailAddress = "test2@gmail.com",
                FirstName = "test first name",
                LastName = "test last name",
                UserName = "test_username4",
                DateOfBirth = DateTime.Now
            });
        }
    }

    internal class Ex04
    {
        public static void Run(ApplicationDbContext context)
        {
            // Todo
            // have a look on ConferencePlanner.Services and ISessionRepository
            // implement the repository inside the Data project
            // use the repository here in order to read 

            var repo = new BaseRepository<Attendee>(context);
            var attendeeById = repo.GetById(1);

            var repo2 = new BaseRepository<Track>(context);
            var allTracks = repo2.GetAll();
        }
    }

    internal class Ex05
    {
        // todo
        // rename the Speaker.Name to Speaker.FullName
        // you should add a migration

        /* Result: 
         * Build started...
            Build succeeded.
            An operation was scaffolded that may result in the loss of data. Please review the migration for accuracy.
            */
    }

    internal class Ex06
    {
        public static void Run(ApplicationDbContext context)
        {
            // all Sessions that title contains ".NET" on query results using Repository
            var repoSessions = new BaseRepository<Session>(context);
            var sessionTitle = repoSessions.GetAll().Where(s => s.Title.Contains(".NET")).ToList();

            // all Sessions that title contains ".NET" but use filter 
            var sessionTitle2 = repoSessions.Get(s => s.Title.Contains(".NET"));

            // number of sessions for each speaker using direct context
            var session = context.SessionSpeaker
                .GroupBy(x => x.SpeakerId)
                .Select(x => new
                {
                    Id = x.Key,
                    Count = x.Count()
                })
                .ToList();

            // number of tracks per session
            // all tracks for each session
        }
    }

    internal class Ex07
    {
        public static void Run(ApplicationDbContext context)
        {
            // get all sessions for one speaker
            // Lazy loading
            var speakers = context.Speakers.Include(c => c.SessionSpeakers).ToList();

        }
    }

    internal class Ex08
    {
        public static void Run()
        {
            // todo
            // create a separate project for dapper
            // implement the ISpeakerRepository using dapper

            //-- Done Ex8Dapper
        }
    }

    internal class Ex09
    {
        public static void Run()
        {
            // todo
            // create view
            /*
               create view AllSessionsAndSpeakersView as
               select ses.Title, sp.Name, ses.StartTime from Sessions ses
               join SessionSpeaker ss on ses.Id = ss.SessionId
               join Speakers sp on sp.Id = ss.SpeakerId
            */
            // use the view from Dapper
            // display all information at console

            //-- Done Ex8Dapper
        }
    }

    internal class Ex10
    {
        public static void Run()
        {
            // todo
            // use Dapper Plus
            // bulk insert 10 attendees
        }
    }
}
