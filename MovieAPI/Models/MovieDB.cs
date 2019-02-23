using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public class MovieDB
    {
        //[Key]
        //public int ID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Rating { get; set; }
        public string ReleaseDate { get; set; }

        public MovieDB(string APIText, string i)
        {
            JObject movieJson = JObject.Parse(APIText);

            List<JToken> movies = movieJson["paths"].ToList();

            JToken movie = movies[0];

            Title = movie["title"].ToString();
        }

        public MovieDB() { }
    }
}