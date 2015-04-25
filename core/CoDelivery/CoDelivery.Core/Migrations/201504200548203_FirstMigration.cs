namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FirstMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Integration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        IntegrationSystem = c.Int(nullable: false),
                        SettingsJson = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.IntegrationRecipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ConfigurationsJson = c.String(),
                        Integration_Id = c.Int(),
                        Recipe_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Integration", t => t.Integration_Id)
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id)
                .Index(t => t.Integration_Id)
                .Index(t => t.Recipe_Id);
            
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.User", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.User",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                        Email = c.String(),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "User_Id", "dbo.User");
            DropForeignKey("dbo.Integration", "User_Id", "dbo.User");
            DropForeignKey("dbo.IntegrationRecipe", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.IntegrationRecipe", "Integration_Id", "dbo.Integration");
            DropIndex("dbo.Recipe", new[] { "User_Id" });
            DropIndex("dbo.IntegrationRecipe", new[] { "Recipe_Id" });
            DropIndex("dbo.IntegrationRecipe", new[] { "Integration_Id" });
            DropIndex("dbo.Integration", new[] { "User_Id" });
            DropTable("dbo.User");
            DropTable("dbo.Recipe");
            DropTable("dbo.IntegrationRecipe");
            DropTable("dbo.Integration");
        }
    }
}
