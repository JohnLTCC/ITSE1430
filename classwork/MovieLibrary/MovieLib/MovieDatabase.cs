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
        public Movie Add ( Movie movie )
        {
            //Raise an error using throw - only works with exceptions
            // Validation
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));
            //movie = movie ?? throw new ArgumentNullException(nameof(movie));

            ObjectValidator.ValidateObject(movie);
            //if (!ObjectValidator.TryValidateObject(movie, out var errors))
            //    return "Movie is invalid";

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null)
                //throw new ArgumentException("Movie must be unique", nameof(movie));
            throw new InvalidOperationException("Movie must be unique");

            // Add movie
            try
            {
                var newMovie = AddCore(movie);
                return newMovie;
            } catch (InvalidOperationException)
            {
                //Pass through
                // NEVER DO THIS -> throw e;
                throw;
            } catch (Exception e)
            {
                //Wrap it in a generic exception
                throw new Exception("Error adding movie", e);
            };
            //movie.Id = newMovie.Id;
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
        public void Update ( int id, Movie movie )
        {
            // Validation
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");
            if (movie == null)
                throw new ArgumentNullException(nameof(movie));

            ObjectValidator.ValidateObject(movie);

            //Title must be unique
            var existing = FindByName(movie.Title);
            if (existing != null && existing.Id != id)
                throw new ArgumentException("Movie must be unique", nameof(movie));

            //Make sure movie exists
            existing = GetCore(id);
            if (existing == null)
                throw new ArgumentNullException(nameof(movie));

            // Updates movie
            UpdateCore(id, movie);
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
        public void Delete ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            DeleteCore(id);
        }

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The id of the movie to get.</param>
        /// <returns>A copy of the id's movie.</returns>
        public Movie Get ( int id )
        {
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than 0");

            return GetCore(id);
        }

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        public IEnumerable<Movie> GetAll () => GetAllCore();

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
