using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models.Dto
{
    public class ShowsDto
    {
        public int ShowId { get; set; }
        public DateTime ShowDateTime { get; set; }
        public int TheatreId { get; set; }
        public string? TheatreName { get; set; }
        public string? City { get; set; }
        public int TheatreRating { get; set; }
        public float Latitude { get; set; }
        public float longitute { get; set; }

    }
}
