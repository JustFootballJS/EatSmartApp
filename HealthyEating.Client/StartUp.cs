
using HealthyEating.Client.Core;
using HealthyEating.Client.Data;
using HealthyEating.Client.IoC;
//using HealthyEating.Client.Migrations;
using Ninject;
using System.Data.Entity;


namespace HealthyEating.Client
{
    public class StartUp
    {
        static void Main()
        {
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<HealthyEatingContext, Configuration>());

            IKernel kernel = new StandardKernel(new HealthyEatingModule());

            var engine = kernel.Get<IEngine>();
            engine.Run();
        }
    }
}
