namespace FlightTicketBookingSystem.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TblAdminLogin",
                c => new
                    {
                        AdminId = c.Int(nullable: false, identity: true),
                        AdName = c.String(nullable: false, maxLength: 40),
                        Password = c.String(nullable: false, maxLength: 10),
                    })
                .PrimaryKey(t => t.AdminId);
            
            CreateTable(
                "dbo.AeroPlaneInfoes",
                c => new
                    {
                        Planeid = c.Int(nullable: false, identity: true),
                        APlaneName = c.String(nullable: false, maxLength: 30),
                        SeatingCapacity = c.Int(nullable: false),
                        Price = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Planeid);
            
            CreateTable(
                "dbo.TicketReserve_tbl",
                c => new
                    {
                        ResId = c.Int(nullable: false, identity: true),
                        Resfrom = c.String(nullable: false),
                        ResTo = c.String(nullable: false),
                        ResDepDate = c.String(nullable: false),
                        ResTime = c.String(nullable: false),
                        PlaneId = c.Int(nullable: false),
                        PlaneSeat = c.Int(nullable: false),
                        ResTicketPrice = c.Single(nullable: false),
                        ResTicketType = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.ResId)
                .ForeignKey("dbo.AeroPlaneInfoes", t => t.PlaneId, cascadeDelete: true)
                .Index(t => t.PlaneId);
            
            CreateTable(
                "dbo.TblFlightBook",
                c => new
                    {
                        bid = c.Int(nullable: false, identity: true),
                        BCusName = c.String(nullable: false),
                        bCusAddress = c.String(nullable: false),
                        bCusEmail = c.String(nullable: false),
                        bCusSeats = c.String(nullable: false),
                        bCusPhoneNum = c.String(nullable: false),
                        AdharNumber = c.String(nullable: false),
                        ResId = c.String(),
                        TicketReserve_tbls_ResId = c.Int(),
                    })
                .PrimaryKey(t => t.bid)
                .ForeignKey("dbo.TicketReserve_tbl", t => t.TicketReserve_tbls_ResId)
                .Index(t => t.TicketReserve_tbls_ResId);
            
            CreateTable(
                "dbo.BookingDetailsDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        FirstName = c.String(),
                        LastName = c.String(),
                        bCusPhoneNum = c.String(),
                        AdharNumber = c.String(),
                        ResTicketPrice = c.Single(nullable: false),
                        Resfrom = c.String(),
                        ResTo = c.String(),
                        Time = c.String(),
                        Date = c.String(),
                        TicketReserve_tbls_ResId = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .ForeignKey("dbo.TicketReserve_tbl", t => t.TicketReserve_tbls_ResId)
                .Index(t => t.CustomerId)
                .Index(t => t.TicketReserve_tbls_ResId);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        CustomerId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        bCusPhoneNum = c.String(nullable: false),
                        AdharNumber = c.String(nullable: false),
                        TicketReservation_ResId = c.Int(),
                    })
                .PrimaryKey(t => t.CustomerId)
                .ForeignKey("dbo.TicketReserve_tbl", t => t.TicketReservation_ResId)
                .Index(t => t.TicketReservation_ResId);
            
            CreateTable(
                "dbo.TblUserAccount",
                c => new
                    {
                        UserID = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 20),
                        LastName = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 20),
                        Password = c.String(nullable: false, maxLength: 20),
                        Age = c.Int(nullable: false),
                        Phoneno = c.String(nullable: false),
                        AdharNumber = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.UserID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BookingDetailsDatas", "TicketReserve_tbls_ResId", "dbo.TicketReserve_tbl");
            DropForeignKey("dbo.BookingDetailsDatas", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "TicketReservation_ResId", "dbo.TicketReserve_tbl");
            DropForeignKey("dbo.TblFlightBook", "TicketReserve_tbls_ResId", "dbo.TicketReserve_tbl");
            DropForeignKey("dbo.TicketReserve_tbl", "PlaneId", "dbo.AeroPlaneInfoes");
            DropIndex("dbo.Customers", new[] { "TicketReservation_ResId" });
            DropIndex("dbo.BookingDetailsDatas", new[] { "TicketReserve_tbls_ResId" });
            DropIndex("dbo.BookingDetailsDatas", new[] { "CustomerId" });
            DropIndex("dbo.TblFlightBook", new[] { "TicketReserve_tbls_ResId" });
            DropIndex("dbo.TicketReserve_tbl", new[] { "PlaneId" });
            DropTable("dbo.TblUserAccount");
            DropTable("dbo.Customers");
            DropTable("dbo.BookingDetailsDatas");
            DropTable("dbo.TblFlightBook");
            DropTable("dbo.TicketReserve_tbl");
            DropTable("dbo.AeroPlaneInfoes");
            DropTable("dbo.TblAdminLogin");
        }
    }
}
