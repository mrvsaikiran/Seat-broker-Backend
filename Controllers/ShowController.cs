using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Seat_broker_backend.Models;
using Seat_broker_backend.Models.Dto;
using Seat_broker_backend.Repository.Implentations;

namespace Seat_broker_backend.Controllers
{
    [Route("[controller]")]
    public class ShowController : Controller
    {
        private readonly ILogger<ShowController> _logger;
        private readonly ShowRepository _showRepository;
        public ShowController(ILogger<ShowController> logger, ShowRepository showRepository)
        {
            _logger = logger;
            _showRepository = showRepository;
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

        [HttpPost]
        public async Task<IEnumerable<ShowsDto>> getAllShows(MovieDetailsForShows details) 
        {
            return await _showRepository.getShowForMovieOnDateInCity(details);
        }
    }
}