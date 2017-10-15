using HealthyEating.Client.Core.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HealthyEating.Client.Core.Commands.RecomendCommands
{
    public class RecommendFullPortionsCommand : Command, ICommand
    {
        private readonly IFoodRecomender foodRecomender;

        public RecommendFullPortionsCommand(IReader reader, IWriter writer, IFoodRecomender foodRecomender)
            : base(reader, writer)
        {
            this.foodRecomender = foodRecomender;
        }

        public override string Execute(IList<string> commandLine)
        {
            IList<string> inputParameters = this.TakeInput();
            var nutrition = inputParameters[0];
            var maxCalories = decimal.Parse(inputParameters[1]);

            var answer= this.foodRecomender.RecommendFullPortions(maxCalories, nutrition);

            return string.Join(Environment.NewLine, answer.Select(x => x.Name));
        }

        private IList<string> TakeInput()
        {
            var nutrition = base.ReadOneLine("Nutrition: ");
            var maxCalories = base.ReadOneLine("Max calories: ");

            return new List<string>() { nutrition, maxCalories };
        }
    }
}
