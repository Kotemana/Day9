using System;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace Day9
{
    class Program
    {
        static void Main(string[] args)
        {

            string jsonString = File.ReadAllText("hello.txt");

            var options = new JsonSerializerOptions();
            options.PropertyNameCaseInsensitive = true;

            var news = JsonSerializer.Deserialize<News>(jsonString,options);
            var superNews = news.Articles.Where(x => !string.IsNullOrWhiteSpace(x.Content) && x.Content.Contains("for")).ToList();
            for (int i = 0; i < superNews.Count; i++)
            {
                Console.WriteLine(i + " - " + superNews[i].Description);
            }
            Console.WriteLine("Select news to read");

            Console.WriteLine($"Go to {superNews[int.Parse(Console.ReadLine())].Url}");
            //1af83452c10b4aec85b15f2a92a003ed
        }
    }

    class News
    {
        public List<Article> Articles { get; set; }
    }

    class Article
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }

        public string urlToImage { get; set; }
    }
}
