using System.Collections.Generic;

namespace HealthyEating.Client.Models
{
    public class User
    {
        public User()
        {
            this.Recipes = new HashSet<Recipe>();
            this.Goals = new HashSet<string>();
            this.Logs = new HashSet<string>();
        }

        public int Id { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }

        public double CurrentWeight { get; set; }

        public ICollection<string> Goals { get; set; }

        public ICollection<string> Logs { get; set; }

        public bool IsDeleted { get; set; }
    }
}
