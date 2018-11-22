namespace TicketApp.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Version_1_0_0_0 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Events",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        OrganizerId = c.Int(nullable: false),
                        Address = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.OrganizerId, cascadeDelete: true)
                .Index(t => t.OrganizerId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserTickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        PaidAmount = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Status = c.Int(nullable: false),
                        ExpiryDateTime = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.TicketId);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        StartDateTime = c.DateTime(nullable: false),
                        EndDateTime = c.DateTime(nullable: false),
                        Price = c.Decimal(nullable: false, precision: 18, scale: 2),
                        EventId = c.Int(nullable: false),
                        Capacity = c.Int(nullable: false),
                        Organizer_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Events", t => t.EventId)
                .ForeignKey("dbo.Users", t => t.Organizer_Id)
                .Index(t => t.EventId)
                .Index(t => t.Organizer_Id);
            
            CreateTable(
                "dbo.UserRoles",
                c => new
                    {
                        RoleId = c.Int(nullable: false),
                        UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.UserId })
                .ForeignKey("dbo.Users", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Roles", t => t.UserId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Events", "OrganizerId", "dbo.Users");
            DropForeignKey("dbo.UserTickets", "UserId", "dbo.Users");
            DropForeignKey("dbo.UserTickets", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.Tickets", "Organizer_Id", "dbo.Users");
            DropForeignKey("dbo.Tickets", "EventId", "dbo.Events");
            DropForeignKey("dbo.UserRoles", "UserId", "dbo.Roles");
            DropForeignKey("dbo.UserRoles", "RoleId", "dbo.Users");
            DropIndex("dbo.UserRoles", new[] { "UserId" });
            DropIndex("dbo.UserRoles", new[] { "RoleId" });
            DropIndex("dbo.Tickets", new[] { "Organizer_Id" });
            DropIndex("dbo.Tickets", new[] { "EventId" });
            DropIndex("dbo.UserTickets", new[] { "TicketId" });
            DropIndex("dbo.UserTickets", new[] { "UserId" });
            DropIndex("dbo.Events", new[] { "OrganizerId" });
            DropTable("dbo.UserRoles");
            DropTable("dbo.Tickets");
            DropTable("dbo.UserTickets");
            DropTable("dbo.Roles");
            DropTable("dbo.Users");
            DropTable("dbo.Events");
        }
    }
}
