namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class hopeforquantity : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.IngredientRecipes", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.IngredientRecipes", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.IngredientRecipes", new[] { "Ingredient_Id" });
            DropIndex("dbo.IngredientRecipes", new[] { "Recipe_Id" });
            CreateTable(
                "dbo.Quantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(),
                        RecipeId = c.Int(),
                        QuantityValue = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId);
            
            DropTable("dbo.IngredientRecipes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.IngredientRecipes",
                c => new
                    {
                        Ingredient_Id = c.Int(nullable: false),
                        Recipe_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Ingredient_Id, t.Recipe_Id });
            
            DropForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Quantities", new[] { "RecipeId" });
            DropIndex("dbo.Quantities", new[] { "IngredientId" });
            DropTable("dbo.Quantities");
            CreateIndex("dbo.IngredientRecipes", "Recipe_Id");
            CreateIndex("dbo.IngredientRecipes", "Ingredient_Id");
            AddForeignKey("dbo.IngredientRecipes", "Recipe_Id", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.IngredientRecipes", "Ingredient_Id", "dbo.Ingredients", "Id", cascadeDelete: true);
        }
    }
}
