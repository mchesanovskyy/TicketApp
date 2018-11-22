using System.Data.Entity.ModelConfiguration;
using TicketApp.Core.Entities;

namespace TicketApp.Core.EntityFramework.Configs
{
    public class RoleConfiguration : EntityTypeConfiguration<Role>
    {
        public RoleConfiguration()
        {
            ToTable("Roles");
            HasKey(x => x.Id);
        }
    }
}