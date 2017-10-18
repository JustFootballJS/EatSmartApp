namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopefullyfinal : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.RecipeIngredients", newName: "IngredientRecipes");
            DropPrimaryKey("dbo.IngredientRecipes");
            AddPrimaryKey("dbo.IngredientRecipes", new[] { "Ingredient_Id", "Recipe_Id" });
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.IngredientRecipes");
            AddPrimaryKey("dbo.IngredientRecipes", new[] { "Recipe_Id", "Ingredient_Id" });
            RenameTable(name: "dbo.IngredientRecipes", newName: "RecipeIngredients");
        }
    }
}
