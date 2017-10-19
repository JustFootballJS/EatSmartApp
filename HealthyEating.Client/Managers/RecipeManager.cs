using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyEating.Client.Models;
using HealthyEating.Client.Data;
using Bytes2you.Validation;

namespace HealthyEating.Client.Managers
{
    public class RecipeManager : IRecipeManager
    {
        private readonly HealthyEatingContext db;
        private readonly IModelFactory factory;
        public RecipeManager(HealthyEatingContext db, IModelFactory factory)
        {
            Guard.WhenArgument(db, "db").IsNull().Throw();
            Guard.WhenArgument(factory, "factory").IsNull().Throw();

            this.factory = factory;
            this.db = db;
        }
        public string CreateRecipe(string name, ICollection<Ingredient> ingredients)
        {
            Guard.WhenArgument(name, "name").IsNullOrEmpty().Throw();
            Guard.WhenArgument(ingredients, "ingredients").IsNullOrEmpty().Throw();

            var recipe = factory.CreateRecipe(name, ingredients);
            db.Recipes.Add(recipe);

            return $"Recipe {name} was created successfully";
        }

        public string DeleteRecipe(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            var recipeID = db.Recipes.Where(x => x.Id == id).SingleOrDefault();
            recipeID.IsDeleted = true;

            return $"Recipe with ID {recipeID} was deleted.";
        }

        public string ReadRecipe(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            var recipeID = db.Recipes.Where(x => x.Id == id).SingleOrDefault();

            return UserAsString(recipeID.Id);
        }
        public string UserAsString(int id)
        {
            Guard.WhenArgument(id, "id").IsLessThan(0).Throw();

            var recipe = db.Recipes.Single(x => x.Id == id);

            return string.Concat(
                $"Recipe name: {recipe.Name}",
                Environment.NewLine,
                $"Ingredients: ",
                Environment.NewLine,
                string.Join(Environment.NewLine, recipe.Ingredients),
                Environment.NewLine
                );
        }
    }
}
