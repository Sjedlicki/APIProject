using MovieAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieAPI.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MovieDB movie = new MovieDAL.GetStuffed(0);

            return View(movie);
        }

        //public ActionResult Display()
        //{
        //    List<JToken> display = MovieInfo();

        //    ViewBag.Info = display;
        //    return View();
        //}
    }
}