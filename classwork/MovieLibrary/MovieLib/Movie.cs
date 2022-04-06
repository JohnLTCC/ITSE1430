using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib
{
    // Class - wraps data and functionality
    // Naming: nouns, Pascal cased

    /// <summary> Represents a movie. </summary>
    public class Movie : IValidatableObject
    {
        //Fields - where data is stored

        public const int MinimumReleaseYear = 1900;
        //public readonly DateTime MinimumReleaseDate = new DateTime(1900, 1, 1);

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

        public int Id { get; set; }

        public Movie Copy ()
        {
            /* Object initializer syntax
            *var item = new Movie();
            *item.Id = Id;
            *item.Title = Title;
            *item.Description = Description;
            *item.Duration = Duration;
            *item.ReleaseYear = ReleaseYear;
            *item.Genre = Genre;
            *item.Rating = Rating;
            *item.IsClassic = IsClassic;
            */

            //return item;

            // Object initializer syntax
            // Only works with new
            /* 1. Remove smicolon ad curlies
             * 2. Indent for readablity
             * 3. Replace semicolon with comas
             * 4. Removce instance name
             */
            return new Movie() {
                Id = Id,
                Title = Title,
                Description = Description,
                Duration = Duration,
                ReleaseYear = ReleaseYear,
                Genre = Genre,
                Rating = Rating,
                IsClassic = IsClassic
            };
        }

        public void CopyFrom(Movie source)
        {
            Title = source.Title;
            Description = source.Description;
            Duration = source.Duration;
            ReleaseYear = source.ReleaseYear;
            Genre = source.Genre;
            Rating = source.Rating;
            IsClassic = source.IsClassic;
        }

        public override string ToString ()
        {
            return $"{Title} ({ReleaseYear})";
        }

        public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        {
            //Title is required
            if (String.IsNullOrEmpty(_title))
                yield return new ValidationResult("Title is required", new[] { nameof(Title) });

            if (Duration < 0)
                yield return new ValidationResult("Duration must be greater than 0", new[] { nameof(Duration) });

            if (ReleaseYear < MinimumReleaseYear)
                yield return new ValidationResult($"Release year must be greater than {MinimumReleaseYear}",  new[] { nameof(ReleaseYear) });

            if (String.IsNullOrEmpty(Rating))
                yield return new ValidationResult("Rating is required", new[] { nameof(Rating) });
        }
    }
}
