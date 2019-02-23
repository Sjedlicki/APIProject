using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace MovieAPI.Models
{
    public class MovieDB
    {
        //[Key]
        //public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string Genre { get; set; }
        public string Metascore { get; set; }
        

        public MovieDB(string APIText)
        {
            var movieJson = JObject.Parse(APIText).ToString();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            MovieDB mov = new MovieDB();

            mov = oJS.Deserialize<MovieDB>(movieJson);

            Title = mov.Title;
            Year = mov.Year;
            Genre = mov.Genre;
            Metascore = mov.Metascore;
        }

        public MovieDB() { }
    }
}