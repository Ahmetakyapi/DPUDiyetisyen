namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buSonMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProposalContext", "name", c => c.String());
            DropColumn("dbo.ProposalContext", "header");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProposalContext", "header", c => c.String());
            DropColumn("dbo.ProposalContext", "name");
        }
    }
}
