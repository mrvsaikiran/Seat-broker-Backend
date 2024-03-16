using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class MovieRepository : IMovieRepository
    {
        private readonly AppDbContext _context;

        private readonly ShowRepository _showRepository;

        private readonly TheatreRepository _theatreRepository;

        public MovieRepository(AppDbContext db, ShowRepository showRepository,TheatreRepository theatreRepository) 
        {
            _context = db;
             _theatreRepository = theatreRepository;
            _showRepository = showRepository;
        }
        public  Task<Movies> getMovieById(int MovieId)
        {
            throw new NotImplementedException();
        }

       public  Task<IEnumerable<Movies>> GetMoviesInCity(string City)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Movies>> getMovieByCity(string locationGiven)
        {
            IEnumerable<int> TheatreIdInCity= await _theatreRepository.getTheatreIdByCity(locationGiven);

            IEnumerable<int> MovieIdInCity= await _showRepository.getMovieIdGivenTheatreIds(TheatreIdInCity);
             
            IEnumerable<Movies> moviesList = await _context.Movies.Where(m => MovieIdInCity.Contains(m.MovieId)).ToListAsync();

            return moviesList;
        }
    }
}
