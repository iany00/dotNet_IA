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

        public List<Speaker> GetAllSpeakers()
        {
            List<Speaker> speakers = new List<Speaker>();

            using (var connection = new SqlConnection(sqlConnectionString))
            {
                var listOfSpeakers = connection.Query<Speaker>("select * from Speakers").ToList();
                /*var orderDetail = connection.QueryFirstOrDefault<Speaker>(sqlOrder, new { OrderId = 1 });
                var affectedRows = connection.Execute(sqlOrderInsert, new Order { CustomerId = 1, EmployeeId = 2, OrderDate = DateTime.Now });
                Console.WriteLine(orderDetails.Count);
                Console.WriteLine(affectedRows);*/

                return listOfSpeakers;
            }            
        }

    }
}
