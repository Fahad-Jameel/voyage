using Voyage.Domain.Models;

namespace Voyage.API.DTOs.TicketsDTOs
{
    public class SearchTicketsTwoWayResponse
    {
        public List<AvailableTicket> OutboundTickets { get; set; }
        public List<AvailableTicket> InboundTickets { get; set; }
    }
}
