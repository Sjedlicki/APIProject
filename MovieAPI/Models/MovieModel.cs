using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieAPI.Models
{
    public class MovieModel
    {
        public List<MovieDB> Movies { get; set; }

        public string Title { get; set; }
    }
}