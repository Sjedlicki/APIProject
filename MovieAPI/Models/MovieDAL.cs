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

            //PASS USER INPUT DATA HERE!!
            string movieName = "american psycho".Trim();

            string output = GetData($"http://www.omdbapi.com/?t={movieName}{apikey}");
            MovieDB movie = new MovieDB(output);
            return movie;
        }
    }
}