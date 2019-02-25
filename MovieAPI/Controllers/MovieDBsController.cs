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

        // GET: MovieDBs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Favorite.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // GET: MovieDBs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieDBs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Year,Poster,Genre,Metascore,Plot")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Favorite.Add(movieDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieDB);
        }

        public ActionResult Favorites(string imdbID)
        {
            MovieDB movie = MovieDAL.GetMovie(imdbID);
            db.Favorite.Add(movie);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: MovieDBs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Favorite.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // POST: MovieDBs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,Poster,Genre,Metascore,Plot")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieDB);
        }

        // GET: MovieDBs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieDB movieDB = db.Favorite.Find(id);
            if (movieDB == null)
            {
                return HttpNotFound();
            }
            return View(movieDB);
        }

        // POST: MovieDBs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
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
