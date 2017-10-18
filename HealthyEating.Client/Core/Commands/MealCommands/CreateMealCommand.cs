using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyEating.Client.Core.Factories;
using HealthyEating.Client.Utils;

namespace HealthyEating.Client.Core.Commands.MealCommands
{
    class CreateMealCommand
    {
        private readonly IDatabase db;
        private readonly IModelFactory factory;
        private readonly User user;

        public CreateMealCommand(IDatabase db, IModelFactory factory, User user)
        {
            this.db = db;
            this.factory = factory;
            this.user = user;
        }

        public string Execute(IList<string> commandLine)
        {
            MealCategory mealCategory = (MealCategory)Enum.Parse(typeof(MealCategory), commandLine[0], true);
            DateTime date = Convert.ToDateTime(commandLine[1]);
            ICollection<Recipe> recipesToAdd = null;

            for (int i = 1; i < commandLine.Count; i++)
            {
                try
                {
                    recipesToAdd.Add(user.Recipes.Where(rec => rec.Name == commandLine[i]).Single());
                }
                catch
                {
                    throw new ArgumentException("Failed to find recipes in user.");
                }
            }

            var meal = factory.CreateMeal(mealCategory, date, recipesToAdd);
            return $"Meal with ID {db.Meals.Count() - 1} was created!";
        }
    }
}
