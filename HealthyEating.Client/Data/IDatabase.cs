using HealthyEating.Client.Models;
using System.Collections;
using System.Collections.Generic;

namespace HealthyEating.Client.Data
{
    public interface IDatabase
    {
        IList<Ingredient> Ingredients { get; set; }

        IList<Recipe> Recipes { get; set; }

        ICollection<User> Users { get; set; }
    }
}