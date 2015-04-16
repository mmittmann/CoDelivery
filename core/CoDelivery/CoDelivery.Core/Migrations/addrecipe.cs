namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrecipe : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IntegrationEntity", newName: "Integration");
            RenameTable(name: "dbo.IntegrationSystemEntity", newName: "IntegrationSystem");
            RenameTable(name: "dbo.UserEntity", newName: "User");
            CreateTable(
                "dbo.Recipe",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Integration", "Recipe_Id", c => c.String(maxLength: 128));
            CreateIndex("dbo.Integration", "Recipe_Id");
            AddForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.Integration", new[] { "Recipe_Id" });
            DropColumn("dbo.Integration", "Recipe_Id");
            DropTable("dbo.Recipe");
            RenameTable(name: "dbo.User", newName: "UserEntity");
            RenameTable(name: "dbo.IntegrationSystem", newName: "IntegrationSystemEntity");
            RenameTable(name: "dbo.Integration", newName: "IntegrationEntity");
        }
    }
}
