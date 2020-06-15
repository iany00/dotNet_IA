using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Ex2___REST_API
{
    class Comment
    {

        public int postId { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string body { get; set; }

        static readonly HttpClient client = new HttpClient();

        public static async Task<List<Comment>> GetCommentByPostId(int id)
        {
            var uri = $"https://jsonplaceholder.typicode.com/comments?postId={id}";

            HttpResponseMessage response = await client.GetAsync(uri);
            response.EnsureSuccessStatusCode();
            string responseBody = await response.Content.ReadAsStringAsync();

            int tickCount = Environment.TickCount;
            Console.WriteLine("Task={0}, id={1}, TickCount={2}, Thread={3}", Task.CurrentId, id, tickCount, Thread.CurrentThread.ManagedThreadId);

            var deserialized = JsonConvert.DeserializeObject<List<Comment>>(responseBody);

            return deserialized;
        }



        public List<Comment> GetComments(int id)
        {
            var uri = $"https://jsonplaceholder.typicode.com/comments?postId={id}";

            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = "GET";
            request.AutomaticDecompression = DecompressionMethods.Deflate | DecompressionMethods.GZip;

            var content = string.Empty;

            using (var response = (HttpWebResponse)request.GetResponse())
            {
                using (var stream = response.GetResponseStream())
                {
                    using (var sr = new StreamReader(stream))
                    {
                        content = sr.ReadToEnd();
                    }
                }
            }

            var deserialized = JsonConvert.DeserializeObject<List<Comment>>(content);

            int tickCount = Environment.TickCount;
            Console.WriteLine("Task={0}, i={1}, TickCount={2}, Thread={3}", Task.CurrentId, id, tickCount, Thread.CurrentThread.ManagedThreadId);


            return deserialized;
        }
    }
}
