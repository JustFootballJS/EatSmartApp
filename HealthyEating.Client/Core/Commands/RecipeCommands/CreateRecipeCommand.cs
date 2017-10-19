using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands
{
    public class CreateRecipeCommand : ICommand
    {
        //private readonly IDatabase db;
        private readonly HealthyEatingContext dbContext;
        private readonly IModelFactory factory;
        private readonly IUserManager userManager;
        public CreateRecipeCommand(HealthyEatingContext dbContext, IModelFactory factory, IUserManager userManager)
        {
            //this.db = db;
            this.userManager = userManager;
            this.dbContext = dbContext;
            this.factory = factory;
        }
        public string Execute()
        {
            //string name;
            //string ingredients;

            //try
            //{
            //    name = commandLine[0];
            //    ingredients = commandLine[1];
            //}
            //catch
            //{
            //    throw new ArgumentException("Failed to parse Recipe command parameters.");
            //}
            //var ingredient = dbContext.Ingredients.SingleOrDefault(x =>x.Name == )
            //var recipe = factory.CreateRecipe(name, ingredients);
            //userManager.LoggedUser.Recipes.Add(recipe);
            ////dbContext.Recipes.Add(recipe);
            //dbContext.SaveChanges();
            //return $"Recipe with ID {dbContext.Recipes.Count()} was created.";
            return "";
        }
    }
}