namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrecipe3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Recipe", "User_Id", c => c.Int());
            CreateIndex("dbo.Recipe", "User_Id");
            AddForeignKey("dbo.Recipe", "User_Id", "dbo.User", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipe", "User_Id", "dbo.User");
            DropIndex("dbo.Recipe", new[] { "User_Id" });
            DropColumn("dbo.Recipe", "User_Id");
        }
    }
}
