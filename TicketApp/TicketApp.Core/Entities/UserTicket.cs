using System;
using TicketApp.Core.Entities.Enums;

namespace TicketApp.Core.Entities
{
    public class UserTicket
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int TicketId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal PaidAmount { get; set; }
        public UserTicketStatus Status { get; set; }
        public DateTime? ExpiryDateTime { get; set; }

        public virtual User User { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}