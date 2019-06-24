using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NLog;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Solution_4
{
    class Program
    {
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        private const string url = "https://jsonplaceholder.typicode.com/posts";

        private static List<Post> Posts { get; set; } = new List<Post>();
        private static Dictionary<int, int> UserPosts { get; set; } = new Dictionary<int, int>();


        static void Main(string[] args)
        {
            ParseJson();
            while (true)
            {
                Console.Write("Enter command: ");
                string userCommand = Console.ReadLine();
                string[] splitUserCommand = userCommand.Split(' ');
                string mainCommand = splitUserCommand[0];
                switch (mainCommand)
                {
                    case ("refresh"):
                        Console.Clear();
                        ParseJson();
                        break;
                    case ("stat"):
                        DataGrouping(Posts);
                        break;
                    case ("page"):
                        try
                        {
                            string page = splitUserCommand[1];
                            if (Int32.TryParse(page, out int result))
                            {
                                PrintPage(result);
                            }
                            else
                            {
                                Console.WriteLine("Incorrect syntax");
                            }
                        }
                        catch (ArgumentOutOfRangeException e)
                        {
                            Console.WriteLine("Incorrect syntax");
                            logger.Error(e);
                        }
                        break;
                    case ("exit"):
                        return;
                    default:
                        break;
                }
            }
        }

        private static List<Post> SortListByUserId(List<Post> posts)
        {
            var list = from post in posts
                       orderby post.UserId ascending
                       orderby post.Id ascending
                       select post;

            return list.ToList();
        }

        private static void PrintPage(int page)
        {
            if (page <= 0)
            {
                Console.WriteLine("Incorrect page");
                return;
            }
            List<Post> posts = SortListByUserId(Posts);

            posts.RemoveRange(84, 5);

            int maxContentOnAPage = 20;
            int startPost = (page - 1) * maxContentOnAPage + 1;
            int endPost = startPost + maxContentOnAPage;
            if (startPost > posts.Count)
            {
                Console.WriteLine("Page doesn't exist");
                return;
            }
            if (endPost > posts.Count)
            {
                endPost = posts.Count;
            }
            for (int i = startPost; i < endPost; i++)
            {
                var post = posts[i-1];
                var title = post.Title;
                if (title.Length > 30)
                {
                    title = title.Substring(0, 30) + "...";
                }
                Console.WriteLine($"User with Id {post.UserId} posted '{title}'");
            }
        }

        private static void DataGrouping(List<Post> posts)
        {
            foreach (var item in Posts)
            {
                var userID = item.UserId;
                if (UserPosts.ContainsKey(userID))
                {
                    UserPosts[userID]++;
                }
                else
                {
                    UserPosts.Add(userID, 1);
                }
            }
            foreach (var item in UserPosts)
            {
                Console.WriteLine($"User with Id {item.Key} has {item.Value} posts");
            }
        }

        private static void ParseJson()
        {
            var json = MethodForRestSharp(url);
            JArray jArray = JArray.Parse(json);
            foreach (var item in jArray)
            {
                Posts.Add(new Post(
                    Int32.Parse(item["userId"].ToString()),
                    Int32.Parse(item["id"].ToString()),
                    item["title"].ToString(),
                    item["body"].ToString()));
            }
        }

        /// <summary>
        /// Return response via RestSharp
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>response as string</returns>
        private static string MethodForRestSharp(string url)
        {
            var client = new RestClient(url);
            var request = new RestRequest(Method.GET);
            Console.WriteLine($"Start of connection to {url}");
            IRestResponse response = client.Execute(request);
            if (response.StatusCode == HttpStatusCode.OK)
            {
                Console.WriteLine($"{response.ResponseStatus} - {response.StatusCode}"); 
            }
            else
            {
                Console.WriteLine($"{response.ResponseStatus} - {response.StatusCode}");
            }
            return response.Content;
        }

        /// <summary>
        /// Return response via WebRequest
        /// </summary>
        /// <param name="url">url</param>
        /// <returns>response as string</returns>
        private static string MethodForWebRequest(string url)
        {
            string result = "";
            var request = (HttpWebRequest)WebRequest.Create(url);
            using (var response = (HttpWebResponse)request.GetResponse())
            {
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var receiveStream = response.GetResponseStream();
                    if (receiveStream != null)
                    {
                        StreamReader streamReader;
                        if (response.CharacterSet == null)
                        {
                            streamReader = new StreamReader(receiveStream);
                        }
                        else
                        {
                            streamReader = new StreamReader(receiveStream, Encoding.GetEncoding(response.CharacterSet));
                        }
                        result = streamReader.ReadToEnd();
                        streamReader.Close();
                    }
                }
            }
            return result;
        }
    }
}
