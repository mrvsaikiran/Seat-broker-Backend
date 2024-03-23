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
    public class BookingController : Controller
    {
        private readonly ILogger<BookingController> _logger;
        private readonly BookingRepository _bookingRepository;

        public BookingController(ILogger<BookingController> logger, BookingRepository bookingRepository)
        {
            _logger = logger;
            _bookingRepository = bookingRepository;
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
        public async Task<IEnumerable<Bookings>> getBookingHistory(int id) 
        {
            return await _bookingRepository.getBookingsOfUser(id);
        }

        [HttpGet]
        public async Task<IEnumerable<string>> getBookedSeatsList(int showId) 
        {
            return await _bookingRepository.getBookedSeatsList(showId);
        }
        
        [HttpGet]
        public async Task<BookingsDto> getBookingInfo(int showId,DateTime showDate)
        {
            return await _bookingRepository.getBookingInfo(showId, showDate);
        }
        [HttpPost]
        public IActionResult AddBookingDetails(Bookings bookingDetails)
        {
             _bookingRepository.AddBookingDetails(bookingDetails);
            return Ok();
        }
    }
}