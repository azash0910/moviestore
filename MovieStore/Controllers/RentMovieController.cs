using MovieStore.Context;
using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class RentMovieController : Controller
    {
        MovieContext db = new MovieContext();

        // GET: RentMovie
        public ActionResult Index()
        {
            var rentmovies = (from rent in db.RentMovies
                          join movie in db.Movies
                          on rent.MovieId equals movie.Id
                          join customer in db.Customers
                          on rent.CustomerId equals customer.Id

                          select new RentMovieViewModel
                          {
                              Id = rent.Id,
                              MovieId = rent.MovieId,
                              CustomerId = rent.CustomerId,
                              RentDate = rent.RentDate,
                              MovieName = movie.Titel,
                              CustomerName = customer.Firstname + " " + customer.Lastname,
                              Status = rent.Status
                          });

            return View(rentmovies);
        }

        // GET: RentMovie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            RentMovieModel rentmovie = db.RentMovies.Find(id);

            var rentMovies = from s in db.RentMovies
                             where s.Id.Equals(id)
                             select s;

            if (rentmovie == null)
            {
                return HttpNotFound();
            }
            return View(rentmovie);
        }

        // GET: RentMovie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RentMovie/Create
        [HttpPost]
        public ActionResult Create(RentMovieModel rentmovie)
        {
            try
            {
                db.RentMovies.Add(rentmovie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentMovie/Edit/5
        public ActionResult Edit(int id)
        {
            RentMovieModel rentmovie = db.RentMovies.Find(id);
            if (rentmovie == null)
            {
                return HttpNotFound();
            }
            return View(rentmovie);
        }

        // POST: RentMovie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, RentMovieModel rentmovie)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(rentmovie).State = EntityState.Modified;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RentMovie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RentMovieModel rentmovie = db.RentMovies.Find(id);

            if (rentmovie == null)
            {
                return HttpNotFound();
            }
            return View(rentmovie);
        }

        // POST: RentMovie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                RentMovieModel rentmovie = db.RentMovies.Find(id);
                db.RentMovies.Remove(rentmovie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
