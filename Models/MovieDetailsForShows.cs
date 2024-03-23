using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Seat_broker_backend.Models
{
    public class MovieDetailsForShows
    {
        public int MovieId { get; set; }
        public DateTime Date { get; set; }
        public string City { get; set; }
        public int CurrentIndex { get; set; }
        public int PageSize { get; set; }
    }
}