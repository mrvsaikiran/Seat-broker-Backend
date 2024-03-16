using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface ITheatreRepository
    {
        Task<IEnumerable<Theatre>> GetTheatreByCity(string city);

        Task<IEnumerable<int>> getTheatreIdByCity(string cityGiven);

        Task<TheatreStructureDto> getTheatreStructureDetails(int TheatreId);
    }

}




