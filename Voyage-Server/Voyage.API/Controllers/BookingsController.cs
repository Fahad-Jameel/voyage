using Microsoft.AspNetCore.Mvc;
using Voyage.API.DTOs.BookingsDTOs;
using Voyage.Domain.Models;
using Voyage.Manager.DbManagers;

namespace Voyage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookingsController : ControllerBase
    {
        private readonly BookingsManager m_BookingsManager;

        public BookingsController()
        {
            m_BookingsManager = new BookingsManager();
        }

        [HttpGet("CreateBooking")]
        public IActionResult CreateBooking([FromBody] BookingsRequestDTO bookingsRequestDTO)
        {
            Booking bookingToCreate = new Booking();
            bookingToCreate.UserId = bookingsRequestDTO.UserId;
            bookingToCreate.TicketId = bookingsRequestDTO.TicketId;

            return Ok(m_BookingsManager.CreateBooking(bookingToCreate));
        }
    }
}
