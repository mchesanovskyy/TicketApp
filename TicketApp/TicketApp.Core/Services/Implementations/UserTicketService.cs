using System;
using System.Linq;
using TicketApp.Core.EntityFramework;
using TicketApp.Core.Services.Interfaces;

namespace TicketApp.Core.Services.Implementations
{
    public class UserTicketService : IUserTicketService
    {
        private readonly TicketAppDbContext _dbContext;
        public UserTicketService(TicketAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        /// <summary>
        /// Removes UserTicket record where expiryDateTime less than DateTime.UtcNow
        /// </summary>
        /// <returns>Count of removed user tickets</returns>
        public int RemoveExpiredTickets()
        {
            var userTickets = _dbContext.UserTickets.Where(ut => ut.ExpiryDateTime.HasValue && ut.ExpiryDateTime.Value < DateTime.UtcNow);
            int count = userTickets.Count();
            _dbContext.UserTickets.RemoveRange(userTickets);
            _dbContext.SaveChanges();
            return count;
        }


    }
}