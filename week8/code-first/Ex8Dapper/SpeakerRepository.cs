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

        public List<Speaker> SpeakersExecute()
        {
            List<Speaker> speakers = new List<Speaker>();

            string sqlOrder = "SELECT * FROM Speaker WHERE Id = @Id;";
            string sqlOrderInsert = "INSERT INTO Speakers (Bio, WebSite, FullName) Values (@Bio, @WebSite, @FullName);";

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                var speakersDetail = connection.QueryFirstOrDefault<Speaker>(sqlOrder, new { Id = 1 });

                var affectedRows = connection.Execute(sqlOrderInsert, new Speaker { Bio = "My Bio", WebSite = "www.mywebsite.com", FullName = "JOhn DOe"});
                
                Console.WriteLine(affectedRows);

                var listOfSpeakers = connection.Query<Speaker>("select * from Speakers").ToList();

                return listOfSpeakers;
            }            
        }

    }
}
