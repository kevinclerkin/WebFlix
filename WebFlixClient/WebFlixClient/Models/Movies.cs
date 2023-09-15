using System;
using System.ComponentModel.DataAnnotations;

namespace WebFlix.Models
{
    public class Movies
    {



        [Required]
        [MinLength(4)]
        public string MovieID { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]

        public string Certification { get; set; }


        [Required]
        public string ReleaseDate { get; set; }

        [Required]
        [Range(1, 10)]
        public int AverageRating { get; set; }

        public override string ToString()
        {
            return $"MovieID: {MovieID} | Title: {Title}";
        }

    }
}

