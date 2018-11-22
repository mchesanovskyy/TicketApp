using System;
using System.Collections.Generic;

namespace TicketApp.Core.Entities
{
    public class Event
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int OrganizerId { get; set; }
        public string Address { get; set; }
        public string Description { get; set; }

        public virtual User Organizer { get; set; }
        public virtual ICollection<Ticket> Tickets { get; set; }
    }
}