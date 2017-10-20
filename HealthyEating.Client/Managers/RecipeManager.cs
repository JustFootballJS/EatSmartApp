using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Managers
{
    public class RecipeManager : IRecipeManager
    {
        private readonly IDatabase database;
        private readonly IModelFactory modelFactory;
        private readonly IUserManager userManager;

        public RecipeManager(IDatabase database, IModelFactory modelFactory, IUserManager userManager)
        {
            this.database = database;
            this.modelFactory = modelFactory;
            this.userManager = userManager;
        }

        public string CreateRecipe(string name, string quanitites, string ingredients)
        {
            var ingredientsAsObjects = ingredients.Split(',').Select(x =>
             {
                 return this.database.Ingredients.Single(y => y.Name == x);
 
             }).ToList();
            var quantitestAsList = quanitites.Split(',').ToList();
            if (quantitestAsList.Count != ingredientsAsObjects.Count)
            {
                throw new ArgumentException("Invalid count");
            }
            var quantityObjects = new List<Quantity>();
            for (int i = 0; i < quantitestAsList.Count; i++)
            {
                quantityObjects.Add(this.modelFactory.CreateQuantity(ingredientsAsObjects[i], quantitestAsList[i]));
            }

           var recipe= EstimateNutritions(this.modelFactory.CreateRecipe(name, quantityObjects));

            this.userManager.LoggedUser.Recipes.Add(recipe);
            this.database.Users.Single(x => x.Id == this.userManager.LoggedUser.Id).Recipes.Add(recipe);
            this.database.SaveChanges();
            return $"Recipe {recipe.Name} was created";
        }
        public string DeleteRecipe(string name)
        {
            var recipe = this.database.Recipes.Single(x => x.Name == name);
            this.database.Recipes.Remove(recipe);
            this.database.SaveChanges();
            return "Deleted!";
        }
        public Recipe EstimateNutritions(Recipe recipe)
        {
            recipe.KCAL = recipe.Quantities.Sum(x => x.QuantityValue * x.Ingredient.KCAL);
            recipe.Protein = recipe.Quantities.Sum(x => x.QuantityValue * x.Ingredient.Protein);
            recipe.Fibre = recipe.Quantities.Sum(x => x.QuantityValue * x.Ingredient.Fibre);
            recipe.Fat = recipe.Quantities.Sum(x => x.QuantityValue * x.Ingredient.Fat);
            recipe.Carbohydrate = recipe.Quantities.Sum(x => x.QuantityValue * x.Ingredient.Carbohydrate);
            return recipe;
        }
        public string RecipeAsString(string name)
        {
            var recipe=this.database.Recipes.Single(x => x.Name == name);
            return string.Concat("Name: ",recipe.Name,
                Environment.NewLine,
                "Kcal: ", recipe.KCAL,
                Environment.NewLine,
                "Protein:", recipe.Protein,
                Environment.NewLine,
                "Fat:",recipe.Fat,
                Environment.NewLine,
                "Carbs:",recipe.Carbohydrate,
                Environment.NewLine,
                "Fibre:",recipe.Fibre,
                Environment.NewLine,
                string.Join(Environment.NewLine,recipe.Quantities.Select(x=>$"{x.Ingredient.Name} - {x.QuantityValue}"))
                );
        }
    }
}
