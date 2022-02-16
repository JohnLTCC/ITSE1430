using System;

namespace MovieLib
{
    // Class - wraps data and functionality
    // Naming: nouns, Pascal cased
    
    /// <summary> Represents a movie. </summary>
    public class Movie
    {
        //Fields - where data is stored

        /// <summary> Gets or sets the title of the movie. </summary>
        public string title;
        public int duration;
        public int releaseYear = 1900;
        public string rating;
        public string genre;
        public bool isColor;
        public string description;

        private int id;
    }
}
