namespace Musala.GatewayMgmt.Repositories.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Devices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UID = c.Long(nullable: false),
                        Vendor = c.String(nullable: false, maxLength: 30),
                        Status = c.Int(nullable: false),
                        DateCreated = c.DateTime(nullable: false),
                        GatewayId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Gateways", t => t.GatewayId, cascadeDelete: true)
                .Index(t => t.GatewayId);
            
            CreateTable(
                "dbo.Gateways",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SerialNumber = c.String(),
                        Name = c.String(nullable: false, maxLength: 30),
                        IPv4 = c.String(nullable: false, maxLength: 15),
                        DateCreated = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Devices", "GatewayId", "dbo.Gateways");
            DropIndex("dbo.Devices", new[] { "GatewayId" });
            DropTable("dbo.Gateways");
            DropTable("dbo.Devices");
        }
    }
}
