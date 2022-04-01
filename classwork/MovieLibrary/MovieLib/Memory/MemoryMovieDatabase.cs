using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib.Memory
{
    public class MemoryMovieDatabase
    {
        private readonly List<Movie> _movies = new List<Movie>();

        public string Add ( Movie movie )
        {
            // Validation
            if (movie == null)
                return "Movie cannot be null.";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return "Movie is invalid.";

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

        public string Update ( int id, Movie movie )
        {
            // Validation
            if (id <= 0)
                return "ID must be greater than or equal to 0.";
            if (movie == null)
                return "Movie cannot be null.";
            var error = movie.Validate();
            if (!String.IsNullOrEmpty(error))
                return error;

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
                if(item.Id == id)
                {
                    _movies.Remove(item);
                    return;
                }
            }
        }
        public Movie Get ( int id)
        {
            return FindById(id)?.Copy();
        }
        public Movie[] GetAll ()
        {
            // Need to clone movies
            var items = new Movie[_movies.Count];
            var index = 0;
            foreach (var movie in _movies)
                items[index++] = movie.Copy();

            return items;
        }

        //Simple identifier system
        private int _id = 1;
    }
}
