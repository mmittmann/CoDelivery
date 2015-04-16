namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DatabaseCreated : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Integration",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IntegrationSystem_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.IntegrationSystem", t => t.IntegrationSystem_Id)
                .Index(t => t.IntegrationSystem_Id);
            
            CreateTable(
                "dbo.IntegrationSystem",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.UserEntity",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Integration", "IntegrationSystem_Id", "dbo.IntegrationSystem");
            DropIndex("dbo.Integration", new[] { "IntegrationSystem_Id" });
            DropTable("dbo.UserEntity");
            DropTable("dbo.IntegrationSystem");
            DropTable("dbo.Integration");
        }
    }
}
