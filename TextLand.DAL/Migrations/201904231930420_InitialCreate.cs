namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        TypeOfText = c.Int(nullable: false),
                        Informations = c.String(),
                        KeyWords = c.String(),
                        NumberOfCharacters = c.Int(nullable: false),
                        Status = c.Boolean(nullable: false),
                        AddingUser_UserId = c.Int(nullable: false),
                        ExecutingUser_UserId = c.Int(),
                    })
                .PrimaryKey(t => t.OrderId)
                .ForeignKey("dbo.Users", t => t.AddingUser_UserId)
                .ForeignKey("dbo.Users", t => t.ExecutingUser_UserId)
                .Index(t => t.AddingUser_UserId)
                .Index(t => t.ExecutingUser_UserId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        UserId = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        Address = c.String(),
                        AccountForAddingOrders = c.Decimal(nullable: false, precision: 18, scale: 2),
                        AccountForCompletedOrders = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Rating = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "ExecutingUser_UserId", "dbo.Users");
            DropForeignKey("dbo.Orders", "AddingUser_UserId", "dbo.Users");
            DropIndex("dbo.Orders", new[] { "ExecutingUser_UserId" });
            DropIndex("dbo.Orders", new[] { "AddingUser_UserId" });
            DropTable("dbo.Users");
            DropTable("dbo.Orders");
        }
    }
}
