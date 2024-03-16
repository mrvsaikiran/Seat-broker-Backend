using Microsoft.EntityFrameworkCore;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class ShowRepository : IShowRepository
    {

        private readonly AppDbContext _db;

        private readonly TheatreRepository _theatreRepository;
        
        public ShowRepository(AppDbContext db,TheatreRepository theatreRepository)
        {
            _db = db;
            _theatreRepository = theatreRepository;
        }

   
        public async Task<IEnumerable<int>> getMovieIdGivenTheatreIds(IEnumerable<int> TheatreIdList)
        {
           IEnumerable<int> MovieIdList= await _db.Shows
                                                    .Where(s => TheatreIdList.Contains(s.TheatreId))
                                                    .Select(m=>m.MovieId)
                                                    .ToListAsync();
            return MovieIdList;
        }

        public async Task<IEnumerable<ShowsDto>> getShowForMovieOnDateInCity(int MovieId, DateTime date, string City,int CurrentIndex,int PageSize)
        {
            IEnumerable<int> theatresList=await _theatreRepository.getTheatreIdByCity(City);

            IEnumerable<ShowsDto> ShowList = await _db.Shows
                      .Where(s => theatresList.Contains(s.TheatreId) &&
                                  s.MovieId == MovieId &&
                                  s.ShowDateTime.Year == date.Year &&
                                  s.ShowDateTime.Month == date.Month &&
                                  s.ShowDateTime.Day == date.Day)
                      .Join(_db.Theatre,
                      sh => sh.TheatreId, th => th.TheatreId, 
                      (sh, th) => new ShowsDto{
                         ShowId=sh.ShowId,
                         ShowDateTime= sh.ShowDateTime,
                         TheatreId = sh.TheatreId,
                         TheatreName= th.TheatreName,
                         City = th.City,
                         TheatreRating = th.TheatreRating,
                         Latitude = th.Latitude,
                         longitute = th.longitute
                      })
                      .Skip(CurrentIndex)
                      .Take(PageSize)
                      .ToListAsync();

            return ShowList;
        }

        public async Task<Shows> getShowById(int ShowId)
        {
            Shows showInfo = await _db.Shows.Where(s=>s.ShowId==ShowId).FirstOrDefaultAsync();
            return showInfo;
        }
    }
}
