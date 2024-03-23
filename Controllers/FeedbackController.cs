using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Seat_broker_backend.Models;
using Seat_broker_backend.Repository.Implentations;

namespace Seat_broker_backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FeedbackController : ControllerBase
    {
        FeedbackRepository _feedbackRepository;
        FeedbackController (FeedbackRepository feedbackRepository) 
        {
            _feedbackRepository = feedbackRepository;
        }
        [HttpPost]
        public async Task UpdateTheaterRating(Rating rating)
        {
            await _feedbackRepository.UpdateTheaterRating(rating);
        }
    }
}