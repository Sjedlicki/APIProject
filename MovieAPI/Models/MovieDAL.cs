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

            return data;
        }

        public static MovieDB GetStuffed(int i)
        {
            string output = GetData("http://www.omdbapi.com/?i=tt3896198&apikey=e3c05793");
            MovieDB movie = new MovieDB(output, i);
            return movie;
        }
    }
}