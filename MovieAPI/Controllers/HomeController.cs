using MovieAPI.Models;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json.Linq;

namespace MovieAPI.Controllers
{
<<<<<<< HEAD
	public class HomeController : Controller
	{
		public ActionResult Index()
		{

			return View();
		}

		public List<JToken> MovieInfo()
		{

			string url = " http://www.omdbapi.com/?i=tt3896198&apikey=e3c05793";

			HttpWebRequest Request = WebRequest.CreateHttp(url);

			//Request.Headers.Add("OAuth2", value);


			HttpWebResponse response = (HttpWebResponse)Request.GetResponse();

			//Getting the data from a response 
			StreamReader sr = new StreamReader(response.GetResponseStream());

			string APIText = sr.ReadToEnd();
			sr.Close();
			//Now we're moving into parsing
			//JToken parses the JSon info into C# natural language.
			JToken MoviesData = JToken.Parse(APIText);

			//Making a string that goes into the website 
			//and looks for the name of the field in the API
			List<JToken> AllInfo = MoviesData["p"]["exports"].ToList();

			return AllInfo;
		}
	}
=======
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
>>>>>>> 1a4f639fc45fc0b8b6eb79e729eb8e9bb9f98966
}