namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fluentapifirst : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecipeMeals", newName: "MealRecipes");
            DropPrimaryKey("dbo.MealRecipes");
            AddPrimaryKey("dbo.MealRecipes", new[] { "Meal_Id", "Recipe_Id" });

            DropColumn("dbo.Recipes", "Meal_Id");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.MealRecipes");
            AddPrimaryKey("dbo.MealRecipes", new[] { "Recipe_Id", "Meal_Id" });
            RenameTable(name: "dbo.MealRecipes", newName: "RecipeMeals");
        }
    }
}
