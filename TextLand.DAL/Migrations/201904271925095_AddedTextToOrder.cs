namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedTextToOrder : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Orders", "Content", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Orders", "Content");
        }
    }
}
