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
			if (model.Title == null)
			{
				ViewBag.Error = "No title, try again!";
				return View("Error");
			}
			
			else
			{
				model.Movies = MovieDAL.SearchByTitle(model.Title);
				if (model.Movies.Count != 0)
				{
					return View("Index", model);
				}
				else
				{
					ViewBag.Error = "That's just a buncha fuckin jibberish";
					return View("Error");
				}

				}
			}

		public ActionResult Error()
		{
			ViewBag.Error = "Please input a title!";
			return View();
		}
    }
}