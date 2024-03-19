using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface IBookingRespoitory
    {
        Task<IEnumerable<string>> getBookedSeatsList(int showId);

        Task<BookingsDto> getBookingInfo(int showId,DateTime ShowDate);

        Task<IEnumerable<Bookings>> getBookingsOfUser(int UserId);
        void AddBookingDetails(Bookings bookingDetails);
    }
}
