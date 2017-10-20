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
        private readonly IUserManager userManager;
        private readonly IRecipeManager recipeManager;
        public CreateRecipeCommand(IReader reader, IWriter writer,IUserManager userManager, IRecipeManager recipeManager)
            :base(reader,writer)
        {
            Guard.WhenArgument(userManager, "userManager").IsNull().Throw();
            Guard.WhenArgument(recipeManager, "recipeManager").IsNull().Throw();


            this.userManager = userManager;
            
            this.recipeManager = recipeManager;
           
        }
        public override string Execute()
        {
            var parameters = TakeInput();
            var name = parameters[0];
            var names = parameters[1];
            var counts = parameters[2];
            return this.recipeManager.CreateRecipe(name,counts,names);
        }
        private IList<string> TakeInput()
        {
            var name = base.ReadOneLine("Name: ");
            var ingredientNames = base.ReadOneLine("IngredientNames: ");
            var ingredientQuantities = base.ReadOneLine("IngredientQuantaties: ");

            return new List<string>() { name, ingredientNames, ingredientQuantities };
        }
    }
}