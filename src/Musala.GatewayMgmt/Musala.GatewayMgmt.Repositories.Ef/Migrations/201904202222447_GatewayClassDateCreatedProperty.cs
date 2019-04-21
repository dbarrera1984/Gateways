namespace Musala.GatewayMgmt.Repositories.Ef.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class GatewayClassDateCreatedProperty : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Gateways", "DateCreated");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Gateways", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
