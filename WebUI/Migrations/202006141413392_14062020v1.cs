namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _14062020v1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.About",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        header = c.String(),
                        description = c.String(),
                        birthOfDate = c.String(),
                        cityName = c.String(),
                        favorites = c.String(),
                        workExperiences = c.String(),
                        userId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contact",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        headerOne = c.String(),
                        headerTwo = c.String(),
                        description = c.String(),
                        location = c.String(),
                        mail = c.String(),
                        phone = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProposalContext",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        header = c.String(),
                        description = c.String(),
                        foodTime = c.String(),
                        forWhoPerson = c.Int(nullable: false),
                        showMainPage = c.Boolean(nullable: false),
                        userId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProposalHeader",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        header = c.String(),
                        description = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        image_path = c.String(),
                        description = c.String(),
                        foodTime = c.String(),
                        forWhoPerson = c.Int(nullable: false),
                        showMainPage = c.Boolean(nullable: false),
                        userId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipesContents",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        recipesId = c.Int(nullable: false),
                        scale = c.String(),
                        name = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipesDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        recipesId = c.Int(nullable: false),
                        recipesContentId = c.Int(nullable: false),
                        description = c.String(),
                        userId = c.Int(nullable: false),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tbUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        surname = c.String(),
                        email = c.String(),
                        password = c.String(),
                        createdAt = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VisitorMessages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        mail = c.String(),
                        message = c.String(),
                        createdAt = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.tbLogin");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.tbLogin",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropTable("dbo.VisitorMessages");
            DropTable("dbo.tbUsers");
            DropTable("dbo.RecipesDetails");
            DropTable("dbo.RecipesContents");
            DropTable("dbo.Recipes");
            DropTable("dbo.ProposalHeader");
            DropTable("dbo.ProposalContext");
            DropTable("dbo.Contact");
            DropTable("dbo.About");
        }
    }
}
