namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMig4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "name", c => c.String());
            DropColumn("dbo.Contact", "headerOne");
            DropColumn("dbo.Contact", "headerTwo");
            DropColumn("dbo.Contact", "description");
            DropColumn("dbo.Contact", "location");
            DropColumn("dbo.Contact", "createdAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Contact", "createdAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Contact", "location", c => c.String());
            AddColumn("dbo.Contact", "description", c => c.String());
            AddColumn("dbo.Contact", "headerTwo", c => c.String());
            AddColumn("dbo.Contact", "headerOne", c => c.String());
            DropColumn("dbo.Contact", "name");
        }
    }
}
