using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface IShowRepository
    {
        Task<IEnumerable<int>> getMovieIdGivenTheatreIds(IEnumerable<int> TheatreIdList);

        Task<Shows> getShowById(int ShowId);
        Task<IEnumerable<ShowsDto>> getShowForMovieOnDateInCity(MovieDetailsForShows details);
    }
}
