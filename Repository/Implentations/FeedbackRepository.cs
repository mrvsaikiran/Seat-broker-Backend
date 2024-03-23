using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using Seat_broker_backend.Context;
using Seat_broker_backend.Models;
using Seat_broker_backend.Repository.Interfaces;

namespace Seat_broker_backend.Repository.Implentations
{
    public class FeedbackRepository : IFeedbackRepository
    {
         private readonly AppDbContext _context;
         FeedbackRepository(AppDbContext db)
        {
            _context = db;
        }

        public async Task UpdateTheaterRating(Rating rating)
        {
            var movieDetails = await _context.Movies.Where(element => element.MovieId == rating.MovieId).FirstOrDefaultAsync();
            if(movieDetails != null)
            {
                movieDetails.MovieRating = (movieDetails.MovieRating * movieDetails.RatersCount + rating.MovieRating)/(movieDetails.RatersCount+1);
                movieDetails.RatersCount++;
            }
            var theaterDetails = await _context.Theatre.Where(element => element.TheatreId == rating.TheaterId).FirstOrDefaultAsync();
            if(theaterDetails != null)
            {
                theaterDetails.TheatreRating = (theaterDetails.TheatreRating * theaterDetails.RatersCount + rating.MovieRating)/(theaterDetails.RatersCount+1);
                theaterDetails.RatersCount++;
            }
            await _context.SaveChangesAsync();
        }
    }
}