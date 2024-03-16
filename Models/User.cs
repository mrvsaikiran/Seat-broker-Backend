using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
 

namespace Seat_broker_backend.Models
{
    [Index(nameof(Email), IsUnique = true)]
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? UserName { get; set; }

        [Required]
        public string? Email { get; set; }

        [Required]
        public string? PhoneNumber { get; set; }

        [Required]
        public string? Password { get; set; }

        public string? Token { get; set; }

        public string? UserType { get; set; }

    }
}
