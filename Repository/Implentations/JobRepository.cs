using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public  class JobRepository
    {
        private readonly AppDbContext _db;
        JobRepository(AppDbContext dbContext)
        {
            _db=dbContext;
        }
        
        public  async void CleanupPreviousBookings()
        {
            
            var yesterday = DateTime.Today.AddDays(-1);
            var bookingsToDelete = _db.Bookings.Where(b => b.BookedForDate.Date == yesterday.Date);
            _db.Bookings.RemoveRange(bookingsToDelete);
            await _db.SaveChangesAsync();

        }
    }
}
