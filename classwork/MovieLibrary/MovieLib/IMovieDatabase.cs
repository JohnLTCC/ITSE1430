using System.Collections.Generic;

namespace MovieLib
{
    public interface IMovieDatabase
    {
        string Add ( Movie movie );
        string Delete ( int id );
        Movie Get ( int id );
        IEnumerable<Movie> GetAll ();
        string Update ( int id, Movie movie );
    }
}