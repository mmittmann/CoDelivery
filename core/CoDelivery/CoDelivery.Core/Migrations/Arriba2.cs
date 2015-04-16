namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Arriba2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.Integration", new[] { "Recipe_Id" });
            CreateTable(
                "dbo.RecipeIntegration",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Integration_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Integration_Id })
                .ForeignKey("dbo.Recipe", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Integration", t => t.Integration_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Integration_Id);
            
            AddColumn("dbo.Integration", "SettingsJson", c => c.String());
            DropColumn("dbo.Integration", "Recipe_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Integration", "Recipe_Id", c => c.Int());
            DropForeignKey("dbo.RecipeIntegration", "Integration_Id", "dbo.Integration");
            DropForeignKey("dbo.RecipeIntegration", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.RecipeIntegration", new[] { "Integration_Id" });
            DropIndex("dbo.RecipeIntegration", new[] { "Recipe_Id" });
            DropColumn("dbo.Integration", "SettingsJson");
            DropTable("dbo.RecipeIntegration");
            CreateIndex("dbo.Integration", "Recipe_Id");
            AddForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe", "Id");
        }
    }
}
