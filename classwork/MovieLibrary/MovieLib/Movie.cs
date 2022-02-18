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
        public string Title
        {
            get { return _title; }
            set { _title = value; }
        }
        private string _title;

        public int _duration;
        public int _releaseYear = 1900;
        public string _rating;
        public string _genre;
        public bool _isClassic;
        public string _description;

        //BW <= 1939
        public bool IsBlackAndWhite 
        {
            get { return _isBlackAndWhite; }
            set { }
        }
        private bool _isBlackAndWhite;

        public void CalculateBlackAndWhite()
        {
            _isBlackAndWhite = _releaseYear <= 1939;
        }

        /// <summary>Validates the instance.</summary>
        /// <returns>Returns an error message if movie is invalide or empty string otherwise.</returns>
        public string Validate()
        {
            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            if (_duration < 0)
                return "Duration must be greater than 0";

            if (_releaseYear < 1900)
                return "Release year must be greater than 1900";

            if (String.IsNullOrEmpty(_rating))
                return "Rating is required";

            //Special rule - no classic movies before 1940
            if (_isClassic && _releaseYear < 1940)
                return "Release year must be at least 1940 to be a classic";

            return "";
        }
        private int id;
    }
}
