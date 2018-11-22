using System.Data.Entity.ModelConfiguration;
using TicketApp.Core.Entities;

namespace TicketApp.Core.EntityFramework.Configs
{
    public class TicketConfiguration : EntityTypeConfiguration<Ticket>
    {
        public TicketConfiguration()
        {
            ToTable("Tickets");
            HasKey(x => x.Id);

            HasRequired(x => x.Event)
                .WithMany(x => x.Tickets)
                .HasForeignKey(k => k.EventId)
                .WillCascadeOnDelete(false);
        }
    }
}