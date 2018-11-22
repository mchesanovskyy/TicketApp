using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketApp.Core.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<UserTicket> UserTickets { get; set; }

        public string GetFullName()
        {
            return $"{FirstName} {LastName}";
        }

        public string GetRolesString()
        {
            return string.Join(",", Roles.Select(r => r.Name));
        }
    }
}
