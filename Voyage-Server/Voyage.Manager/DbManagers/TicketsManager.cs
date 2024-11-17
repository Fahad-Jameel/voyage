using Microsoft.EntityFrameworkCore;
using Voyage.Domain.Database;
using Voyage.Domain.Enums;
using Voyage.Domain.Models;

namespace Voyage.Manager.DbManagers
{
    public class TicketsManager
    {
        private readonly AppDbContext m_AppDbContext;
        public TicketsManager()
        {
            m_AppDbContext = new AppDbContext();
        }

        public List<AvailableTicket> GetAvailableTickets(string startCity, string endCity, DateOnly date)
        {
            List<AvailableTicket> availableTickets = m_AppDbContext.AvailableTickets.AsNoTracking().Where(t => t.StartLocationCity.Name == startCity
                                                                                                            && t.EndLocationCity.Name == endCity
                                                                                                            && t.TicketDate == date).ToList();
            return availableTickets;
        }

        public AvailableTicket GetAvailableTicketById(int id)
        {
            return m_AppDbContext.AvailableTickets.AsNoTracking().Where(t => t.Id == id).FirstOrDefault();
        }
    }
}
