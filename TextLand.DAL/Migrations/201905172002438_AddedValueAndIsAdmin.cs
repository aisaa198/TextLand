namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedValueAndIsAdmin : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Value", c => c.Double(nullable: false));
            AddColumn("dbo.Users", "IsAdmin", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "IsAdmin");
            DropColumn("dbo.Orders", "Value");
        }
    }
}
