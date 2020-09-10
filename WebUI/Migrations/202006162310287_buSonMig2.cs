namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class buSonMig2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipes", "name", c => c.String());
            AddColumn("dbo.Recipes", "imagePath", c => c.String());
            AddColumn("dbo.Recipes", "content", c => c.String());
            DropColumn("dbo.Recipes", "image_path");
            DropColumn("dbo.Recipes", "showMainPage");
            DropColumn("dbo.Recipes", "userId");
            DropColumn("dbo.Recipes", "createdAt");
            DropColumn("dbo.RecipesContents", "createdAt");
            DropTable("dbo.RecipesDetails");
        }
        
        public override void Down()
        {
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
            
            AddColumn("dbo.RecipesContents", "createdAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "createdAt", c => c.DateTime(nullable: false));
            AddColumn("dbo.Recipes", "userId", c => c.Int(nullable: false));
            AddColumn("dbo.Recipes", "showMainPage", c => c.Boolean(nullable: false));
            AddColumn("dbo.Recipes", "image_path", c => c.String());
            DropColumn("dbo.Recipes", "content");
            DropColumn("dbo.Recipes", "imagePath");
            DropColumn("dbo.Recipes", "name");
        }
    }
}
