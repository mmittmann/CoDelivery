namespace CoDelivery.Core.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdicionadaapropriedadeNAMEnasintegrações : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Integration", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Integration", "Name");
        }
    }
}
