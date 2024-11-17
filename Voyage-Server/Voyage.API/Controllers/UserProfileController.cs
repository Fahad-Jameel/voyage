using Microsoft.AspNetCore.Mvc;
using Voyage.API.DTOs.UserDTOs;
using Voyage.Domain.Models;
using Voyage.Manager.DbManagers;
using Voyage.Manager.Utils;

namespace Voyage.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserProfileController : ControllerBase
    {
        private readonly UsersManager m_UsersManager;
        private readonly Utilities m_Utils;
        public UserProfileController()
        {
            m_UsersManager = new UsersManager();
            m_Utils = new Utilities();
        }

        [HttpPost("AuthenticateUser")]
        public IActionResult AuthenticateUser([FromBody] UserAuthenticationDTO userAuthenticationDTO)
        {
            return Ok(m_UsersManager.AuthenticateUser(userAuthenticationDTO.UserEmail, userAuthenticationDTO.UserPassword));
        }

        [HttpPost("CreateUserProfile")]
        public IActionResult CreateUserProfile([FromBody] UserProfileCreationDTO userProfileCreationDTO)
        {
            User userToCreate = new User();
            userToCreate.Email = userProfileCreationDTO.Email;
            userToCreate.PasswordHash = m_Utils.ComputeHash(userProfileCreationDTO.Password);
            userToCreate.FirstName = userProfileCreationDTO.FirstName;
            userToCreate.LastName = userProfileCreationDTO.LastName;

            userToCreate.PhoneNumber = string.Empty;
            userToCreate.PassportNumber = string.Empty;
            userToCreate.CNICNumber = string.Empty;

            return Ok(m_UsersManager.CreateUserProfile(userToCreate));
        }

        [HttpGet("GetUserProfile")]
        public IActionResult GetUserProfile([FromBody] int userId)
        {
            return Ok();
        }

        [HttpGet("UpdateUserProfile")]
        public IActionResult UpdateUserProfile([FromBody] UserProfileUpdatingDTO userProfileUpdationDTO)
        {
            return Ok();
        }
    }
}
