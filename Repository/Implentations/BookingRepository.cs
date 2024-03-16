using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class BookingRepository : IBookingRespoitory
    {
        private readonly AppDbContext _context;
        private readonly ShowRepository _showRepo;
        private readonly TheatreRepository _theatreRepo;
        BookingRepository(AppDbContext db,ShowRepository showRepository,TheatreRepository theatreRepo)
        {
            _context = db;
            _showRepo=showRepository;
            _theatreRepo=theatreRepo;
        }
       public async Task<IEnumerable<string>> getBookedSeatsList(int showId)
        {
            IEnumerable<string> seatList= await _context.Bookings.Where(b => b.ShowId==showId).Select(s=>s.SeatId).ToListAsync();
            return seatList;
        }

       public async Task<BookingsDto> getBookingInfo(int showId,DateTime Showdate)
        {
            Shows showPriceInfo = await _showRepo.getShowById(showId);
            TheatreStructureDto theatreStructureInfo = await _theatreRepo.getTheatreStructureDetails(showId);
            IEnumerable<string> bookedSeats = await _context.Bookings
                     .Where(b => b.ShowId == showId && b.BookedForDate == Showdate)
                     .Select(s=>s.SeatId).ToListAsync();
           
            return new BookingsDto
            {
                ShowId = showId,
                LowerBalconyColCount = theatreStructureInfo.LowerBalconyColCount,
                LowerBalconyRowCount = theatreStructureInfo.LowerBalconyRowCount,
                UpperBalconyColCount = theatreStructureInfo.UpperBalconyColCount,
                UpperBalconyRowCount = theatreStructureInfo.UpperBalconyRowCount,
                ShowLowerBalconyPrice = showPriceInfo.ShowLowerBalconyPrice,
                ShowUpperBalconyPrice = showPriceInfo.ShowUpperBalconyPrice,
                BookedSeatsList = bookedSeats
            };
          
        }

        public async Task<IEnumerable<Bookings>> getBookingsOfUser(int UserId)
        {
            IEnumerable<Bookings>BookingList= await _context.Bookings.Where(b => b.UserId == UserId).ToListAsync();
            return BookingList;
        }

        
    }
}
