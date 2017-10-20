using HealthyEating.Client.Core.Contracts;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Commands.IngredientCommands
{
    public class DeleteIngredientCommand : Command, ICommand

    {
        private readonly IIngredientManager ingredientManager;
        public DeleteIngredientCommand(IReader reader,IWriter writer, IIngredientManager ingredientManager)
            :base(reader,writer)
        {
            this.ingredientManager = ingredientManager;
        }
        public override string Execute()
        {
            var parameters = TakeInput();
            var name = parameters[0];

            return this.ingredientManager.Delete(name);
        }
        private IList<string> TakeInput()
        {
            var name = base.ReadOneLine("Name: ");
            return new List<string>() { name };
        }
    }
}
