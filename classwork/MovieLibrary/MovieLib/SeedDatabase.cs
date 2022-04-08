using System;

using MovieLib.Memory;

namespace MovieLib
{
    //Static classes contain only static members
    // Static members do not require an instance
    // Static members must be called using type name
    // Static members can only refer to other static members

    // Extention methods
    //  In a static public/internal class
    //  Must be a static method
    //  First parameter must be preceded by this

    /// <summary>
    /// Seeds a movie database
    /// </summary>
    public static class SeedDatabase
    {
        public static void Seed ( this IMovieDatabase database )
        {
            database.Add(new Movie() {
                Title = "The Lego Movie",
                Genre = "Comedy",
                ReleaseYear = 2014,
                Duration = 100,
                Rating = "PG",
                IsClassic = true
            });

            database.Add(new Movie() {
                Title = "Monster House",
                Genre = "Horror",
                ReleaseYear = 2006,
                Duration = 91,
                Rating = "PG",
                IsClassic = false
            });

            database.Add(new Movie() {
                Title = "Dune",
                Genre = "Sci-fi",
                ReleaseYear = 2021,
                Duration = 155,
                Rating = "PG-13",
                IsClassic = false
            });

            database.Add(new Movie() {
                Title = "Elf",
                Genre = "Comedy",
                ReleaseYear = 2003,
                Duration = 97,
                Rating = "PG",
                IsClassic = true
            });
        }
    }
}
