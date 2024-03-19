using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Seat_broker_backend.Models;

namespace Seat_broker_backend.Repository.Interfaces
{
    public interface IFeedbackRepository
    {
        Task UpdateTheaterRating(Rating rating);
    }
}