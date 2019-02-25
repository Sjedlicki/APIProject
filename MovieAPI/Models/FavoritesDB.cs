using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public class FavoritesDB
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public int Year { get; set; }
        public string ImdbID { get; set; }
        public string Poster { get; set; }
        public string Genre { get; set; }
        public string Metascore { get; set; }
        public string Plot { get; set; }
    }

    public class FavoriteDBContext : DbContext
    {
        public DbSet<FavoritesDB> Favorites { get; set; }
    }
}