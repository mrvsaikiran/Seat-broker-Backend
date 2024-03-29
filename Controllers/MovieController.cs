using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seat_broker_backend.Models;
using Seat_broker_backend.Repository.Implentations;

namespace Seat_broker_backend.Controllers
{
    [Route("[controller]")]
    public class MovieController : Controller
    {
        private readonly ILogger<MovieController> _logger;
        private readonly MovieRepository _movieRepository;

        public MovieController(ILogger<MovieController> logger, MovieRepository movieRepository)
        {
            _logger = logger;
            _movieRepository = movieRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }

        [HttpGet]
        public async Task<IEnumerable<Movies>> getMovieByCity(string location) 
        {
            return await _movieRepository.getMovieByCity(location);
        }
    }
}