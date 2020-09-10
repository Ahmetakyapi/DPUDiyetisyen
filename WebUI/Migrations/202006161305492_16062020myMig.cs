namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _16062020myMig : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProposalContext", "imagePath", c => c.String());
            DropColumn("dbo.ProposalContext", "foodTime");
            DropColumn("dbo.ProposalContext", "forWhoPerson");
            DropColumn("dbo.ProposalContext", "showMainPage");
            DropColumn("dbo.ProposalContext", "userId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProposalContext", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.ProposalContext", "showMainPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProposalContext", "forWhoPerson", c => c.Int(nullable: false));
            AddColumn("dbo.ProposalContext", "foodTime", c => c.String());
            DropColumn("dbo.ProposalContext", "imagePath");
        }
    }
}
