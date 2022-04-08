using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public abstract class MovieDatabase : IMovieDatabase
    {
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
            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                return "Movie must be unique.";

            // Add movie
            var newMovie = AddCore(movie);
            movie.Id = newMovie.Id;
            return "";
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

            if (!ObjectValidator.TryValidateObject(movie, out var errors))
                return "Movie is invalid";
            //var error = movie.Validate();
            //if (!String.IsNullOrEmpty(error))
            //    return error;

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                return "Movie must be unique.";

            //Make sure movie exists
            existing = GetCore(id);
            if (existing == null)
                return "Movie does not exist";

            // Updates movie
            UpdateCore(id, movie);
            return "";
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
        public string Delete ( int id )
        {
            if (id <= 0)
                return "ID must be > 0.";

            DeleteCore(id);
            return "";
        }

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The id of the movie to get.</param>
        /// <returns>A copy of the id's movie.</returns>
        public Movie Get ( int id )
        {
            if (id <= 0)
                return null;

            return GetCore(id);
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll ()
        {
            return GetAllCore();
        }

        #region Abstract members
        /// <summary>Adds a movie to the database</summary>
        /// <param name="movie">The movie to add</param>
        /// <returns>The added movie</returns>
        protected abstract Movie AddCore ( Movie movie );

        /// <summary>Finds a movie by its name.</summary>
        /// <param name="name">Name of the movie to find.</param>
        /// <returns>The movie with the name used.</returns>
        protected abstract Movie FindByName ( string name );

        /// <summary>Updates a movie to the database.</summary>
        /// <param name="id">The id of the movie to be updated.</param>
        /// <param name="movie">The movie to be updated.</param>
        protected abstract void UpdateCore ( int id, Movie movie );

        /// <summary>Deletes a movie from the database.</summary>
        /// <param name="id">The id of the movie to be deleted.</param>
        protected abstract void DeleteCore ( int id );

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The id of the movie to get.</param>
        /// <returns>The id's movie.</returns>
        protected abstract Movie GetCore ( int id );

        /// <summary>Gets all movies from the database.</summary>
        /// <returns>Movies from the database.</returns>
        protected abstract IEnumerable<Movie> GetAllCore ();
        #endregion
    }
}
