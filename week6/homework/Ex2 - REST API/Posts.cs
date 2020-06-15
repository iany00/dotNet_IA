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
    class Posts
    {
        public int id { get; set; }
        public int userId { get; set; }
        public string title { get; set; }
        public string body { get; set; }


        public List<Posts> GetAllPosts()
        {
            var uri = "https://jsonplaceholder.typicode.com/posts";
            var content = string.Empty;
            var request = (HttpWebRequest)WebRequest.Create(uri);

            request.Method = "GET";

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

            var deserialized = JsonConvert.DeserializeObject<List<Posts>>(content);

            return deserialized;
        }


    }
}
