using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Data.Entity;

namespace MovieAPI.Models
{
    public class MovieDB
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Year { get; set; }
        public string ImdbID { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Metascore { get; set; }
        public string Plot { get; set; }

        public MovieDB(string APIText)
        {
            var movieJson = JObject.Parse(APIText).ToString();

            JavaScriptSerializer oJS = new JavaScriptSerializer();
            MovieDB mov = new MovieDB();

            mov = oJS.Deserialize<MovieDB>(movieJson);

            Title = mov.Title;
            Year = mov.Year;
            ImdbID = mov.ImdbID;
            Poster = mov.Poster;
            Genre = mov.Genre;
            Metascore = mov.Metascore;
            Plot = mov.Plot;
        }

        public MovieDB() { }
    }

    public class FavoriteDBContext : DbContext
    {
        public DbSet<MovieDB> Favorite { get; set; }
    }
}