using HealthyEating.Client.Data;
//using HealthyEating.Client.Migrations;
using HealthyEating.Client.Models;
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

            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HealthyEatingContext, Configuration>());

            var recipe = new Recipe();
            var user = new User();

            user.Username = "Pesho";
            recipe.Name = "Musaka";
            

            using (var context = new HealthyEatingContext())
            {
                context.Users.Add(user);
                context.Recipes.Add(recipe);
                System.Console.WriteLine(context);
                //System.Console.WriteLine(context.Quantities.Count());

                context.SaveChanges();
            }
            


        }
    }
}
