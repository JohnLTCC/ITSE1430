using System;

namespace MovieLib
{
    // Class - wraps data and functionality
    // Naming: nouns, Pascal cased

    /// <summary> Represents a movie. </summary>
    public class Movie
    {
        //Fields - where data is stored

        public const int MinimumReleaseYear = 1900;
        public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

        /// <summary> Gets or sets the title of the movie. </summary>
        public string Title
        {
            //get { return !String.IsNullOrEmpty(_title) ? _title : ""; }
            //get { return (_title != null) ? _title : ""; }
            get { return _title ?? ""; } // null coalescing ::= E ?? E

            //set { _title = (value ?? "").Trim(); }
            set { _title = value?.Trim(); }
        }
        private string _title;

        /// <summary>
        /// gets or sets the duration in minutes
        /// </summary>
        public int Duration { get; set; }

        /// <summary>
        /// gets or sets the release year
        /// </summary>
        public int ReleaseYear { get; set; } = 1900;

        /// <summary>
        /// gets ors sets the rating
        /// </summary>
        public string Rating
        {
            get { return _rating ?? ""; }
            set { _rating = value; }
        }
        private string _rating;

        /// <summary>
        /// gets or sets the genre
        /// </summary>
        public string Genre
        {
            get { return _genre ?? ""; }
            set { _genre = value; }
        }
        private string _genre;

        /// <summary>
        /// gets or sets if movie is a classic
        /// </summary>
        public bool IsClassic { get; set; }

        /// <summary>
        /// gets or sets the description
        /// </summary>
        public string Description
        {
            get { return _description ?? ""; }
            set { _description = value; }
        }
        private string _description;

        //BW <= 1939
        //calculated property
        public bool IsBlackAndWhite 
        {
            get { return ReleaseYear <= 1939; }
        }
        //private bool _isBlackAndWhite;

        //private void CalculateBlackAndWhite()
        //{
        //    _isBlackAndWhite = ReleaseYear <= 1939;
        //}

        /// <summary>Validates the instance.</summary>
        /// <returns>Returns an error message if movie is invalide or empty string otherwise.</returns>
        public string Validate()
        {
            //Title is required
            if (String.IsNullOrEmpty(_title))
                return "Title is required";

            if (Duration < 0)
                return "Duration must be greater than 0";

            if (ReleaseYear < MinimumReleaseYear)
                return $"Release year must be greater than {MinimumReleaseYear}";

            if (String.IsNullOrEmpty(Rating))
                return "Rating is required";

            //Special rule - no classic movies before 1940
            if (IsClassic && ReleaseYear < 1940)
                return "Release year must be at least 1940 to be a classic";

            return "";
        }

        public int Id { get; private set; }
    }
}
