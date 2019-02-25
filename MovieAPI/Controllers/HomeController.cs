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
            var model = new MovieModel();
            model.Movies = new List<MovieDB>();
            return View(model);
        }

        public ActionResult Search(MovieModel model)
        {
            model.Movies = MovieDAL.SearchByTitle(model.Title);

            return View("Index", model);
        }
    }
}