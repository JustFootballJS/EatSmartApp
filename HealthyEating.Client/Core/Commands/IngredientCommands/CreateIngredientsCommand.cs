using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands
{
   public class CreateIngredientsCommand:Command, ICommand
    {
        private readonly IIngredientManager ingredientManager;

        public CreateIngredientsCommand(IReader reader, IWriter writer, IIngredientManager ingredientManager)
            :base(reader,writer)
        {
            this.ingredientManager = ingredientManager;
        }

        public override string Execute()
        {
            var parameters = TakeInput();
            return this.ingredientManager.Create(parameters[0], parameters[1],
                parameters[2], parameters[3], parameters[4], parameters[5]);
        }
        private IList<string> TakeInput()
        {
            var name = base.ReadOneLine("Name: ");
            var kcal = base.ReadOneLine("Kcal: ");
            var protein = base.ReadOneLine("Protein: ");
            var fat = base.ReadOneLine("Fat: ");
            var fibre = base.ReadOneLine("Fibre: ");
            var carbs = base.ReadOneLine("Carbs: ");
            return new List<string>() { name, kcal, protein, fat, fibre, carbs };
        }
    }
}
