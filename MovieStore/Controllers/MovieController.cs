using MovieStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MovieStore.Controllers
{
    public class MovieController : Controller
    {
        // GET: Movie
        public ActionResult Index()
        {
            List<MovieModel> movie = new List<MovieModel>();
            movie.Add(new MovieModel { Titel = "Terminator", Genre = "Action", Description = "bla bla", Length = 120 });
            movie.Add(new MovieModel { Titel = "Terminator 2", Genre = "Action", Description = "bla bla", Length = 120 });
            movie.Add(new MovieModel { Titel = "Terminator 3", Genre = "Action", Description = "bla bla", Length = 120 });
            movie.Add(new MovieModel { Titel = "Terminator 4", Genre = "Action", Description = "bla bla", Length = 120 });
            movie.Add(new MovieModel { Titel = "Terminator 5", Genre = "Action", Description = "bla bla", Length = 120 });

            return View(movie);
        }


    }
}