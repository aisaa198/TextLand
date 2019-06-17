namespace TextLand.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPayoff : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Payoffs",
                c => new
                    {
                        PayoffId = c.Int(nullable: false, identity: true),
                        Value = c.Double(nullable: false),
                        IsDone = c.Boolean(nullable: false),
                        RequestingUser_UserId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PayoffId)
                .ForeignKey("dbo.Users", t => t.RequestingUser_UserId, cascadeDelete: true)
                .Index(t => t.RequestingUser_UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Payoffs", "RequestingUser_UserId", "dbo.Users");
            DropIndex("dbo.Payoffs", new[] { "RequestingUser_UserId" });
            DropTable("dbo.Payoffs");
        }
    }
}
