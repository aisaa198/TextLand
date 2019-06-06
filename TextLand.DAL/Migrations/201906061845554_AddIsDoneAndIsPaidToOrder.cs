namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddIsDoneAndIsPaidToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "IsDone", c => c.Boolean(nullable: false));
            AddColumn("dbo.Orders", "IsPaid", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Orders", "Status", c => c.Boolean(nullable: false));
            DropColumn("dbo.Orders", "IsPaid");
            DropColumn("dbo.Orders", "IsDone");
        }
    }
}
