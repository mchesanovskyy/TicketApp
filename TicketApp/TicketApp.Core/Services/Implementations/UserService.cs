using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TicketApp.Core.Entities;
using TicketApp.Core.Entities.Enums;
using TicketApp.Core.EntityFramework;
using TicketApp.Core.Services.Interfaces;

namespace TicketApp.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly TicketAppDbContext _dbContext;
        public UserService(TicketAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void AddWithRole(User user, RoleName roleName)
        {
            var role = _dbContext.Roles.FirstOrDefault(r =>
                r.Name.Equals(roleName.ToString(), StringComparison.OrdinalIgnoreCase));
            if(role == null)
                throw new Exception(string.Format("A role '{0}' does not exist", roleName.ToString()));

            if(user.Roles == null)
                user.Roles = new List<Role>();

            user.Roles.Add(role);

            Add(user);
        }

        public IEnumerable<User> Collection
        {
            get { return _dbContext.Users.AsEnumerable(); }
        }

        public void Update(User user)
        {
            _dbContext.Entry(user).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }
    }
}