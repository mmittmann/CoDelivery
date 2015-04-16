namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CriacaoTabelaMigrationRecipe : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.RecipeIntegration", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.RecipeIntegration", "Integration_Id", "dbo.Integration");
            DropIndex("dbo.RecipeIntegration", new[] { "Recipe_Id" });
            DropIndex("dbo.RecipeIntegration", new[] { "Integration_Id" });
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
            
            DropTable("dbo.RecipeIntegration");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.RecipeIntegration",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Integration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Integration_Id });
            
            DropForeignKey("dbo.IntegrationRecipe", "Recipe_Id", "dbo.Recipe");
            DropForeignKey("dbo.IntegrationRecipe", "Integration_Id", "dbo.Integration");
            DropIndex("dbo.IntegrationRecipe", new[] { "Recipe_Id" });
            DropIndex("dbo.IntegrationRecipe", new[] { "Integration_Id" });
            DropTable("dbo.IntegrationRecipe");
            CreateIndex("dbo.RecipeIntegration", "Integration_Id");
            CreateIndex("dbo.RecipeIntegration", "Recipe_Id");
            AddForeignKey("dbo.RecipeIntegration", "Integration_Id", "dbo.Integration", "Id", cascadeDelete: true);
            AddForeignKey("dbo.RecipeIntegration", "Recipe_Id", "dbo.Recipe", "Id", cascadeDelete: true);
        }
    }
}
