using System.Collections.Generic;

namespace MovieLib
{
    public interface IMovieDatabase
    {
        Movie Add ( Movie movie );
        void Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        void Update ( int id, Movie movie );
    }
}