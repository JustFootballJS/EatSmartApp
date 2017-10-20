using HealthyEating.Client.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthyEating.Client.Data
{
    public class HealthyEatingContext : DbContext, IDatabase
    {
        public HealthyEatingContext()
            : base("HealthyEating")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Recipe>().HasRequired(m => m.User).WithMany(m => m.Recipes).WillCascadeOnDelete(true);
            modelBuilder.Entity<Quantity>().HasRequired(m => m.Recipe).WithMany(x => x.Quantities).WillCascadeOnDelete(true);
            modelBuilder.Entity<Quantity>().HasRequired(m => m.Ingredient).WithMany(x => x.Quantities).WillCascadeOnDelete(true);
           
            base.OnModelCreating(modelBuilder);

        }

        public virtual IDbSet<Recipe> Recipes { get; set; }

        public virtual IDbSet<Ingredient> Ingredients { get; set; }

        public virtual IDbSet<User> Users { get; set; }

        public virtual IDbSet<Meal> Meals { get; set; }

        public virtual IDbSet<Quantity> Quantities { get; set; }

        public virtual IDbSet<Goal> Goals { get; set; }
       
    }
}
