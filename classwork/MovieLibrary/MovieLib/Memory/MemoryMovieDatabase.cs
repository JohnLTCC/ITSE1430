using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase : MovieDatabase
    {
        private readonly List<Movie> _movies = new List<Movie>();

        protected override Movie AddCore ( Movie movie )
        {
            movie.Id = _id++;
            _movies.Add(movie.Copy()); ;
            return movie;
        }

        /// <summary>Finds a movie by its name.</summary>
        /// <param name="name">Name of the movie to find.</param>
        /// <returns>The movie with the name used.</returns>
        protected override Movie FindByName ( string name )
        {
            // Foreach rules
            // 1. loop variant is readonly
            // 2. Array cannot change
            //Approach 1
            //foreach (var movie in _movies)
            //    if (String.Equals(movie.Title, name, StringComparison.CurrentCultureIgnoreCase))
            //        return movie;
            //return null;

            //approach 2
            //return _movies.FirstOrDefault(x => String.Equals(x.Title,name, StringComparison.CurrentCultureIgnoreCase));

            //Approach 3
            return (from m in _movies
                   where String.Equals(m.Title, name, StringComparison.CurrentCultureIgnoreCase)
                   select m).FirstOrDefault();
        }

        /// <summary>Finds a movie by its id.</summary>
        /// <param name="id">Id for the movie to find.</param>
        /// <returns>The movie matching the id.</returns>
        private Movie FindById ( int id )
        {
            //LINQ:
            //var movie = _movies.Where(IsMatchingId)
            //var movie = _movies.Where(item => item.Id == id)
            //                   .FirstOrDefault();
            //return movie;

            return _movies.FirstOrDefault(x => x.Id == id);
        }

        //Func<Movie, bool>
        //private bool IsMatchingId (Movie movie)
        //{
        //    return false;
        //}

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
        protected override void UpdateCore ( int id, Movie movie )
        {
            //Update
            var existing = FindById(id);
            existing.CopyFrom(movie);
        }

        /// <summary>Deletes a movie.</summary>
        /// <param name="id">The ID of the movie to delete.</param>
        protected override void DeleteCore ( int id )
        {
            var movie = _movies.FirstOrDefault(x => x.Id == id);
            if (movie != null)
                _movies.Remove(movie);
            //foreach (var item in _movies)
            //{
            //    if (item.Id == id)
            //    {
            //        _movies.Remove(item);
            //        return;
            //    }
            //}
        }

        /// <summary>Gets a movie from the database.</summary>
        /// <param name="id">The id of the movie to get.</param>
        /// <returns>Returns a copy of the id's movie.</returns>
        protected override Movie GetCore ( int id )
        {
            return FindById(id)?.Copy();
        }

        /*Iterators = implementation of IEnumerable<T>
        *
        */

        /// <summary>Gets all the movies.</summary>
        /// <returns>The movies in the database.</returns>
        protected override IEnumerable<Movie> GetAllCore ()
        {
            // Need to clone movies
            //var items = new Movie[_movies.Count];
            //var index = 0;

            //Approach 1
            //foreach (var movie in _movies)
            //{
            //    //System.Diagnostics.Debug.WriteLine($"Returning {movie.Title}");
            //    yield return movie.Copy();
            //}

            //Approach 2
            return _movies.Select(x => x.Copy());

        }

        //Simple identifier system
        private int _id = 1;
    }
}
