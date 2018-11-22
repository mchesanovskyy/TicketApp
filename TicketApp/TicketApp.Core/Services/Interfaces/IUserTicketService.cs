namespace TicketApp.Core.Services.Interfaces
{
    public interface IUserTicketService
    {
        int RemoveExpiredTickets();
    }
}