namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangedRecuiredProperties : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Orders", "KeyWords", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Email", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Password", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "Surname", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "Surname", c => c.String());
            AlterColumn("dbo.Users", "Name", c => c.String());
            AlterColumn("dbo.Users", "Password", c => c.String());
            AlterColumn("dbo.Users", "Email", c => c.String());
            AlterColumn("dbo.Orders", "KeyWords", c => c.String());
        }
    }
}
