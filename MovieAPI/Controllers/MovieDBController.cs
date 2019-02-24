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
    public class MovieDBController : Controller
    {
        private FavoriteDBContext db = new FavoriteDBContext();

        // GET: MovieDB
        public ActionResult Index()
        {
            return View(db.Favorite.ToList());
        }

        // GET: MovieDB/Details/5
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

        // GET: MovieDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MovieDB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Year,ImdbID,Poster,Genre,Metascore,Plot")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Favorite.Add(movieDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(movieDB);
        }

        // GET: MovieDB/Edit/5
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

        // POST: MovieDB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,ImdbID,Poster,Genre,Metascore,Plot")] MovieDB movieDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movieDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movieDB);
        }

        // GET: MovieDB/Delete/5
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

        // POST: MovieDB/Delete/5
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
