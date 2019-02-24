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
    public class FavoritesDBController : Controller
    {
        private FavoriteDBContext db = new FavoriteDBContext();

        // GET: FavoritesDB
        public ActionResult Index()
        {
            return View(db.Favorites.ToList());
        }

        // GET: FavoritesDB/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoritesDB favoritesDB = db.Favorites.Find(id);
            if (favoritesDB == null)
            {
                return HttpNotFound();
            }
            return View(favoritesDB);
        }

        // GET: FavoritesDB/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FavoritesDB/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Title,Year,ImdbID,Poster,Genre,Metascore,Plot")] FavoritesDB favoritesDB)
        {
            if (ModelState.IsValid)
            {
                db.Favorites.Add(favoritesDB);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(favoritesDB);
        }

        // GET: FavoritesDB/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoritesDB favoritesDB = db.Favorites.Find(id);
            if (favoritesDB == null)
            {
                return HttpNotFound();
            }
            return View(favoritesDB);
        }

        // POST: FavoritesDB/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Title,Year,ImdbID,Poster,Genre,Metascore,Plot")] FavoritesDB favoritesDB)
        {
            if (ModelState.IsValid)
            {
                db.Entry(favoritesDB).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(favoritesDB);
        }

        // GET: FavoritesDB/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FavoritesDB favoritesDB = db.Favorites.Find(id);
            if (favoritesDB == null)
            {
                return HttpNotFound();
            }
            return View(favoritesDB);
        }

        // POST: FavoritesDB/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FavoritesDB favoritesDB = db.Favorites.Find(id);
            db.Favorites.Remove(favoritesDB);
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
