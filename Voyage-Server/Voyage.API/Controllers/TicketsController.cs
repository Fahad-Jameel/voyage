using Microsoft.AspNetCore.Mvc;
using Voyage.API.DTOs.TicketsDTOs;
using Voyage.Domain.Models;
using Voyage.Manager.DbManagers;

namespace Voyage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TicketsController : ControllerBase
    {
        private readonly TicketsManager m_TicketsManager;
        public TicketsController()
        {
            m_TicketsManager = new TicketsManager();
        }

        [HttpGet("GetAvailableTickets")]
        public IActionResult GetAvailableTickets([FromBody] SearchTicketsRequestDTO searchTicketsRequestDTO)
        {
            if (searchTicketsRequestDTO.IsTwoWay == false)
            {
                return Ok(m_TicketsManager.GetAvailableTickets(searchTicketsRequestDTO.StartLocationCity, searchTicketsRequestDTO.EndLocationCity, searchTicketsRequestDTO.OutboundTicketDate));
            }
            else
            {
                List<AvailableTicket> OutboundTickets = m_TicketsManager.GetAvailableTickets(searchTicketsRequestDTO.StartLocationCity, searchTicketsRequestDTO.EndLocationCity, searchTicketsRequestDTO.OutboundTicketDate);
                List<AvailableTicket> InboundTickets = m_TicketsManager.GetAvailableTickets(searchTicketsRequestDTO.EndLocationCity, searchTicketsRequestDTO.StartLocationCity, searchTicketsRequestDTO.InboundTicketDate);

                SearchTicketsTwoWayResponse searchTicketsTwoWayResponse = new SearchTicketsTwoWayResponse();
                searchTicketsTwoWayResponse.OutboundTickets = OutboundTickets;
                searchTicketsTwoWayResponse.InboundTickets = InboundTickets;

                return Ok(searchTicketsTwoWayResponse);
            }
        }
    }
}
