using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using MovieLib.WebApp.Models;

namespace MovieLib.WebApp.Controllers
{
    //URL: <Controller>/<Action>

    // Controllers must be globally unique
    // Must derive from controller
    // Must be public
    // Must be creatable
    public class MoviesController : Controller // Everything before the Controller portion of the name counts as the URL
    {
        public MoviesController ( IMovieDatabase database )
        {
            _database = database;
        }
        // formally known as an action
        // must be public
        // must return IActionResult or derived type
        [HttpGet]
        public IActionResult Index ()
        {
            var movies = _database.GetAll();
            var models = movies.Select(x => new MovieViewModel(x));

            return View(models); //"Index.cshtml"
            //return View("Index.cshtml", <model>)
        }
        // movies/edit/{id}
        [HttpGet]
        public IActionResult Edit (int id)
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public IActionResult Edit ( MovieViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.toMovie();

                _database.Update(model.Id, newMovie);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create ()
        {
            var model = new MovieViewModel();
            return View(model);
        }

        [HttpPost]
        public IActionResult Create ( MovieViewModel model )
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var newMovie = model.toMovie();

                _database.Add(newMovie);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Delete ( int id )
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        [HttpPost]
        public IActionResult Delete ( MovieViewModel model )
        {
            try
            {
                _database.Delete(model.Id);

                return RedirectToAction("Index");
            } catch (Exception e)
            {
                ModelState.AddModelError("", e.Message);
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Details ( int id )
        {
            var movie = _database.Get(id);

            if (movie == null)
                return NotFound();

            var model = new MovieViewModel(movie);
            return View(model);
        }

        private readonly IMovieDatabase _database;
    }
}
