using ConferencePlanner.Entities;
using Dapper;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace Ex8Dapper
{
    public class SpeakerRepository
    {
        private string sqlConnectionString = @"data source =.\SQLExpress; database = ConferencePlanner; integrated security = SSPI";

        public List<Speaker> SpeakersExecuteDemo()
        {
            string sqlOrder = "SELECT * FROM Speakers WHERE Id = @SpeakerId;";
            string sqlOrderInsert = "INSERT INTO Speakers (Bio, WebSite, FullName) Values (@Bio, @WebSite, @FullName);";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                var speakersDetail = connection.QueryFirstOrDefault(sqlOrder, new { SpeakerId = 1 });

                var affectedRows = connection.Execute(sqlOrderInsert, new Speaker { Bio = "My Bio", WebSite = "www.mywebsite.com", FullName = "JOhn DOe"});

                var listOfSpeakers = connection.Query<Speaker>("select * from Speakers").ToList();

                return listOfSpeakers;
            }            
        }

        public List<AllSessionsAndSpeakersView> useViewFromDapper()
        {
            using (var connection = new SqlConnection(sqlConnectionString))
            {
                var sessonAndSpeakers = new AllSessionsAndSpeakersView();
                List<AllSessionsAndSpeakersView> data = connection.Query<AllSessionsAndSpeakersView>("select * from AllSessionsAndSpeakersView ", new { sessonAndSpeakers }).AsList();

                return data;
            }
        }

    }
}
