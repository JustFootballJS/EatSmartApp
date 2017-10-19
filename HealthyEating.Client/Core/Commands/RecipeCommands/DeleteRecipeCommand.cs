using Bytes2you.Validation;
using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.RecipeCommands
{
    public class DeleteRecipeCommand : Command, ICommand
    {
        private readonly IRecipeManager recipeManager;
        private readonly HealthyEatingContext db;
        public DeleteRecipeCommand(IReader reader, IWriter writer, IRecipeManager recipeManager, HealthyEatingContext db) : base(reader, writer)
        {
            Guard.WhenArgument(db, "db").IsNull().Throw();
            Guard.WhenArgument(recipeManager, "recipeManager").IsNull().Throw();

            this.recipeManager = recipeManager;
            this.db = db;
        }

        public override string Execute(IList<string> commandLine)
        {
            var parameters = TakeInput();
            var Id = int.Parse(parameters[0]);

            return recipeManager.DeleteRecipe(Id);
        }
        private IList<string> TakeInput()
        {
            var recipeId = ReadOneLine("Recipe Id: ");
            
            return new List<string>() { recipeId };
        }

    }
}
