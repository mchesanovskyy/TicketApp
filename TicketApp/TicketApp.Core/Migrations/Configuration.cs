using TicketApp.Core.Entities;
using TicketApp.Core.Entities.Enums;

namespace TicketApp.Core.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<TicketApp.Core.EntityFramework.TicketAppDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(TicketApp.Core.EntityFramework.TicketAppDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            // it will create 3 basic roles with DB migrations
            context.Roles.AddOrUpdate(new Role() { Name = RoleName.Administrator.ToString() });
            context.Roles.AddOrUpdate(new Role() { Name = RoleName.Organizer.ToString() });
            context.Roles.AddOrUpdate(new Role() { Name = RoleName.Attendee.ToString() });

        }
    }
}
