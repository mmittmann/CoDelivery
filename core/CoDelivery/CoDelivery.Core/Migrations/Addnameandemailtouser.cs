namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addnameandemailtouser : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.UserEntity", "Email", c => c.String());
            AddColumn("dbo.UserEntity", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.UserEntity", "Name");
            DropColumn("dbo.UserEntity", "Email");
        }
    }
}
