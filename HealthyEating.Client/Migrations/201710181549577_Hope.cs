namespace HealthyEating.Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Hope : DbMigration
    {
        public override void Up()
        {
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
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RecipeIngredients",
                c => new
                    {
                        Recipe_Id = c.Int(nullable: false),
                        Ingredient_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recipe_Id, t.Ingredient_Id })
                .ForeignKey("dbo.Recipes", t => t.Recipe_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingredients", t => t.Ingredient_Id, cascadeDelete: true)
                .Index(t => t.Recipe_Id)
                .Index(t => t.Ingredient_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.RecipeIngredients", "Ingredient_Id", "dbo.Ingredients");
            DropForeignKey("dbo.RecipeIngredients", "Recipe_Id", "dbo.Recipes");
            DropIndex("dbo.RecipeIngredients", new[] { "Ingredient_Id" });
            DropIndex("dbo.RecipeIngredients", new[] { "Recipe_Id" });
            DropTable("dbo.RecipeIngredients");
            DropTable("dbo.Recipes");
            DropTable("dbo.Ingredients");
        }
    }
}
