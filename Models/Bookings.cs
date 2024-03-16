using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Seat_broker_backend.Models
{
    [Index(nameof(ShowId))]
    public class Bookings
    {
        [Key]
        public int BookingId { get; set; }

        [Required]
        public DateTime BookedForDate { get; set; }

        [Required]
        public int price { get; set; }

        public string SeatId { get; set; } = null!;

        [Required]
        public int UserId {  get; set; }

        [Required]
        public int ShowId { get; set; }

        public User user { get; set; } = null!;

        public Shows show { get; set; } = null!;


       
    }
}
