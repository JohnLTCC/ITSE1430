using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib
{
    // Class - wraps data and functionality
    // Naming: nouns, Pascal cased

    /// <summary> Represents a movie. </summary>
    public class Movie //: IValidatableObject
    {
        public const int MinimumReleaseYear = 1900;

        /// <summary> Gets or sets the title of the movie. </summary>
        // If there are no parameters you don't need parantheses
        //[RequiredAttribute()]
        //[RequiredAttribute]
        [Required(AllowEmptyStrings = false)]
        public string Title
        {
            get => _title ?? "";
            set => _title = value?.Trim();
        }
        private string _title;

        /// <summary>
        /// gets or sets the duration in minutes
        /// </summary>
        [Range(0, Int32.MaxValue)]
        public int Duration { get; set; }

        /// <summary>
        /// gets or sets the release year
        /// </summary>
        [Range(MinimumReleaseYear, 2100)]
        public int ReleaseYear { get; set; } = MinimumReleaseYear;

        /// <summary>
        /// gets ors sets the rating
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Rating
        {
            get => _rating ?? ""; 
            set => _rating = value; 
        }
        private string _rating;

        /// <summary>
        /// gets or sets the genre
        /// </summary>
        [Required(AllowEmptyStrings = false)]
        public string Genre
        {
            get => _genre ?? "";
            set => _genre = value;
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
            get => _description ?? "";
            set => _description = value;
        }
        private string _description;

        //BW <= 1939
        //calculated property
        [Obsolete("Do not use")]
        public bool IsBlackAndWhite => ReleaseYear <= 1939;

        /// <summary>
        /// gets or sets the ID of the movie
        /// </summary>
        public int Id { get; set; }

        public Movie Copy () => new Movie() {
            Id = Id,
            Title = Title,
            Description = Description,
            Duration = Duration,
            ReleaseYear = ReleaseYear,
            Genre = Genre,
            Rating = Rating,
            IsClassic = IsClassic
        };
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

        //Expression body
        public override string ToString () => $"{Title} ({ReleaseYear})";

        //public IEnumerable<ValidationResult> Validate ( ValidationContext validationContext )
        //{
        //    ////Title is required
        //    //if (String.IsNullOrEmpty(_title))
        //    //    yield return new ValidationResult("Title is required", new[] { nameof(Title) });

        //    //if (Duration < 0)
        //    //    yield return new ValidationResult("Duration must be greater than 0", new[] { nameof(Duration) });

        //    //if (ReleaseYear < MinimumReleaseYear)
        //    //    yield return new ValidationResult($"Release year must be greater than {MinimumReleaseYear}",  new[] { nameof(ReleaseYear) });

        //    //if (String.IsNullOrEmpty(Rating))
        //    //    yield return new ValidationResult("Rating is required", new[] { nameof(Rating) });

        //    //if (String.Equals(_title, "Error", StringComparison.OrdinalIgnoreCase))
        //    //    yield return new ValidationResult("Title cannot be 'error'", new[] { nameof(Title) });
        //}

        private void ShouldNotUse()
        {
            var isSet = IsBlackAndWhite;
        }
    }
}
