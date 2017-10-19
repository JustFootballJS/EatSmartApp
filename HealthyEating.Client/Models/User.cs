using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required]
        [StringLength(16,MinimumLength=3)]
        public string Username { get; set; }

        [Required]
        [StringLength(128, MinimumLength = 8,ErrorMessage ="Password must be between 8 and 128 symbols")]
        public string Password { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public double CurrentWeight { get; set; }

        public virtual Goal Goal { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }

        public bool IsDeleted { get; set; }
    }
}
