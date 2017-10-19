using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Recipe
    {
        public Recipe()
        {
            this.Meals = new HashSet<Meal>();
            this.Ingredients = new HashSet<Ingredient>();
            this.IsDeleted = false;
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Ingredient> Ingredients { get; set; }
        public virtual ICollection<Meal> Meals {get; set;}

        //public ICollection<User> Users { get; set; }

        public decimal KCAL { get; set; }

        public decimal Protein { get; set; }

        public decimal Fat { get; set; }

        public decimal Carbohydrate { get; set; }

        public decimal Fibre { get; set; }

        public bool IsDeleted { get; set; }
    }
}