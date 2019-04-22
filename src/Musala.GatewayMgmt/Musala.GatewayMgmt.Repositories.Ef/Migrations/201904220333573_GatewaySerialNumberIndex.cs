namespace Musala.GatewayMgmt.Repositories.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GatewaySerialNumberIndex : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Gateways", "SerialNumber", c => c.String(nullable: false, maxLength: 50));
            CreateIndex("dbo.Gateways", "SerialNumber", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Gateways", new[] { "SerialNumber" });
            AlterColumn("dbo.Gateways", "SerialNumber", c => c.String());
        }
    }
}
