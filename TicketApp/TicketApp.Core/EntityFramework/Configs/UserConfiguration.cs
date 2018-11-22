using System.Data.Entity.ModelConfiguration;
using TicketApp.Core.Entities;

namespace TicketApp.Core.EntityFramework.Configs
{
    public class UserConfiguration : EntityTypeConfiguration<User>
    {
        public UserConfiguration()
        {
            ToTable("Users");
            HasKey(x => x.Id);

            HasMany(x => x.Roles)
                .WithMany(x => x.Users)
                .Map(m =>
                {
                    m.MapLeftKey("RoleId");
                    m.MapRightKey("UserId");
                    m.ToTable("UserRoles");
                });
        }
    }
}