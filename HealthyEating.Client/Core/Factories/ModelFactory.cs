using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;
using HealthyEating.Client.Utils;
using System;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Recipe CreateRecipe(string name, string ingredient)
        {
            return new Recipe() { Name = name, Ingredient = ingredient };
        }

        public User CreateUser(string username, string password)
        {
            return new User() { Username = username, Password = password };
        }

        public Meal CreateMeal(MealCategory mealCategory, DateTime date, ICollection<Recipe> recipes)
        {
            return new Meal() { Date = date, Recipes = recipes };
        }

        public Goal CreateGoal(int maxKcal, int wantedWeight)
        {
            return new Goal() { MaxKcal = maxKcal, WantedWeight = wantedWeight };
        }
    }
}
