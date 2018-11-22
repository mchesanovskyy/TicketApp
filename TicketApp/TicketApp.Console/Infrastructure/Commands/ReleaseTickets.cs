using TicketApp.Core.Services;

namespace TicketApp.Console.Infrastructure.Commands
{
    public class ReleaseTickets : ICommand
    {
        private readonly ServicesUnitOfWork _unitOfWork;

        public ReleaseTickets(ServicesUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public string CommandKey
        {
            get { return "tickets release"; }
        }
        public string Description
        {
            get { return "Remove all user tickets where ExpiryDateTime less than DateTime.UtcNow"; }
        }

        public void Execute(string[] args, string enteredCommandKey)
        {
            var removedUserTicketsCount = _unitOfWork.UserTicketService.RemoveExpiredTickets();
            System.Console.WriteLine("Removed {0} expired bookings", removedUserTicketsCount);
        }
    }
}