namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class users : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Username = c.String(),
                        Password = c.String(),
                        CurrentWeight = c.Double(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MaxKcal = c.Int(nullable: false),
                        WantedWeight = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        mealCategory = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        user_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.user_Id)
                .Index(t => t.user_Id);
            
            AddColumn("dbo.Recipes", "Meal_Id", c => c.Int());
            AddColumn("dbo.Recipes", "User_Id", c => c.Int());
            CreateIndex("dbo.Recipes", "Meal_Id");
            CreateIndex("dbo.Recipes", "User_Id");
            AddForeignKey("dbo.Recipes", "Meal_Id", "dbo.Meals", "Id");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.Users", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Meals", "user_Id", "dbo.Users");
            DropForeignKey("dbo.Recipes", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.Goals", "User_Id", "dbo.Users");
            DropIndex("dbo.Meals", new[] { "user_Id" });
            DropIndex("dbo.Goals", new[] { "User_Id" });
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Recipes", new[] { "Meal_Id" });
            DropColumn("dbo.Recipes", "User_Id");
            DropColumn("dbo.Recipes", "Meal_Id");
            DropTable("dbo.Meals");
            DropTable("dbo.Goals");
            DropTable("dbo.Users");
        }
    }
}
