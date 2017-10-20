namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class deletion : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients");
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Quantities", new[] { "IngredientId" });
            DropIndex("dbo.Quantities", new[] { "RecipeId" });
            AlterColumn("dbo.Recipes", "User_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Quantities", "IngredientId", c => c.Int(nullable: false));
            AlterColumn("dbo.Quantities", "RecipeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Recipes", "User_Id");
            CreateIndex("dbo.Quantities", "IngredientId");
            CreateIndex("dbo.Quantities", "RecipeId");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.Users", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.Users");
            DropIndex("dbo.Quantities", new[] { "RecipeId" });
            DropIndex("dbo.Quantities", new[] { "IngredientId" });
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            AlterColumn("dbo.Quantities", "RecipeId", c => c.Int());
            AlterColumn("dbo.Quantities", "IngredientId", c => c.Int());
            AlterColumn("dbo.Recipes", "User_Id", c => c.Int());
            CreateIndex("dbo.Quantities", "RecipeId");
            CreateIndex("dbo.Quantities", "IngredientId");
            CreateIndex("dbo.Recipes", "User_Id");
            AddForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients", "Id");
            AddForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes", "Id");
            AddForeignKey("dbo.Recipes", "User_Id", "dbo.Users", "Id");
        }
    }
}
