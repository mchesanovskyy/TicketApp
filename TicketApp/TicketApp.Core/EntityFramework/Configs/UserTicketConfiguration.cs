using System.Data.Entity.ModelConfiguration;
using TicketApp.Core.Entities;

namespace TicketApp.Core.EntityFramework.Configs
{
    public class UserTicketConfiguration : EntityTypeConfiguration<UserTicket>
    {
        public UserTicketConfiguration()
        {
            ToTable("UserTickets");
            HasKey(x => x.Id);

            HasRequired(x => x.Ticket)
                .WithMany(x => x.UserTickets)
                .HasForeignKey(k => k.TicketId);

            HasRequired(x => x.User)
                .WithMany(x => x.UserTickets)
                .HasForeignKey(k => k.UserId);
        }
    }
}