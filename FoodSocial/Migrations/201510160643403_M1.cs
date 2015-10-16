namespace FoodSocial.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class M1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.tblBAICHIASE", "longitude", c => c.String());
            AddColumn("dbo.tblBAICHIASE", "latitude", c => c.String());
            DropColumn("dbo.tblCOMMENT", "vote");
        }
        
        public override void Down()
        {
            AddColumn("dbo.tblCOMMENT", "vote", c => c.Int(nullable: false));
            DropColumn("dbo.tblBAICHIASE", "latitude");
            DropColumn("dbo.tblBAICHIASE", "longitude");
        }
    }
}
