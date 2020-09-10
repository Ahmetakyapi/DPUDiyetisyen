namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class insLastMig : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProposalContext", "createdAt");
            DropColumn("dbo.ProposalHeader", "createdAt");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProposalHeader", "createdAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProposalContext", "createdAt", c => c.DateTime(nullable: false));
        }
    }
}
