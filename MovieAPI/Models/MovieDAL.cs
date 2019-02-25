using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using Newtonsoft.Json.Linq;

namespace MovieAPI.Models
{
    public class MovieDAL
    {

        public static string GetData(string url)
        {
            HttpWebRequest request = WebRequest.CreateHttp(url);
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();

            StreamReader rd = new StreamReader(response.GetResponseStream());
            string data = rd.ReadToEnd();
            rd.Close();

            return data;
        }

        public static List<MovieDB> SearchByTitle(string title)
        {
            List<MovieDB> results = new List<MovieDB>();

            string apikey = "&apikey=e3c05793";
            string output = GetData($"http://www.omdbapi.com/?s={title}{apikey}");
            var token = JToken.Parse(output);
            var list = token.SelectToken("Search");
            foreach (var item in list)
            {
                MovieDB movie = new MovieDB(item.ToString());
                results.Add(movie);
            }
            return results;
        }

        public static MovieDB GetMovie(string imdbID)
        {
            string apikey = "&apikey=e3c05793";

            string movieName = imdbID;

            string output = GetData($"http://www.omdbapi.com/?i={movieName}{apikey}");
            MovieDB movie = new MovieDB(output);
            return movie;
        }
    }
}