namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Goals",
                c => new
                    {
                        UserId = c.Int(nullable: false),
                        MaxKcal = c.Int(nullable: false),
                        WantedWeight = c.Int(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.Users", t => t.UserId)
                .Index(t => t.UserId);
            
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
                "dbo.Meals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MealCategory = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        isDeleted = c.Boolean(nullable: false),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Recipes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KCAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carbohydrate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fibre = c.Decimal(nullable: false, precision: 18, scale: 2),
                        User_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Users", t => t.User_Id)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.Quantities",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IngredientId = c.Int(),
                        RecipeId = c.Int(),
                        QuantityValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Ingredients", t => t.IngredientId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId)
                .Index(t => t.IngredientId)
                .Index(t => t.RecipeId);
            
            CreateTable(
                "dbo.Ingredients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        KCAL = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Protein = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fat = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Carbohydrate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Fibre = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.Id);
            
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Goals", "UserId", "dbo.Users");
            DropForeignKey("dbo.Recipes", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Meals", "User_Id", "dbo.Users");
            DropForeignKey("dbo.Quantities", "RecipeId", "dbo.Recipes");
            DropForeignKey("dbo.Quantities", "IngredientId", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeMeals", "Meal_Id", "dbo.Meals");
            DropForeignKey("dbo.RecipeMeals", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeMeals", new[] { "Meal_Id" });
            DropIndex("dbo.RecipeMeals", new[] { "Recipe_Id" });
            DropIndex("dbo.Quantities", new[] { "RecipeId" });
            DropIndex("dbo.Quantities", new[] { "IngredientId" });
            DropIndex("dbo.Recipes", new[] { "User_Id" });
            DropIndex("dbo.Meals", new[] { "User_Id" });
            DropIndex("dbo.Goals", new[] { "UserId" });
            DropTable("dbo.RecipeMeals");
            DropTable("dbo.Ingredients");
            DropTable("dbo.Quantities");
            DropTable("dbo.Recipes");
            DropTable("dbo.Meals");
            DropTable("dbo.Users");
            DropTable("dbo.Goals");
        }
    }
}
