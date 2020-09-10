namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myLastMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.About", "imagePath", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.About", "imagePath");
        }
    }
}
