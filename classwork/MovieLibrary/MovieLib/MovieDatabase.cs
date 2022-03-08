using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieLib
{
    public class MovieDatabase
    {
        public MovieDatabase () : this("My Movies")
        {

        }

        public MovieDatabase( string name )
        {
            Name = name;
        }
        public string Name { get; set; }

        public virtual void Add ( Movie movie )
        {

        }
        public Movie Find( string name )
        {
            return null;
        }
        public void Delete( Movie movie )
        {

        }
        public void Update( Movie movie )
        {

        }
        public Movie Get()
        {
            return null;
        }
    }

    public class MemoryMovieDatabase : MovieDatabase
    {
        public override void Add ( Movie movie )
        {
            base.Add(movie);
        }
    }
}
