using System;
using System.Collections.Generic;

namespace TicketApp.Core.Entities
{
    public class Ticket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public decimal Price { get; set; }
        public int EventId { get; set; }
        public int Capacity { get; set; }

        public virtual User Organizer { get; set; }
        public virtual Event Event { get; set; }
        public virtual ICollection<UserTicket> UserTickets { get; set; }
    }
}