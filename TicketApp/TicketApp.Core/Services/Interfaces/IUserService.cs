using System.Collections.Generic;
using TicketApp.Core.Entities;
using TicketApp.Core.Entities.Enums;

namespace TicketApp.Core.Services.Interfaces
{
    public interface IUserService
    {
        void Add(User user);
        void AddWithRole(User user, RoleName roleName);
        IEnumerable<User> Collection { get; }
        void Update(User user);
    }
}
