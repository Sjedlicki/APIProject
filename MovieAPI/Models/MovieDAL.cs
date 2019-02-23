using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;

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

        public static MovieDB GetMovie()
        {
            string apikey = "&apikey=e3c05793";
            string movieName = "tt0144084";

            string output = GetData($"http://www.omdbapi.com/?i={movieName}{apikey}");
            MovieDB movie = new MovieDB(output);
            return movie;
        }
    }
}