using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MovieAPI.Models;

namespace MovieAPI.Controllers
{
    public class MovieDBsController : Controller
    {
        private FavoriteDBContext db = new FavoriteDBContext();

        // GET: MovieDBs
        public ActionResult Index()
        {
            return View(db.Favorite.ToList());
        }

        public ActionResult Favorites(string imdbID)
        {
            MovieDB movie = MovieDAL.GetMovie(imdbID);
            db.Favorite.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult GetOneMovie(string imdbID)
        {
            MovieDB movie = MovieDAL.GetMovie(imdbID);
            ViewBag.Title = movie.Title;
            ViewBag.Meta = movie.Metascore;
            ViewBag.Plot = movie.Plot;
            ViewBag.Poster = movie.Poster;
            ViewBag.Year = movie.Year;
            ViewBag.Genre = movie.Genre;
            ViewBag.IMDB = movie.ImdbID;

            return View("OneMovie");
        }

        public ActionResult DeleteAll()
        {
            foreach (MovieDB movieDB in db.Favorite)
            {
                db.Favorite.Remove(movieDB);
            }
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteConfirm(int id)
        {
            MovieDB movieDB = db.Favorite.Find(id);
            db.Favorite.Remove(movieDB);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }		
    }
}