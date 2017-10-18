namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _fixed : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Meals", new[] { "user_Id" });
            CreateIndex("dbo.Meals", "User_Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Meals", new[] { "User_Id" });
            CreateIndex("dbo.Meals", "user_Id");
        }
    }
}
