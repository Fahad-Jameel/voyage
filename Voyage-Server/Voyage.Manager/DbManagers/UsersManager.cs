using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Voyage.Domain.Database;
using Voyage.Domain.Models;

namespace Voyage.Manager.DbManagers
{
    public class UsersManager
    {
        private readonly AppDbContext m_DbContext;
        public UsersManager()
        {
            m_DbContext = new AppDbContext();
        }

        public int AuthenticateUser(string email, string passwordHash)
        {
            User foundUserProfile = m_DbContext.Users.AsNoTracking().SingleOrDefault(u => u.Email == email);

            if (foundUserProfile == null)
            {
                return -1;
            }
            else
            {
                if (foundUserProfile.PasswordHash == passwordHash)
                {
                    return foundUserProfile.Id;
                }
                else
                {
                    return -1;
                }
            }
        }

        public int CreateUserProfile(User user)
        {
            m_DbContext.Users.Add(user);
            m_DbContext.SaveChanges();

            return m_DbContext.Users.AsNoTracking().OrderByDescending(u => u.Id).FirstOrDefault().Id;
        }

        public User GetUserById(int id)
        {
            return m_DbContext.Users.AsNoTracking().Where(u => u.Id == id).FirstOrDefault();
        }
    }
}
