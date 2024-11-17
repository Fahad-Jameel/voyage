using Microsoft.AspNetCore.Mvc;
using Voyage.Manager.DbManagers;

namespace Voyage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DashboardController : ControllerBase
    {
        private readonly CitiesManager m_CitiesManager;

        public DashboardController()
        {
            m_CitiesManager = new CitiesManager();
        }

        [HttpGet("GetUserRecommendations")]
        public IActionResult GetUserRecommendations()
        {
            return Ok();
        }

        [HttpGet("GetCitiesList")]
        public IActionResult GetCities()
        {
            return Ok(m_CitiesManager.GetAllCities());
        }
    }
}
