using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthyEating.Client.Models;

namespace HealthyEating.Client.Data
{
    public class InMemoryDB : IDatabase
    {
        public InMemoryDB()
        {
            this.Ingredients = new List<Ingredient>();
            this.Recipes = new List<Recipe>();
            this.Users = new HashSet<User>();
            this.Meals = new HashSet<Meal>();
        }

        public IList<Ingredient> Ingredients { get; set; }
        
        public IList<Recipe> Recipes { get; set; }

        public ICollection<User> Users { get; set; }

        public ICollection<Meal> Meals { get; set; }
        
    }
}
