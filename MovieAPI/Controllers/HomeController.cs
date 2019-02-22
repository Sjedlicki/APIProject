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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

		public List<JToken> GetTitles()
		{

			string url = "https://api.themoviedb.org/3/movie/550?api_key=452c4e31f03a234970a8f9e1c564a52f";

			HttpWebRequest Request = WebRequest.CreateHttp(url);

			//Request.Headers.Add("OAuth2", value);


			HttpWebResponse response = (HttpWebResponse)Request.GetResponse();

			//Getting the data from a response 
			StreamReader sr = new StreamReader(response.GetResponseStream());

			string APIText = sr.ReadToEnd();
			sr.Close();
			//Now we're moving into parsing
			//JToken parses the JSon info into C# natural language.
			JToken titleData = JToken.Parse(APIText);

			//Making a string that goes into the website 
			//and looks for the name of the field in the API
			List<JToken> titles = titleData["data"]["children"].ToList();

			return titles;
		}
}