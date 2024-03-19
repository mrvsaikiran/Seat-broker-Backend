using Seat_broker_backend.Models;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface IMovieRepository
    {
        Task<Movies> getMovieById(int MovieId);

        Task<IEnumerable<Movies>> getMovieByCity(string locationGiven);
    }
}
