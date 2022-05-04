﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MovieLib.WebApp.Models
{
    public class MovieViewModel
    {
        public MovieViewModel ()
        { }

        public MovieViewModel(Movie movie)
        {
            Id = movie.Id;
            Title = movie.Title;
            Duration = movie.Duration;
            ReleaseYear = movie.ReleaseYear;
            Rating = movie.Rating;
            Genre = movie.Genre;
            Description = movie.Description;
            IsClassic = movie.IsClassic;
        }
        [Required(AllowEmptyStrings = false)]
        public string Title { get; set; }
       
        [Range(0, Int32.MaxValue)]
        public int Duration { get; set; }
        
        [Range(Movie.MinimumReleaseYear, 2100)]
        public int ReleaseYear { get; set; } = Movie.MinimumReleaseYear;
        
        [Required(AllowEmptyStrings = false)]
        public string Rating { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        public string Genre { get; set; }
        
        public bool IsClassic { get; set; }
        
        public string Description { get; set; }
        
        public int Id { get; set; }
    }
}
