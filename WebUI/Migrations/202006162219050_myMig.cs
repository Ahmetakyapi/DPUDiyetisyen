namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class myMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProposalHeader", "name", c => c.String());
            DropColumn("dbo.ProposalHeader", "header");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProposalHeader", "header", c => c.String());
            DropColumn("dbo.ProposalHeader", "name");
        }
    }
}
