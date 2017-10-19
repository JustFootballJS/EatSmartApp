using Bytes2you.Validation;
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
    public class CreateRecipeCommand : Command, ICommand
    {
        
        private readonly HealthyEatingContext db;
        private readonly IRecipeManager recipeManager;
        public CreateRecipeCommand(IWriter writer, IReader reader, HealthyEatingContext db, IModelFactory factory, IRecipeManager recipeManager)
            :base(reader, writer)
        {
            Guard.WhenArgument(factory, "factory").IsNull().Throw();
            Guard.WhenArgument(db, "db").IsNull().Throw();
            Guard.WhenArgument(recipeManager, "recipeManager").IsNull().Throw();
            
            this.recipeManager = recipeManager;
            this.db = db;
            
        }
        
        public override string Execute(IList<string> commandLine)
        {
            var ingredients = new List<Ingredient>();
            var parameters = TakeInput();
            var name = commandLine[0];
            ICollection<string> ingredientNames = commandLine[1].Split(' ');

            foreach (var ingredient in ingredientNames)
            {
                ingredients.Add(db.Ingredients.Where(x => x.Name == ingredient).SingleOrDefault());
            }

            return this.recipeManager.CreateRecipe(name, ingredients);
        }
        private IList<string> TakeInput()
        {
            var recipeName = ReadOneLine("Recipe name: ");
            var ingredientNames = ReadOneLine("Ingredients: ");
            
            return new List<string>() { recipeName, ingredientNames };
        }
    }
}