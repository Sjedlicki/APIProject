using MovieAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Data;



namespace MovieAPI.Controllers
{

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MovieDB movie = MovieDAL.GetMovie();

            return View(movie);
        }

        public ActionResult ChoseMovies()
        {
            MovieDB movie = MovieDAL.GetMovie();

            return View(movie);
        }
    }
}