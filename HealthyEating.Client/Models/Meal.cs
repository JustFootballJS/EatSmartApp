using HealthyEating.Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Models
{
    public class Meal
    {
        public Meal()
        {
            this.Users = new HashSet<User>();
            this.Recipes = new HashSet<Recipe>();
        }
        public int Id { get; set; }
        
        public MealCategory MealCategory { get; set; }

        public DateTime Date { get; set; }

        public bool isDeleted { get; set; }

        public virtual ICollection<User> Users { get; set; }
        
        public virtual ICollection<Recipe> Recipes { get; set; }
    }


}
