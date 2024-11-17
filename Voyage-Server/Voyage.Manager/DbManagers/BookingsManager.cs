using Microsoft.EntityFrameworkCore;
using Voyage.Domain.Database;
using Voyage.Domain.Models;

namespace Voyage.Manager.DbManagers
{
    public class BookingsManager
    {
        private readonly AppDbContext m_AppDbContext;

        public BookingsManager()
        {
            m_AppDbContext = new AppDbContext();
        }

        public List<Booking> GetActiveBookingsByUserId(int userId)
        {
            List<Booking> foundBookings = m_AppDbContext.Bookings.AsNoTracking().Where(b => b.UserId == userId).ToList();

            return foundBookings;
        }

        public int CreateBooking(Booking booking)
        {
            m_AppDbContext.Bookings.Add(booking);
            m_AppDbContext.SaveChanges();

            return m_AppDbContext.Bookings.AsNoTracking().OrderByDescending(b => b.Id).FirstOrDefault().Id;
        }
    }
}
