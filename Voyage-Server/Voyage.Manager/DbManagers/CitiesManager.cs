using Microsoft.EntityFrameworkCore;
using Voyage.Domain.Database;
using Voyage.Domain.Models;

namespace Voyage.Manager.DbManagers
{
    public class CitiesManager
    {
        private readonly AppDbContext m_AppContext;
        public CitiesManager()
        {
            m_AppContext = new AppDbContext();
        }

        public List<City> GetAllCities()
        {
            return m_AppContext.Cities.AsNoTracking().ToList();
        }
    }
}
