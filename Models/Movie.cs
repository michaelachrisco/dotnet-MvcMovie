using System;
using System.ComponentModel.DataAnnotations;

using MvcMovie.CustomAttributes;

namespace MvcMovie.Models
{
    public class Movie : ClassicMovieAttribute
    {
        public int ID { get; set; }
        [Required]
        [StringLength(100)]
        public string Title { get; set; }
        [DisplayFormatAttribute(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DisplayAttribute(Name = "Classic")]
        [ClassicMovie(1960)]
        public DateTime ReleaseDate { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        [Range(0, 999.99)]
        public decimal Price { get; set; }

        [Required]
        public Genre Genre { get; set; }

        public bool Preorder { get; set; }
    }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if (Genre == Genre.Classic && ReleaseDate.Year > _classicYear)
        {
            yield return new ValidationResult(
                "Classic movies must have a release year earlier than " + _classicYear,
                new[] { "ReleaseDate" });
        }
    }
}