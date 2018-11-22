using System.Data.Entity;
using TicketApp.Core.Entities;
using TicketApp.Core.EntityFramework.Configs;

namespace TicketApp.Core.EntityFramework
{
    public class TicketAppDbContext : DbContext
    {
        public TicketAppDbContext() : base("DefaultConnection")
        {
        }

        static TicketAppDbContext()
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TicketAppDbContext, Migrations.Configuration>());
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<UserTicket> UserTickets { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new EventConfiguration());
            modelBuilder.Configurations.Add(new TicketConfiguration());
            modelBuilder.Configurations.Add(new UserTicketConfiguration());
        }
    }
}
