﻿using HealthyEating.Client.Models;
using HealthyEating.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Core.Contracts
{
    public interface IModelFactory 
    {
        Recipe CreateRecipe(string name, string ingredient);

        User CreateUser(string username, string password);

        Meal CreateMeal(MealCategory mealCategory, DateTime date, ICollection<Recipe> recipes);

        Goal CreateGoal(int maxKcal, int wantedWeight);
    }
}
