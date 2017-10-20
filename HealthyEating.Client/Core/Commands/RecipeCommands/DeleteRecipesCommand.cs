using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.RecipeCommands
{
    public class DeleteRecipesCommand : Command, ICommand
    {
        private readonly IRecipeManager recipeManager;
        public DeleteRecipesCommand(IReader reader, IWriter writer,IRecipeManager recipeManager)
            : base(reader, writer)
        {
            this.recipeManager = recipeManager;
        }
        public override string Execute()
        {
            var parameters = TakeInput();
            var name = parameters[0];
            return this.recipeManager.DeleteRecipe(name);
        }
        private IList<string> TakeInput()
        {
            var name = base.ReadOneLine("Name: ");
            return new List<string>() { name };
        }
    }
}
