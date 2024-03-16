using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class TheatreRepository :ITheatreRepository
    {
        private readonly AppDbContext _db;
        private readonly IMemoryCache _cache;


        public TheatreRepository(AppDbContext db, IMemoryCache cache)
        {
            _db = db;
            _cache = cache;
        }
        public async Task<IEnumerable<Theatre>> GetTheatreByCity(string city)
        {
            var cacheKey = $"TheatresInCity-{city}";

            IEnumerable<Theatre> theatres = _cache.Get<IEnumerable<Theatre>>(cacheKey);
            if (theatres == null)
            {
                theatres = await _db.Theatre.Where(x => x.City == city).ToListAsync();
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(20)); 
                _cache.Set(cacheKey, theatres, cacheEntryOptions);
            }

            return theatres;
            
        }

        public async Task<IEnumerable<int>> getTheatreIdByCity(string cityGiven)
        {
            IEnumerable<int> IdList= await _db.Theatre
                                              .Where(th => th.City == cityGiven)                 
                                              .Select(T => T.TheatreId).ToListAsync();
            return IdList;
        }



        public async Task<TheatreStructureDto> getTheatreStructureDetails(int TheatreId)
        {
            TheatreStructureDto theatreStructure =  await _db.Theatre.Where(t=>t.TheatreId== TheatreId)
                                                           .Select(t=>new TheatreStructureDto
                                                           {
                                                               UpperBalconyRowCount = t.UpperBalconyRowCount,
                                                               UpperBalconyColCount = t.UpperBalconyColCount,
                                                               LowerBalconyColCount = t.LowerBalconyColCount,
                                                               LowerBalconyRowCount = t.LowerBalconyRowCount
                                                           }).FirstOrDefaultAsync();
            return theatreStructure;
        }
    }
}
