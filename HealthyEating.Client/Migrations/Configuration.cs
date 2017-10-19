using HealthyEating.Client.Core.Contracts;
using HealthyEating.Client.Core.Providers;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
namespace HealthyEating.Client.Migrations
{
    

    internal sealed class Configuration : DbMigrationsConfiguration<HealthyEating.Client.Data.HealthyEatingContext>
    {
        
        public Configuration()
        {
            //this.jsonProvider = jsonProvider;
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(HealthyEating.Client.Data.HealthyEatingContext context)
        {
            if (context.Ingredients.Count() == 0)
            {
                var jsonProvider = new JsonProvider();
                var ingredients = jsonProvider.SeedIngredients("IngredientsInJSON.txt");
                foreach (var item in ingredients)
                {
                    context.Ingredients.AddOrUpdate(item);
                }


                var xmlProvider = new XMLProvider();
                var ingredientsXML = xmlProvider.ReadUserFromXML("IngredientsInXML.txt");
                foreach (var item in ingredientsXML)
                {
                    context.Ingredients.AddOrUpdate(item);
                }
                context.SaveChanges();
            }
                
            
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
