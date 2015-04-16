namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addrecipe2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.Integration", new[] { "Recipe_Id" });
            DropPrimaryKey("dbo.Recipe");
            AlterColumn("dbo.Integration", "Recipe_Id", c => c.Int());
            AlterColumn("dbo.Recipe", "Id", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("dbo.Recipe", "Id");
            CreateIndex("dbo.Integration", "Recipe_Id");
            AddForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe");
            DropIndex("dbo.Integration", new[] { "Recipe_Id" });
            DropPrimaryKey("dbo.Recipe");
            AlterColumn("dbo.Recipe", "Id", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Integration", "Recipe_Id", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Recipe", "Id");
            CreateIndex("dbo.Integration", "Recipe_Id");
            AddForeignKey("dbo.Integration", "Recipe_Id", "dbo.Recipe", "Id");
        }
    }
}
