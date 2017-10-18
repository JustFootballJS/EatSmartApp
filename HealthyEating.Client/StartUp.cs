

using HealthyEating.Client.Core;
using HealthyEating.Client.Core.Providers;
using HealthyEating.Client.Data;
using HealthyEating.Client.IoC;
using HealthyEating.Client.Migrations;
using HealthyEating.Client.Models;
using Ninject;
using System.Data.Entity;
using System.Linq;

namespace HealthyEating.Client
{
    public class StartUp
    {
        static void Main()
        {
            //IKernel kernel = new StandardKernel(new HealthyEatingModule());

            //var engine = kernel.Get<IEngine>();
            //engine.Run(); 

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<HealthyEatingContext, Configuration>());

            var recipe = new Recipe();
            recipe.Name = "Musaka";
            recipe.Ingredient = null;

            using (var context = new HealthyEatingContext())
            {
                System.Console.WriteLine(context.Recipes.Count());
            }


        }
    }
}
