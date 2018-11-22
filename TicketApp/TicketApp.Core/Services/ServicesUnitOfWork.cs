using TicketApp.Core.EntityFramework;
using TicketApp.Core.Services.Implementations;
using TicketApp.Core.Services.Interfaces;

namespace TicketApp.Core.Services
{
    public class ServicesUnitOfWork
    {
        private TicketAppDbContext _dbContext;
        protected TicketAppDbContext DbContext
        {
            get { return _dbContext ?? (_dbContext = new TicketAppDbContext()); }
        }

        private IUserService _userService;
        public IUserService UserService
        {
            get { return _userService ?? (_userService = new UserService(DbContext)); }
        }

        private IUserTicketService _userTicketService;
        public IUserTicketService UserTicketService
        {
            get { return _userTicketService ?? (_userTicketService = new UserTicketService(DbContext)); }
        }


    }
}