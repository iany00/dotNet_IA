using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace Ex2___REST_API
{
    /*
        2. Create a console app that makes parallel HTTP requests to get all comments for each post returned by
        https://jsonplaceholder.typicode.com/posts 
        Comments for post https://jsonplaceholder.typicode.com/comments?postId=1 
        use http client, tasks with waitall()
    */

    class Program
    {

        static async Task Main(string[] args)
        {
            var stopwatch = Stopwatch.StartNew();

            var posts            = new Posts();
            var allPosts         = posts.GetAllPosts();
            var allCommentsTasks = new List<Task<List<Comment>>>();

            foreach (var post in allPosts)
            {
                allCommentsTasks.Add(Comment.GetCommentByPostId(post.id));
            }

            try
            {
                // Wait for all the tasks to finish.
                await Task.WhenAll(allCommentsTasks.ToArray());

                // Show post comment body
                foreach (var comments in allCommentsTasks)
                {
                    foreach (var comment in comments.Result)
                    {
                        Console.WriteLine(comment.body);
                    }
                }
            }
            catch (AggregateException e)
            {
                Console.WriteLine("\nThe following exceptions have been thrown by WaitAll(): (THIS WAS EXPECTED)");
                for (int j = 0; j < e.InnerExceptions.Count; j++)
                {
                    Console.WriteLine("\n-------------------------------------------------\n{0}", e.InnerExceptions[j].ToString());
                }
            }

            stopwatch.Stop();

            Console.WriteLine($"Elapsed time: {stopwatch.Elapsed.TotalMilliseconds} ms");
        }

    }
}
