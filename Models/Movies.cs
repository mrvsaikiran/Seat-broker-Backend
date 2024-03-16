using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models
{
    public class Movies
    {
        [Key]
        public int MovieId { get; set; }
         
        [Required]
        public string? MovieName { get; set; }

        public string? MovieDescription { get; set; }

        public string? Genre { get; set; }

        public int MovieRating { get; set; }

        [Required]
        public string? PosterUrl { get; set; }

        [Required]
        public int Duration { get; set; }
    }
}
