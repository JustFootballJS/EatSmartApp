using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands
{
    public class CreateRecipeCommand : ICommand
    {
        private readonly IDatabase db;
        private readonly IModelFactory factory;
        public CreateRecipeCommand(IDatabase db, IModelFactory factory)
        {
            this.db = db;
            this.factory = factory;
        }
        public string Execute(IList<string> commandLine)
        {
            string name;
            string ingredients;

            try
            {
                name = commandLine[0];
                ingredients = commandLine[1];
            }
            catch
            {
                throw new ArgumentException("Failed to parse Recipe command parameters.");
            }
            var recipe = factory.CreateRecipe(name, ingredients);
            db.Recipes.Add(recipe);

            return $"Recipe with ID {db.Recipes.Count - 1} was created.";
        }
    }
}
