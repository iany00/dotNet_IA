namespace LinqAndLamdaExpressions
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Models;

    internal class Program
    {
        private static void Main(string[] args)
        {
            List<User> allUsers = ReadUsers("users.json");
            List<Post> allPosts = ReadPosts("posts.json");

            #region Demo

            Console.WriteLine("#1");
            // 1 - find all users having email ending with ".net".
            var users1 = from user in allUsers
                         where user.Email.EndsWith(".net")
                         select user;

            var users11 = allUsers.Where(user => user.Email.EndsWith(".net"));

            IEnumerable<string> userNames = from user in allUsers
                                            select user.Name;

            var userNames2 = allUsers.Select(user => user.Name);

            foreach (var value in userNames2)
            {
                Console.WriteLine(value);
            }

            IEnumerable<Company> allCompanies = from user in allUsers
                                                select user.Company;

            var users2 = from user in allUsers
                         orderby user.Email
                         select user;

            var netUser = allUsers.First(user => user.Email.Contains(".net"));
            Console.WriteLine(netUser.Username);


            Console.WriteLine("\n#2");
            // 2 - find all posts for users having email ending with ".net".
            IEnumerable<int> usersIdsWithDotNetMails = from user in allUsers
                                                       where user.Email.EndsWith(".net")
                                                       select user.Id;

            IEnumerable<Post> posts = from post in allPosts
                                      where usersIdsWithDotNetMails.Contains(post.UserId)
                                      select post;

            foreach (var post in posts)
            {
                Console.WriteLine(post.Id + " " + "user: " + post.UserId);
            }
            #endregion


            // 3 - print number of posts for each user.
            var numOfPostQuery = from post in allPosts
                         group post by post.UserId into newGroup
                         join user in allUsers on newGroup.First().UserId equals user.Id
                         select new { name = user.Name , count = newGroup.Count()};


            Console.WriteLine("\n#3 Number of posts per users");
            foreach (var post in numOfPostQuery)
            {
                Console.WriteLine($"User : {post.name} number of posts: {post.count}");
            }

            // 4 - find all users that have lat and long negative.
            var latLong = from user in allUsers
                          where user.Address.Geo.Lat < 0 && user.Address.Geo.Lng < 0
                          select user;

            Console.WriteLine("\n#4\n User with lat and logn negative");
            foreach (var user in latLong)
            {
                Console.WriteLine(user.Name);
            }

            // 5 - find the post with longest body.
            var longestBody = allPosts.Where(post => post.Body.Length == allPosts.Max(maxPost => maxPost.Body.Length)).First();
            Console.WriteLine("\n#5  Post with longest body");
            Console.WriteLine("ID: " +longestBody.Id + " Body: " + longestBody.Body);


            // 6 - print the name of the employee that have post with longest body.
            var userLongestBody = from user in allUsers
                                  where longestBody.UserId == user.Id
                                  select user.Name;
            Console.WriteLine("\n#6 Name of the employee that have post with longest body");
            Console.WriteLine(userLongestBody.First());


            // 7 - select all addresses in a new List<Address>. print the list.
            List<Address> addresses = new List<Address>();
            var queryAddress = from user in allUsers
                               select user.Address;

            foreach (var address in queryAddress)
            {
                addresses.Add(new Address { 
                    City   = address.City, 
                    Street = address.Street, 
                    Geo    = new Geo { Lat = address.Geo.Lat, Lng = address.Geo.Lng },
                    Suite  = address.Suite, 
                    Zipcode = address.Zipcode 
                });
            }

            Console.WriteLine("\n#7  select all addresses in a new List<Address>. print the list.");
            foreach (var item in addresses)
            {
                Console.WriteLine(item.Street);
                Console.WriteLine(item.Suite);
                Console.WriteLine(item.City);
                Console.WriteLine(item.Zipcode);
                Console.WriteLine(item.Geo.Lng + " / " + item.Geo.Lat);
                Console.WriteLine("----------------------------------");
            }

            // 8 - print the user with min lat
            var minLatQuery = allUsers.Where(lat => lat.Address.Geo.Lat == allUsers.Min(minLat => minLat.Address.Geo.Lat)).First();
            Console.WriteLine("\n#8 print the user with min lat");
            Console.WriteLine(minLatQuery.Name);


            // 9 - print the user with max long
            var maxLongQuery = allUsers.Where(lng => lng.Address.Geo.Lng == allUsers.Max(maxLong => maxLong.Address.Geo.Lng)).First();
            Console.WriteLine("\n#9 print the user with max long");
            Console.WriteLine(maxLongQuery.Name);


            // 10 - create a new class: public class UserPosts { public User User {get; set}; public List<Post> Posts {get; set} }
            //    - create a new list: List<UserPosts>
            //    - insert in this list each user with his posts only
            List<UserPosts> ListOfUserPosts = new List<UserPosts>();

            var query3 = (from post in allPosts
                         group post by post.UserId into newGroup
                         join user in allUsers on newGroup.First().UserId equals user.Id
                         select new { userDetails = user, userPosts = newGroup }).ToList();

            foreach (var item in query3)
            {
                UserPosts userPost = new UserPosts();
                userPost.User      = item.userDetails;
                userPost.Posts     = item.userPosts.ToList();
                ListOfUserPosts.Add(userPost);               
            }

            // 11 - order users by zip code
            var orderUser = from user in allUsers
                            orderby user.Address.Zipcode
                            select user;

            // 12 - order users by number of posts
            // User query from #3
            var test = numOfPostQuery.OrderBy(Count => Count.count);

            Console.WriteLine("\n#12 order users by number of posts");
            foreach (var post in test)
            {
                Console.WriteLine($"User : {post.name} number of posts: {post.count}");
            }

            Console.ReadLine();
        }

        private static List<Post> ReadPosts(string file)
        {
            return ReadData.ReadFrom<Post>(file);
        }

        private static List<User> ReadUsers(string file)
        {
            return ReadData.ReadFrom<User>(file);
        }
    }
}
