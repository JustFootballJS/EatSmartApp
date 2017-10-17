using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Data;
using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Commands.MealCommands
{
    public class ListMealsCommand : ICommand
    {
        private readonly IDatabase db;
        private readonly User user;

        public ListMealsCommand(IDatabase db)
        {
            this.db = db;
        }

        public string Execute(IList<string> commandLine)
        {
            var meals = user.Meals;
            string result = null;

            if (meals.Count == 0)
            {
                return "There are no created recipes.";
            }

            var mealsList = user.Meals.ToList();
            foreach (Meal m in mealsList)
            {
                result += m.Recipes.Single().Name + ' ';
            }
            return result;
        }
    }
}
