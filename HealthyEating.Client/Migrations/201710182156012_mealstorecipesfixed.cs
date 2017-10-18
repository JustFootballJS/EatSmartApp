namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mealstorecipesfixed : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "Meal_Id", "dbo.Meals");
            DropIndex("dbo.Recipes", new[] { "Meal_Id" });
            CreateTable(
                "dbo.RecipeMeals",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Meal_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Meal_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Meals", t => t.Meal_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Meal_Id);
            
            DropColumn("dbo.Recipes", "Meal_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Recipes", "Meal_Id", c => c.Int());
            DropForeignKey("dbo.RecipeMeals", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.RecipeMeals", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeMeals", new[] { "Meal_Id" });
            DropIndex("dbo.RecipeMeals", new[] { "Recipe_Id" });
            DropTable("dbo.RecipeMeals");
            CreateIndex("dbo.Recipes", "Meal_Id");
            AddForeignKey("dbo.Recipes", "Meal_Id", "dbo.Meals", "Id");
        }
    }
}
