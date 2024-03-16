using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models.Dto
{
    public class TheatreDto
    {
        public int TheatreId { get; set; }
        public string? TheatreName { get; set; }
        public string? City { get; set; }
        public int TheatreRating { get; set; }
        public float Latitude { get; set; }
        public float longitute { get; set; }
    }
}
