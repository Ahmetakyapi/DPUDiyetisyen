namespace WebUI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMig : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.tbLogin");
        }
    }
}
