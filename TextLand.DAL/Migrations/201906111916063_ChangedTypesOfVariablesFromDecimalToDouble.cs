namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedTypesOfVariablesFromDecimalToDouble : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "AccountForAddingOrders", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "AccountForCompletedOrders", c => c.Double(nullable: false));
            AlterColumn("dbo.Users", "Rating", c => c.Double(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Rating", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "AccountForCompletedOrders", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Users", "AccountForAddingOrders", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
