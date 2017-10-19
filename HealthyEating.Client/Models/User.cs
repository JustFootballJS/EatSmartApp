using System.Collections.Generic;

namespace HealthyEating.Client.Models
{
    public class User
    {
        public User()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Meals = new HashSet<Meal>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public double CurrentWeight { get; set; }

        public virtual Goal Goal { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public bool IsDeleted { get; set; }
    }
}
