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
    public class ListMealsCommand : MealCommand, ICommand
    {
        public ListMealsCommand(IModelFactory factory, IReader reader, IWriter writer, IUserManager userManager, IDatabase database) 
            : base(factory, reader, writer, userManager, database)
        {
        }

        //public string Execute()
        //{
        //    var meals = user.Meals;
        //    string result = null;

        //    if (meals.Count == 0)
        //    {
        //        return "There are no created recipes.";
        //    }

        //    var mealsList = user.Meals.ToList();
        //    foreach (Meal m in mealsList)
        //    {
        //        result += m.Recipes.Single().Name + ' ';
        //    }
        //    return result;
        //}

        public override string Execute()
        {
            foreach (Meal m in UserManager.LoggedUser.Meals)
            {
                this.Writer.WriteLine(string.Format($"Meal Id: {0}; Meal category: {1}, Recipes: {2}, You ate it on: {3}",
                    m.Id,
                    m.MealCategory,
                    m.Recipes,
                    m.Date));
            }
            return "That was your meal!";
        }
    }
}
