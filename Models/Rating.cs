using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seat_broker_backend.Models
{
    public class Rating
    {
        public int MovieId { get; set; }
        public int TheaterId { get; set; }
        public int MovieRating { get; set; }
        public int Theaterrating { get; set; }
    }
}