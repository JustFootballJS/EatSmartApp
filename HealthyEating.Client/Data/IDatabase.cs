using HealthyEating.Client.Models;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;

namespace HealthyEating.Client.Data
{
    public interface IDatabase
    {
        IDbSet<Ingredient> Ingredients { get; set; }

        IDbSet<Recipe> Recipes { get; set; }

        IDbSet<User> Users { get; set; }

        IDbSet<Meal> Meals { get; set; }

        IDbSet<Quantity> Quantities { get; set; }

        IDbSet<Goal> Goals { get; set; }

        int SaveChanges();
    }
}