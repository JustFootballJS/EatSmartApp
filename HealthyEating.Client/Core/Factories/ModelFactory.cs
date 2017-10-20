using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Models;
using HealthyEating.Client.Utils;
using System;
using System.Collections.Generic;

namespace HealthyEating.Client.Core.Factories
{
    public class ModelFactory : IModelFactory
    {
        public Ingredient CreateIngredient(string name, string kcal, string protein, string fat, string fibre, string carbs)
        {
            return new Ingredient()
            {
                Name = name,
                KCAL = decimal.Parse(kcal),
                Protein = decimal.Parse(protein),
                Fat = decimal.Parse(fat),
                Fibre = decimal.Parse(fibre),
                Carbohydrate = decimal.Parse(carbs)
            };
        }
        public Recipe CreateRecipe(string name, IList<Quantity> quantities)
        {
            return new Recipe() { Name = name,Quantities=quantities };
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

        public Quantity CreateQuantity(Ingredient ingredient, string quantity)
        {
            return new Quantity { Ingredient = ingredient, QuantityValue = decimal.Parse(quantity) };
        }
    }
}
