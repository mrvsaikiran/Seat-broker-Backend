using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models
{
    [Index(nameof(City))]
    public class Theatre
    {
        [Key]
        public int TheatreId { get; set; }

        [Required]
        public string? TheatreName { get; set; }

        [Required]
        public string? City {  get; set; }

        public int TheatreRating {  get; set; }

        [Required]
        public int UpperBalconyRowCount { get; set; }

        [Required]
        public int UpperBalconyColCount {  get; set; }

        public int LowerBalconyRowCount { get; set; }

        public int LowerBalconyColCount { get; set; }

        public float Latitude { get; set; }

        public float longitute { get; set; }

    }
}
