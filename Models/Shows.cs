using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models
{
    [Index(nameof(ShowDateTime))]
    public class Shows
    {
        [Key]
        public int ShowId { get; set; }

        [Required]
        public DateTime  ShowDateTime { get; set; }

        [Required]
        public int MovieId {  get; set; }

        [Required]
        public int TheatreId { get; set; }

        
        public Movies movies { get; set; } = null!;

        public Theatre theatre { get; set; } = null!;

        [Required]
        public int ShowUpperBalconyPrice { get; set; }

        [Required]
        public int ShowLowerBalconyPrice { get; set; }
    }
}
