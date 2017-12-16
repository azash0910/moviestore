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
    public class MovieController : Controller
    {
        MovieContext db = new MovieContext();

        // GET: Movie
        public ActionResult Index(string sort)
        {

            var movies = from s in db.Movies
                         select s;

            try
            {
                ViewBag.Order = sort.Split('_')[1];
            } catch
            {
                ViewBag.Order = "desc";
            }
            
            switch (sort)
            {
                case "title_desc":
                    movies = movies.OrderByDescending(s => s.Titel);
                    break;
                case "title_asc":
                    movies = movies.OrderBy(s => s.Titel);
                    break;
                case "length_desc":
                    movies = movies.OrderByDescending(s => s.Length);
                    break;
                case "length_asc":
                    movies = movies.OrderBy(s => s.Length);
                    break;
                case "genre_desc":
                    movies = movies.OrderByDescending(s => s.Genre);
                    break;
                case "genre_asc":
                    movies = movies.OrderBy(s => s.Genre);
                    break;
                case "year_desc":
                    movies = movies.OrderByDescending(s => s.Year);
                    break;
                case "year_asc":
                    movies = movies.OrderBy(s => s.Year);
                    break;
                default:
                    movies = movies.OrderBy(s => s.Titel);
                    break;
            }
            
            return View(movies.ToList());
        }

        // GET: Movie/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            MovieModel movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // GET: Movie/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Movie/Create
        [HttpPost]
        public ActionResult Create(MovieModel movie)
        {
            try
            {
                db.Movies.Add(movie);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Edit/5
        public ActionResult Edit(int id)
        {
            MovieModel movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, MovieModel movie)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    db.Entry(movie).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Movie/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MovieModel movie = db.Movies.Find(id);

            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        // POST: Movie/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                MovieModel movie = db.Movies.Find(id);
                db.Movies.Remove(movie);
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
