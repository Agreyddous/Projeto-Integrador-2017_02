namespace Projeto.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Bikes",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Latitude = c.String(nullable: false),
                        Longitude = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usages",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        StartDate = c.DateTime(nullable: false),
                        EndDate = c.DateTime(nullable: false),
                        Distance = c.Double(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Bike_Id = c.Guid(nullable: false),
                        User_Id = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Bikes", t => t.Bike_Id, cascadeDelete: true)
                .ForeignKey("dbo.Users", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.Bike_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 15),
                        LastName = c.String(nullable: false, maxLength: 15),
                        ProfilePic = c.String(nullable: false),
                        Odometer = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Usages", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Usages", "Bike_Id", "dbo.Bikes");
            DropIndex("dbo.Usages", new[] { "User_Id" });
            DropIndex("dbo.Usages", new[] { "Bike_Id" });
            DropTable("dbo.Users");
            DropTable("dbo.Usages");
            DropTable("dbo.Bikes");
        }
    }
}
