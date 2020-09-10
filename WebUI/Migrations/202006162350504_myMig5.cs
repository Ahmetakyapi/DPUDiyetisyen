namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMig5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Contact", "message", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Contact", "message");
        }
    }
}
