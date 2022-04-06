using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase : IMovieDatabase
    {
        private readonly List<Movie> _movies = new List<Movie>();

        /// <summary>Adds a movie to the database.</summary>
        /// <param name="movie">The movie to add.</param>
        /// <returns>The error message, if any.</returns>
        /// <remarks>
        /// Errors occur if:
        /// <paramref name="movie"/> is null.
        /// <paramref name="movie"/> is not valid.
        /// A movie with the same title already exists.
        /// </remarks>
        public string Add ( Movie movie )
        {
            // Validation
            if (movie == null)
                return "Movie cannot be null.";

            //TODO: Fix Validation message
            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return "Movie is invalid.";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique.";

            // Add movie
            movie.Id = _id++;
            _movies.Add(movie.Copy()); ;
            return "";
        }

        private Movie FindByName ( string name )
        {
            // Foreach rules
            // 1. loop variant is readonly
            // 2. Array cannot change
            foreach (var movie in _movies)
                if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
                    return movie;

            return null;
        }

        private Movie FindById ( int id )
        {
            // Find by movie.Id
            foreach (var item in _movies)
            {
                if (item.Id == id)
                    return item;
            }
            return null;
        }

        /// <summary>
        /// Updates an existing movie in the database.
        /// </summary>
        /// <param name="id"> The id of the movie to be updated.</param>
        /// <param name="movie"> The updated movie.</param>
        /// <returns>The error message, if any.</returns>
        /// <remarks>
        /// Errors occur if:
        /// <paramref name="id"/> is less than or equal to zero.
        /// <paramref name="movie"/> is null.
        /// <paramref name="movie"/> it not valid.
        /// A movie with the same title already exists
        /// The movie cannot be found
        /// </remarks>
        public string Update ( int id, Movie movie )
        {
            // Validation
            if (id <= 0)
                return "ID must be greater than or equal to 0.";
            if (movie == null)
                return "Movie cannot be null.";

            if (!new ObjectValidator().TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique.";

            //Make sure movie exists
            existing = FindById(id);
            if (existing == null)
                return "Movie does not exist";

            // Updates movie
            existing.CopyFrom(movie);
            return "";
        }

        public void Delete ( int id )
        {
            // Find by movie.Id
            foreach (var item in _movies)
            {
                if (item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                }
            }
        }

        public Movie Get ( int id )
        {
            return FindById(id)?.Copy();
        }

        /*Iterators = implementation of IEnumerable<T>
        *
        */

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            // Need to clone movies
            //var items = new Movie[_movies.Count];
            //var index = 0;
            foreach (var movie in _movies)
            {
                //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
                yield return movie.Copy();
            }
            //items[index++] = movie.Copy();

        }

        //Simple identifier system
        private int _id = 1;

        //Not visible by interface
        public void foo () { }
    }
}
