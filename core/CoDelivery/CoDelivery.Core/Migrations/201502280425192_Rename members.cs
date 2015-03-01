namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Renamemembers : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.IntegrationSystem", newName: "IntegrationSystemEntity");
            DropForeignKey("dbo.Integration", "IntegrationSystem_Id", "dbo.IntegrationSystem");
            DropIndex("dbo.Integration", new[] { "IntegrationSystem_Id" });
            CreateTable(
                "dbo.IntegrationEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntegrationSystem_Id = c.Int(),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IntegrationSystemEntity", t => t.IntegrationSystem_Id)
                .ForeignKey("dbo.UserEntity", t => t.User_Id)
                .Index(t => t.IntegrationSystem_Id)
                .Index(t => t.User_Id);
            
            DropTable("dbo.Integration");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Integration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntegrationSystem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.IntegrationEntity", "User_Id", "dbo.UserEntity");
            DropForeignKey("dbo.IntegrationEntity", "IntegrationSystem_Id", "dbo.IntegrationSystemEntity");
            DropIndex("dbo.IntegrationEntity", new[] { "User_Id" });
            DropIndex("dbo.IntegrationEntity", new[] { "IntegrationSystem_Id" });
            DropTable("dbo.IntegrationEntity");
            CreateIndex("dbo.Integration", "IntegrationSystem_Id");
            AddForeignKey("dbo.Integration", "IntegrationSystem_Id", "dbo.IntegrationSystem", "Id");
            RenameTable(name: "dbo.IntegrationSystemEntity", newName: "IntegrationSystem");
        }
    }
}
