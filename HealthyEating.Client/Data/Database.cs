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
        }
        public IList<Ingredient> Ingredients { get; set; }
        

        public IList<Recipe> Recipes { get; set; }
        
    }
}
