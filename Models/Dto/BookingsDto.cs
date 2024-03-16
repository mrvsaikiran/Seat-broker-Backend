using System.ComponentModel.DataAnnotations;

namespace Seat_broker_backend.Models.Dto
{
    public class BookingsDto
    {

        public int ShowId { get; set; }
        public int UpperBalconyRowCount { get; set; }
        public int UpperBalconyColCount { get; set; }
        public int LowerBalconyRowCount { get; set; }
        public int LowerBalconyColCount { get; set; }
        public int ShowUpperBalconyPrice { get; set; }
        public int ShowLowerBalconyPrice { get; set; }
        public IEnumerable<string> BookedSeatsList { get; set; } = null!;         


    }
}
