using System.Data.Entity.ModelConfiguration;
using TicketApp.Core.Entities;

namespace TicketApp.Core.EntityFramework.Configs
{
    public class EventConfiguration : EntityTypeConfiguration<Event>
    {
        public EventConfiguration()
        {
            ToTable("Events");
            HasKey(x => x.Id);

            HasRequired(x => x.Organizer)
                .WithMany(x => x.Events)
                .HasForeignKey(k => k.OrganizerId);

        }
    }
}